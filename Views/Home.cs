using CardViewer.Models;
using System.ComponentModel;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace CardViewer.Views
{
    public partial class Home : Form
    {
        internal Dictionary<string, Dictionary<CardSet.RarityTier, CardSet>> normalCards;
        internal Dictionary<string, CardSet> mythicCards;
        internal HashSet<Tuple<string, CardSet.RarityTier>> favoriteCards;

        internal static Home? _instance;

        public static readonly string AppDataDir = Environment.ExpandEnvironmentVariables("%localappdata%\\ExLaCardViewer");
        public static readonly string NormalCardPath = AppDataDir + "\\Cards.json";
        public static readonly string MythicCardPath = AppDataDir + "\\MythicCards.json";
        public static readonly string FavoriteCardPath = AppDataDir + "\\FavoriteCards.json";

        // Two way lookup table to convert between RarityTier enum values and readable strings
        public static readonly Dictionary<CardSet.RarityTier, string> RarityNames = new()
        {
            {CardSet.RarityTier.Rare, "Rare"},
            {CardSet.RarityTier.SuperRare, "Super Rare"},
            {CardSet.RarityTier.SuperSuperRare, "Super Super Rare"},
            {CardSet.RarityTier.Mythic, "Mythic"},

        };
        public static readonly Dictionary<string, CardSet.RarityTier> RarityValues = new()
        {
            {"Rare", CardSet.RarityTier.Rare},
            {"Super Rare", CardSet.RarityTier.SuperRare},
            {"Super Super Rare", CardSet.RarityTier.SuperSuperRare},
            {"Mythic", CardSet.RarityTier.Mythic}
        };

        private static readonly Color unselectedColor = Color.FromArgb(0x44, 0x44, 0x44);
        private static readonly Color selectedColor = Color.FromArgb(0xFF, 0x2A, 0x6D);

        private CardSet? selectedCard = null;
        private bool cardAnimated = false;
        private int currentPage = 0;

        private MemoryStream?[] loadedImageStreams = new MemoryStream[6];
        private Image?[] loadedImages = new Image[6];

        private enum ImageSlot
        {
            Portrait,
            PortraitAnim,
            Ability,
            AbilityAnim,
            Lore,
            LoreAnim
        }

        public Home()
        {
            normalCards = new Dictionary<string, Dictionary<CardSet.RarityTier, CardSet>>();
            mythicCards = new Dictionary<string, CardSet>();
            favoriteCards = new HashSet<Tuple<string, CardSet.RarityTier>>();
            _instance = this;

            InitializeComponent();
        }

        /// <summary>
        /// Onload event for Home form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Home_Load(object sender, EventArgs e)
        {
            // ensure that the app data directory exists
            if (!Directory.Exists(AppDataDir))
            {
                Directory.CreateDirectory(AppDataDir);
            }

            if (File.Exists(NormalCardPath))
            {
                // Load dictionary from the JSON file
                using (FileStream fs = File.OpenRead(NormalCardPath))
                {
                    normalCards = await JsonSerializer.DeserializeAsync<Dictionary<string, Dictionary<CardSet.RarityTier, CardSet>>>(fs) ?? new Dictionary<string, Dictionary<CardSet.RarityTier, CardSet>>();
                }
            }

            if (File.Exists(MythicCardPath))
            {
                // Load dictionary from the JSON file
                using (FileStream fs = File.OpenRead(MythicCardPath))
                {
                    mythicCards = await JsonSerializer.DeserializeAsync<Dictionary<string, CardSet>>(fs) ?? new Dictionary<string, CardSet>();
                }
            }

            if (File.Exists(FavoriteCardPath))
            {
                // Load set from the JSON file
                using (FileStream fs = File.OpenRead(FavoriteCardPath))
                {
                    favoriteCards = await JsonSerializer.DeserializeAsync<HashSet<Tuple<string, CardSet.RarityTier>>>(fs) ?? new HashSet<Tuple<string, CardSet.RarityTier>>();
                }
            }

            labelVersion.Text = Program.Version;

            LinkedList<Tuple<string, CardSet.RarityTier>> corruptCards = new();

            TreeNode? seriesNode = null;

            foreach (string cardName in normalCards.Keys.OrderBy(SortCards))
            {
                TreeNode charNode = new TreeNode(cardName);

                string series = normalCards[cardName][normalCards[cardName].Keys.First()].Series;
                if (seriesNode == null || seriesNode.Text != series)
                {
                    seriesNode = new TreeNode(series);
                    treeViewCards.Nodes[0].Nodes.Add(seriesNode);
                }
                seriesNode.Nodes.Add(charNode);
                foreach (CardSet.RarityTier rarity in normalCards[cardName].Keys.Order())
                {
                    if (!CheckValidPaths(normalCards[cardName][rarity]))
                    {
                        corruptCards.AddLast(new Tuple<string, CardSet.RarityTier>(cardName, rarity));
                        continue;
                    }

                    charNode.Nodes.Add(new TreeNode(RarityNames[rarity]));
                }

                if (charNode.Nodes.Count == 0)
                {
                    charNode.Remove();
                }
            }

            foreach (string setName in mythicCards.Keys)
            {
                if (!CheckValidPaths(mythicCards[setName]))
                {
                    corruptCards.AddLast(new Tuple<string, CardSet.RarityTier>(setName, CardSet.RarityTier.Mythic));
                    continue;
                }
                treeViewCards.Nodes[1].Nodes.Add(new TreeNode(setName));
            }

            foreach (var card in favoriteCards.Order())
            {
                if (corruptCards.Contains(card))
                {
                    continue;
                }
                string nodeName = card.Item1 + " - " + RarityNames[card.Item2];
                treeViewCards.Nodes[2].Nodes.Add(new TreeNode(nodeName));
            }

            if (corruptCards.Count > 0)
            {
                StringBuilder sb = new StringBuilder("The following cards contained invalid data and have been deleted to prevent issues:\n");
                foreach (var card in corruptCards)
                {
                    sb.Append(card.Item1);
                    sb.Append(" - ");
                    sb.AppendLine(RarityNames[card.Item2]);

                    if (card.Item2 == CardSet.RarityTier.Mythic)
                    {
                        mythicCards.Remove(card.Item1);
                    }
                    else
                    {
                        normalCards[card.Item1].Remove(card.Item2);
                        if (normalCards[card.Item1].Count == 0)
                        {
                            normalCards.Remove(card.Item1);
                        }
                    }

                    favoriteCards.Remove(card);
                }
                await SaveAllDataAsync();

                new Alert(sb.ToString()).ShowDialog();
            }
        }

        /// <summary>
        /// Checks if every file path on a card set points to the appdata directory.
        /// </summary>
        /// <param name="set">The card set to check</param>
        /// <returns>true if every path is valid</returns>
        private bool CheckValidPaths(CardSet set)
        {
            string[] paths =
            [
                set.Portrait.ImageFile,
                set.Portrait.AnimFile ?? string.Empty,
                set.Ability.ImageFile,
                set.Ability.AnimFile ?? string.Empty,
                set.Lore.ImageFile,
                set.Lore.AnimFile ?? string.Empty,
            ];

            string imageDir = AppDataDir + "\\images";
            foreach (string path in paths)
            {
                if (path == string.Empty)
                {
                    continue;
                }

                if (Path.GetDirectoryName(path) != imageDir)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Sorter method that generates a sorting key for a card set
        /// </summary>
        /// <param name="name">The "Name" property of a card set</param>
        /// <returns>A sorting key based on the data of the card set</returns>
        private string SortCards(string name)
        {
            var subDict = normalCards[name];
            var card = subDict[subDict.Keys.First()];
            return $"{card.Series}|{card.Number}";
        }

        private void buttonPortrait_Click(object sender, EventArgs e)
        {
            if (selectedCard != null && currentPage != 0)
            {
                ShowPage(0);
            }
        }

        private void buttonAbility_Click(object sender, EventArgs e)
        {
            if (selectedCard != null && currentPage != 1)
            {
                ShowPage(1);
            }
        }

        private void buttonLore_Click(object sender, EventArgs e)
        {
            if (selectedCard != null && currentPage != 2)
            {
                ShowPage(2);
            }
        }

        /// <summary>
        /// Event handler for Add Card button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonAddCard_Click(object sender, EventArgs e)
        {
            CardSet newSet = new CardSet();
            Form editCardForm = new EditCardSet(ref newSet);
            DialogResult result = editCardForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                await AddCardAsync(newSet);
            }
        }

        /// <summary>
        /// Event handler for Import Card button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonImportCard_Click(object sender, EventArgs e)
        {
            if (openFileImportCard.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(openFileImportCard.FileName) != ".json")
                {
                    new Alert("Card data must be a .json file.").ShowDialog();
                }
                else
                {
                    CardSet? newSet = null;
                    using (Stream stream = openFileImportCard.OpenFile())
                    {
                        if (stream != null)
                        {
                            newSet = JsonSerializer.Deserialize<CardSet>(stream);
                        }
                    }

                    if (newSet == null)
                    {
                        new Alert("Invalid card data.").ShowDialog();
                        return;
                    }

                    Form editCardForm = new EditCardSet(ref newSet);
                    if (editCardForm.ShowDialog() == DialogResult.OK)
                    {
                        await AddCardAsync(newSet);
                    }
                }
            }
        }

        /// <summary>
        /// Helper method to add a card set to the underlying data structure as well as the display.
        /// </summary>
        /// <param name="set">The set to add</param>
        private async Task AddCardAsync(CardSet set)
        {
            if (set.Rarity == CardSet.RarityTier.Mythic)
            {
                mythicCards.Add(set.Name, set);
                TreeNode newNode = new TreeNode(set.Name);
                treeViewCards.Nodes[1].Nodes.Add(newNode);

                treeViewCards.SelectedNode = newNode;

                await SaveFileAsync(MythicCardPath, mythicCards);
            }
            else
            {
                TreeNode? charNode = null;
                TreeNode? seriesNode = null;

                foreach (TreeNode node in treeViewCards.Nodes[0].Nodes)
                {
                    if (node.Text == set.Series)
                    {
                        seriesNode = node;
                        break;
                    }
                }
                if (seriesNode == null)
                {
                    seriesNode = new TreeNode(set.Series);
                    treeViewCards.Nodes[0].Nodes.Add(seriesNode);
                }

                if (normalCards.TryGetValue(set.Name, out var innerDict))
                {
                    innerDict.Add(set.Rarity, set);
                    foreach (TreeNode node in seriesNode.Nodes)
                    {
                        if (node.Text == set.Name)
                        {
                            charNode = node;
                            break;
                        }
                    }
                }
                else
                {
                    normalCards.Add(set.Name, new Dictionary<CardSet.RarityTier, CardSet>());
                    normalCards[set.Name].Add(set.Rarity, set);
                    charNode = new TreeNode(set.Name);
                    seriesNode.Nodes.Add(charNode);
                }
                TreeNode newNode = new TreeNode(RarityNames[set.Rarity]);
                charNode.Nodes.Add(newNode);

                treeViewCards.SelectedNode = newNode;

                await SaveFileAsync(NormalCardPath, normalCards);
            }
            treeViewCards.Refresh();
        }

        /// <summary>
        /// Event handler for Export Card buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
#pragma warning disable CS8600, CS8602
        private async void exportCard_Click(object sender, EventArgs e)
        {
            if (selectedCard == null)
            {
                return;
            }
            CardSet newCardSet = selectedCard.Clone() as CardSet;

            newCardSet.Portrait.ImageFile = "";
            newCardSet.Portrait.AnimFile = null;
            newCardSet.Ability.ImageFile = "";
            newCardSet.Ability.AnimFile = null;
            newCardSet.Lore.ImageFile = "";
            newCardSet.Lore.AnimFile = null;

            saveFileExportCard.FileName = $"{newCardSet.Name}_{newCardSet.Rarity}.json";
            if (saveFileExportCard.ShowDialog() == DialogResult.OK)
            {
                using (var stream = saveFileExportCard.OpenFile())
                {
                    if (stream != null)
                    {
                        await JsonSerializer.SerializeAsync(stream, newCardSet);
                    }
                }
            }

        }
#pragma warning restore CS8600, CS8602

        /// <summary>
        /// Background task to save all data files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async Task SaveAllDataAsync()
        {
            Task.WaitAll(SaveFileAsync(NormalCardPath, normalCards), SaveFileAsync(MythicCardPath, mythicCards), SaveFileAsync(FavoriteCardPath, favoriteCards));
        }

        /// <summary>
        /// Background task to save a specific file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static async Task SaveFileAsync(string path, object obj)
        {
            using (FileStream fs = File.Create(path))
            {
                await JsonSerializer.SerializeAsync(fs, obj);
            }
        }

        /// <summary>
        /// Background task to load images for a card set
        /// </summary>
        /// <param name="set"></param>
        private async Task LoadImagesAsync(CardSet set)
        {
            List<Task> loadTasks = new List<Task>();

            loadTasks.Add(LoadImageFileAsync(set.Portrait.ImageFile, ImageSlot.Portrait));

            if (set.Portrait.AnimFile != null)
            {
                loadTasks.Add(LoadImageFileAsync(set.Portrait.AnimFile, ImageSlot.PortraitAnim));
            }
            else
            {
                loadedImages[(int)ImageSlot.PortraitAnim]?.Dispose();
                loadedImages[(int)ImageSlot.PortraitAnim] = null;
                loadedImageStreams[(int)ImageSlot.PortraitAnim]?.Dispose();
                loadedImageStreams[(int)ImageSlot.PortraitAnim] = null;
            }

            loadTasks.Add(LoadImageFileAsync(set.Ability.ImageFile, ImageSlot.Ability));

            if (set.Ability.AnimFile != null)
            {
                loadTasks.Add(LoadImageFileAsync(set.Ability.AnimFile, ImageSlot.AbilityAnim));
            }
            else
            {
                loadedImages[(int)ImageSlot.AbilityAnim]?.Dispose();
                loadedImages[(int)ImageSlot.AbilityAnim] = null;
                loadedImageStreams[(int)ImageSlot.AbilityAnim]?.Dispose();
                loadedImageStreams[(int)ImageSlot.AbilityAnim] = null;
            }

            loadTasks.Add(LoadImageFileAsync(set.Lore.ImageFile, ImageSlot.Lore));

            if (set.Lore.AnimFile != null)
            {
                loadTasks.Add(LoadImageFileAsync(set.Lore.AnimFile, ImageSlot.LoreAnim));
            }
            else
            {
                loadedImages[(int)ImageSlot.LoreAnim]?.Dispose();
                loadedImages[(int)ImageSlot.LoreAnim] = null;
                loadedImageStreams[(int)ImageSlot.LoreAnim]?.Dispose();
                loadedImageStreams[(int)ImageSlot.LoreAnim] = null;
            }

            await Task.WhenAll(loadTasks);
        }

        private async Task LoadImageFileAsync(string path, ImageSlot slot)
        {
            // dispose previous images
            loadedImages[(int)slot]?.Dispose();
            loadedImageStreams[(int)slot]?.Dispose();

            // new stream
            MemoryStream imageStream = new MemoryStream();

            using (FileStream fs = File.OpenRead(path))
            {
                // using CopyToAsync results in a deadlock for some reason
                await fs.CopyToAsync(imageStream);
            }

            loadedImageStreams[(int)slot] = imageStream;
            loadedImages[(int)slot] = Image.FromStream(imageStream);
        }

        /// <summary>
        /// Item selection event handler for the tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // disabling null reference warnings here since most things are implicitly null checked and the compiler isn't good at catching that
#pragma warning disable CS8600, CS8602
        private async void treeViewCards_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeViewCards.SelectedNode;
            if (node.Level == 0 || (node.Level == 1 && node.Parent.Name == "nodeStandardCards") || (node.Level == 2 && node.Parent.Parent.Name == "nodeStandardCards"))
            {
                return;
            }

            if (node.Parent.Name == "nodeMythicCards")
            {
                selectedCard = mythicCards[node.Text];
            }
            else if (node.Parent.Name == "nodeFavoriteCards")
            {
                Match match = Regex.Match(node.Text, "(.+) - (.+)");
                CardSet.RarityTier rarity = RarityValues[match.Groups[2].Value];
                if (rarity == CardSet.RarityTier.Mythic)
                {
                    selectedCard = mythicCards[match.Groups[1].Value];
                }
                else
                {
                    selectedCard = normalCards[match.Groups[1].Value][rarity];
                }
            }
            else
            {
                selectedCard = normalCards[node.Parent.Text][RarityValues[node.Text]];
            }

            labelCharName.Text = selectedCard.Name.ToUpper();

            if (favoriteCards.Contains(new Tuple<string, CardSet.RarityTier>(selectedCard.Name, selectedCard.Rarity)))
            {
                buttonFavorite.Text = "REMOVE FAVORITE";
            }
            else
            {
                buttonFavorite.Text = "ADD FAVORITE";
            }

            await UpdateDisplayAsync();
        }
#pragma warning restore CS8600, CS8602

        /// <summary>
        /// Event handler for the Edit Card buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonEdit_Click(object sender, EventArgs e)
        {
            if (selectedCard == null)
            {
                return;
            }

            CardSet set = selectedCard;

            Form editCardForm = new EditCardSet(ref set, true);
            DialogResult result = editCardForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                Task saveTask;
                if (set.Rarity == CardSet.RarityTier.Mythic)
                {
                    mythicCards[set.Name] = set;

                    saveTask = SaveFileAsync(MythicCardPath, mythicCards);
                }
                else
                {
                    normalCards[set.Name][set.Rarity] = set;

                    saveTask = SaveFileAsync(NormalCardPath, normalCards);
                }

                await UpdateDisplayAsync();

                await saveTask;
            }
        }

        /// <summary>
        /// Event handler for the Delete Card buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (selectedCard == null)
            {
                return;
            }

            ConfirmDelete form = new ConfirmDelete();
            if (form.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            CardSet set = selectedCard;
            selectedCard = null;
            panelCardDisplay.Visible = false;

            File.Delete(set.Portrait.ImageFile);
            if (set.Portrait.AnimFile != null)
            {
                File.Delete(set.Portrait.AnimFile);
            }
            File.Delete(set.Ability.ImageFile);
            if (set.Ability.AnimFile != null)
            {
                File.Delete(set.Ability.AnimFile);
            }
            File.Delete(set.Lore.ImageFile);
            if (set.Lore.AnimFile != null)
            {
                File.Delete(set.Lore.AnimFile);
            }

            if (favoriteCards.Remove(new Tuple<string, CardSet.RarityTier>(set.Name, set.Rarity)))
            {
                foreach (TreeNode node in treeViewCards.Nodes[2].Nodes)
                {
                    if (node.Text == $"{set.Name} - {RarityNames[set.Rarity]}")
                    {
                        node.Remove();
                        break;
                    }
                }
            }

            if (set.Rarity == CardSet.RarityTier.Mythic)
            {
                mythicCards.Remove(set.Name);
                foreach (TreeNode node in treeViewCards.Nodes[1].Nodes)
                {
                    if (node.Text == set.Name)
                    {
                        node.Remove();
                        break;
                    }
                }
            }
            else
            {
                normalCards[set.Name].Remove(set.Rarity);
                if (normalCards[set.Name].Count == 0)
                {
                    normalCards.Remove(set.Name);
                }
                foreach (TreeNode seriesNode in treeViewCards.Nodes[0].Nodes)
                {
                    if (seriesNode.Text == set.Series)
                    {
                        foreach (TreeNode charNode in seriesNode.Nodes)
                        {
                            if (charNode.Text == set.Name)
                            {
                                foreach (TreeNode rarityNode in charNode.Nodes)
                                {
                                    if (rarityNode.Text == RarityNames[set.Rarity])
                                    {
                                        rarityNode.Remove();
                                        break;
                                    }
                                }
                                if (charNode.Nodes.Count == 0)
                                {
                                    charNode.Remove();
                                }
                                break;
                            }
                        }
                        if (seriesNode.Nodes.Count == 0)
                        {
                            seriesNode.Remove();
                        }
                        break;
                    }
                }
            }
            await SaveAllDataAsync();
        }

        /// <summary>
        /// Event handler for the Toggle Favorite buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonFavorite_Click(object sender, EventArgs e)
        {
            if (selectedCard == null)
            {
                return;
            }

            Tuple<string, CardSet.RarityTier> cardTuple = new(selectedCard.Name, selectedCard.Rarity);
            string nodeName = selectedCard.Name + " - " + RarityNames[selectedCard.Rarity];
            if (favoriteCards.Remove(cardTuple))
            {
                foreach (TreeNode node in treeViewCards.Nodes[2].Nodes)
                {
                    if (node.Text == nodeName)
                    {
                        treeViewCards.Nodes[2].Nodes.Remove(node);
                        break;
                    }
                }

                buttonFavorite.Text = "ADD FAVORITE";
            }
            else
            {
                favoriteCards.Add(cardTuple);
                treeViewCards.Nodes[2].Nodes.Add(new TreeNode(nodeName));

                buttonFavorite.Text = "REMOVE FAVORITE";
            }

            await SaveFileAsync(FavoriteCardPath, favoriteCards);
        }

        /// <summary>
        /// Helper method that updates the display with the data for the currently selected card.
        /// </summary>
        /// <exception cref="InvalidOperationException">if no card is currently selected</exception>
        private async Task UpdateDisplayAsync()
        {
            if (selectedCard == null)
            {
                throw new InvalidOperationException();
            }

            currentPage = 0;
            Task loadImageTask = LoadImagesAsync(selectedCard);

            labelSeries.Text = selectedCard.Rarity == CardSet.RarityTier.Mythic ? $"Mythic - {selectedCard.Series}" : $"{selectedCard.Series} Series #{selectedCard.Number}";

            switch (selectedCard.Rarity)
            {
                case (CardSet.RarityTier.Rare):
                    pictureBoxRarity.Image = Properties.Resources.rarityStar_Rare;
                    break;
                case (CardSet.RarityTier.SuperRare):
                    pictureBoxRarity.Image = Properties.Resources.rarityStar_SR;
                    break;
                case (CardSet.RarityTier.SuperSuperRare):
                    pictureBoxRarity.Image = Properties.Resources.rarityStar_SSR;
                    break;
                case (CardSet.RarityTier.Mythic):
                    pictureBoxRarity.Image = Properties.Resources.rarityStar_Mythic;
                    break;
            }

            try
            {
                await loadImageTask;
            }
            catch (Exception e)
            {
                if (e.InnerException is FileNotFoundException)
                {
                    new Alert("One or more image files could not be found.").ShowDialog();
                }
                else
                {
                    new Alert("Something went wrong when loading card images.").ShowDialog();
                }
                panelCardDisplay.Visible = false;
                return;
            }

            panelCardDisplay.Visible = true;
            ShowPage(0);
        }

        private void ShowPage(int pageNum)
        {
            if (selectedCard == null)
            {
                throw new InvalidOperationException();
            }
            currentPage = pageNum;

            panelLoreDetails.Visible = false;
            labelBody1.Visible = false;
            labelHeader2.Visible = false;
            labelBody2.Visible = false;
            labelQuote.Visible = false;

            switch (pageNum)
            {
                case 0:
                    buttonPortrait.BackColor = selectedColor;
                    buttonAbility.BackColor = unselectedColor;
                    buttonLore.BackColor = unselectedColor;

                    labelHeader1.Text = selectedCard.Portrait.Title;

                    labelAnimAvailable.Visible = selectedCard.Portrait.AnimFile != null;

                    if (loadedImageStreams[(int)ImageSlot.Portrait] != null)
                    {
                        pictureBoxCard.Image = loadedImages[(int)ImageSlot.Portrait];
                    }
                    break;
                case 1:
                    buttonAbility.BackColor = selectedColor;
                    buttonPortrait.BackColor = unselectedColor;
                    buttonLore.BackColor = unselectedColor;

                    labelHeader1.Text = "Ability: " + selectedCard.Ability.AbilityName;
                    labelBody1.Visible = true;
                    labelBody1.Text = selectedCard.Ability.AbilityDesc;

                    labelAnimAvailable.Visible = selectedCard.Ability.AnimFile != null;

                    if (loadedImageStreams[(int)ImageSlot.Ability] != null)
                    {
                        pictureBoxCard.Image = loadedImages[(int)ImageSlot.Ability];
                    }
                    break;
                case 2:
                    buttonLore.BackColor = selectedColor;
                    buttonPortrait.BackColor = unselectedColor;
                    buttonAbility.BackColor = unselectedColor;

                    panelLoreDetails.Visible = true;

                    labelDetail1Name.Text = selectedCard.Lore.Detail1Name;
                    labelDetail1.Text = selectedCard.Lore.Detail1;
                    labelDetail2Name.Text = selectedCard.Lore.Detail2Name;
                    labelDetail2.Text = selectedCard.Lore.Detail2;

                    labelQuote.Visible = true;
                    labelBody2.Visible = true;
                    labelHeader2.Visible = true;
                    labelBody1.Visible = true;

                    labelHeader1.Text = selectedCard.Lore.Story1Title;
                    labelBody1.Text = selectedCard.Lore.Story1;
                    labelHeader2.Text = selectedCard.Lore.Story2Title;
                    labelBody2.Text = selectedCard.Lore.Story2;
                    labelQuote.Text = $"\"{selectedCard.Lore.Quote}\"";

                    labelAnimAvailable.Visible = selectedCard.Lore.AnimFile != null;

                    if (loadedImageStreams[(int)ImageSlot.Lore] != null)
                    {
                        pictureBoxCard.Image = loadedImages[(int)ImageSlot.Lore];
                    }
                    break;
            }

            labelBody1.BringToFront();
            labelHeader2.BringToFront();
            labelBody2.BringToFront();
            labelQuote.BringToFront();

            panelButtons.Refresh();
            panelCardDisplay.Refresh();
        }

        /// <summary>
        /// Event handler to catch space bar press events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyPressEvent(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                if (selectedCard == null)
                {
                    return;
                }
                else if (!cardAnimated)
                {
                    switch (currentPage)
                    {
                        case 0:
                            if (loadedImages[(int)ImageSlot.PortraitAnim] != null)
                            {
                                pictureBoxCard.Image = loadedImages[(int)ImageSlot.PortraitAnim];
                            }
                            break;
                        case 1:
                            if (loadedImages[(int)ImageSlot.AbilityAnim] != null)
                            {
                                pictureBoxCard.Image = loadedImages[(int)ImageSlot.AbilityAnim];
                            }
                            break;
                        case 2:
                            if (loadedImages[(int)ImageSlot.LoreAnim] != null)
                            {
                                pictureBoxCard.Image = loadedImages[(int)ImageSlot.LoreAnim];
                            }
                            break;
                    }

                    cardAnimated = true;
                }
                else
                {
                    switch (currentPage)
                    {
                        case 0:
                            if (loadedImages[(int)ImageSlot.Portrait] != null)
                            {
                                pictureBoxCard.Image = loadedImages[(int)ImageSlot.Portrait];
                            }
                            break;
                        case 1:
                            if (loadedImages[(int)ImageSlot.Ability] != null)
                            {
                                pictureBoxCard.Image = loadedImages[(int)ImageSlot.Ability];
                            }
                            break;
                        case 2:
                            if (loadedImages[(int)ImageSlot.Lore] != null)
                            {
                                pictureBoxCard.Image = loadedImages[(int)ImageSlot.Lore];
                            }
                            break;
                    }

                    cardAnimated = false;
                }

                e.Handled = true;
            }
        }
    }
}
