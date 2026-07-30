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

        private MemoryStream? portraitImageStream;
        private Image? portraitImage;
        private MemoryStream? portraitAnimStream;
        private Image? portraitAnim;
        private MemoryStream? abilityImageStream;
        private Image? abilityImage;
        private MemoryStream? abilityAnimStream;
        private Image? abilityAnim;
        private MemoryStream? loreImageStream;
        private Image? loreImage;
        private MemoryStream? loreAnimStream;
        private Image? loreAnim;

        public Home()
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
                    normalCards = JsonSerializer.Deserialize<Dictionary<string, Dictionary<CardSet.RarityTier, CardSet>>>(fs) ?? new Dictionary<string, Dictionary<CardSet.RarityTier, CardSet>>();
                }
            }
            else
            {
                // Initialize empty dictionary
                normalCards = new Dictionary<string, Dictionary<CardSet.RarityTier, CardSet>>();
            }

            if (File.Exists(MythicCardPath))
            {
                // Load dictionary from the JSON file
                using (FileStream fs = File.OpenRead(MythicCardPath))
                {
                    mythicCards = JsonSerializer.Deserialize<Dictionary<string, CardSet>>(fs) ?? new Dictionary<string, CardSet>();
                }
            }
            else
            {
                // Initialize empty dictionary
                mythicCards = new Dictionary<string, CardSet>();
            }

            if (File.Exists(FavoriteCardPath))
            {
                // Load set from the JSON file
                using (FileStream fs = File.OpenRead(FavoriteCardPath))
                {
                    favoriteCards = JsonSerializer.Deserialize<HashSet<Tuple<string, CardSet.RarityTier>>>(fs) ?? new HashSet<Tuple<string, CardSet.RarityTier>>();
                }
            }
            else
            {
                // Initialize empty set
                favoriteCards = new HashSet<Tuple<string, CardSet.RarityTier>>();
            }

            InitializeComponent();

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
                backgroundWorkerSaveData.RunWorkerAsync("a");

                Alert alertForm = new Alert(sb.ToString());
                alertForm.ShowDialog();
            }

            _instance = this;
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
        private void buttonAddCard_Click(object sender, EventArgs e)
        {
            CardSet newSet = new CardSet();
            Form editCardForm = new EditCardSet(ref newSet);
            DialogResult result = editCardForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                AddCard(newSet);
            }
        }

        /// <summary>
        /// Event handler for Import Card button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonImportCard_Click(object sender, EventArgs e)
        {
            if (openFileImportCard.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(openFileImportCard.FileName) != ".json")
                {
                    Alert form = new Alert("Card data must be a .json file.");
                    form.ShowDialog();
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
                        Alert form = new Alert("Invalid card data.");
                        form.ShowDialog();
                        return;
                    }

                    Form editCardForm = new EditCardSet(ref newSet);
                    if (editCardForm.ShowDialog() == DialogResult.OK)
                    {
                        AddCard(newSet);
                    }
                }
            }
        }

        /// <summary>
        /// Helper method to add a card set to the underlying data structure as well as the display.
        /// </summary>
        /// <param name="set">The set to add</param>
        private void AddCard(CardSet set)
        {
            if (set.Rarity == CardSet.RarityTier.Mythic)
            {
                mythicCards.Add(set.Name, set);
                TreeNode newNode = new TreeNode(set.Name);
                treeViewCards.Nodes[1].Nodes.Add(newNode);

                treeViewCards.SelectedNode = newNode;

                backgroundWorkerSaveData.RunWorkerAsync("m");
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

                backgroundWorkerSaveData.RunWorkerAsync("n");
            }
            treeViewCards.Refresh();
        }

        /// <summary>
        /// Event handler for Export Card buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
#pragma warning disable CS8600, CS8602
        private void exportCard_Click(object sender, EventArgs e)
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
                        JsonSerializer.Serialize(stream, newCardSet);
                    }
                }
            }

        }
#pragma warning restore CS8600, CS8602

        /// <summary>
        /// Do Work event handler for the save data background worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorkerSaveData_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (e.Argument as string)
            {
                case "n":
                    using (FileStream fs = File.Create(NormalCardPath))
                    {
                        JsonSerializer.Serialize(fs, normalCards);
                    }
                    break;
                case "m":
                    using (FileStream fs = File.Create(MythicCardPath))
                    {
                        JsonSerializer.Serialize(fs, mythicCards);
                    }
                    break;
                case "f":
                    using (FileStream fs = File.Create(FavoriteCardPath))
                    {
                        JsonSerializer.Serialize(fs, favoriteCards);
                    }
                    break;
                default:
                    using (FileStream fs = File.Create(NormalCardPath))
                    {
                        JsonSerializer.Serialize(fs, normalCards);
                    }
                    using (FileStream fs = File.Create(MythicCardPath))
                    {
                        JsonSerializer.Serialize(fs, mythicCards);
                    }
                    using (FileStream fs = File.Create(FavoriteCardPath))
                    {
                        JsonSerializer.Serialize(fs, favoriteCards);
                    }
                    break;
            }
        }

        /// <summary>
        /// Do Work event handler for the image loading background worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="ArgumentException"></exception>
        private void backgroundWorkerLoadImage_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument == null || e.Argument is not CardSet)
            {
                throw new ArgumentException("Argument must be a CardSet");
            }

            CardSet set = (CardSet)e.Argument;

            portraitImage?.Dispose();
            portraitImageStream?.Dispose();
            portraitImageStream = new MemoryStream();
            using (FileStream fs = File.OpenRead(set.Portrait.ImageFile))
            {
                fs.CopyTo(portraitImageStream);
            }
            portraitImage = Image.FromStream(portraitImageStream);


            portraitAnim?.Dispose();
            portraitAnimStream?.Dispose();
            if (set.Portrait.AnimFile != null)
            {
                portraitAnimStream = new MemoryStream();
                using (FileStream fs = File.OpenRead(set.Portrait.AnimFile))
                {
                    fs.CopyTo(portraitAnimStream);
                }
                portraitAnim = Image.FromStream(portraitAnimStream);
            }

            abilityImage?.Dispose();
            abilityImageStream?.Dispose();
            abilityImageStream = new MemoryStream();
            using (FileStream fs = File.OpenRead(set.Ability.ImageFile))
            {
                fs.CopyTo(abilityImageStream);
            }
            abilityImage = Image.FromStream(abilityImageStream);

            abilityAnim?.Dispose();
            abilityAnimStream?.Dispose();
            if (set.Ability.AnimFile != null)
            {
                abilityAnimStream = new MemoryStream();
                using (FileStream fs = File.OpenRead(set.Ability.AnimFile))
                {
                    fs.CopyTo(abilityAnimStream);
                }
                abilityAnim = Image.FromStream(abilityAnimStream);
            }

            loreImage?.Dispose();
            loreImageStream?.Dispose();
            loreImageStream = new MemoryStream();
            using (FileStream fs = File.OpenRead(set.Lore.ImageFile))
            {
                fs.CopyTo(loreImageStream);
            }
            loreImage = Image.FromStream(loreImageStream);

            loreAnim?.Dispose();
            loreAnimStream?.Dispose();
            if (set.Lore.AnimFile != null)
            {
                loreAnimStream = new MemoryStream();
                using (FileStream fs = File.OpenRead(set.Lore.AnimFile))
                {
                    fs.CopyTo(loreAnimStream);
                }
                loreAnim = Image.FromStream(loreAnimStream);
            }

            // invoke garbage collect to clean up old images and prevent using a lot of memory
            GC.Collect();
        }

        /// <summary>
        /// Item selection event handler for the tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // disabling null reference warnings here since most things are implicitly null checked and the compiler isn't good at catching that
#pragma warning disable CS8600, CS8602
        private void treeViewCards_AfterSelect(object sender, TreeViewEventArgs e)
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

            UpdateDisplay();
            panelCardDisplay.Visible = true;
        }
#pragma warning restore CS8600, CS8602

        /// <summary>
        /// Event handler for the Edit Card buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEdit_Click(object sender, EventArgs e)
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
                if (set.Rarity == CardSet.RarityTier.Mythic)
                {
                    mythicCards[set.Name] = set;

                    backgroundWorkerSaveData.RunWorkerAsync("m");
                }
                else
                {
                    normalCards[set.Name][set.Rarity] = set;

                    backgroundWorkerSaveData.RunWorkerAsync("n");
                }

                UpdateDisplay();
            }
        }

        /// <summary>
        /// Event handler for the Delete Card buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, EventArgs e)
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
            backgroundWorkerSaveData.RunWorkerAsync("a");
        }

        /// <summary>
        /// Event handler for the Toggle Favorite buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFavorite_Click(object sender, EventArgs e)
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

            backgroundWorkerSaveData.RunWorkerAsync("f");
        }

        /// <summary>
        /// Helper method that updates the display with the data for the currently selected card.
        /// </summary>
        /// <exception cref="InvalidOperationException">if no card is currently selected</exception>
        private void UpdateDisplay()
        {
            if (selectedCard == null)
            {
                throw new InvalidOperationException();
            }

            currentPage = 0;
            backgroundWorkerLoadImage.RunWorkerAsync(selectedCard);

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
            ShowPage(0);
        }

        private void ShowPage(int pageNum)
        {
            if (selectedCard == null)
            {
                throw new InvalidOperationException();
            }
            currentPage = pageNum;

            switch (pageNum)
            {
                case 0:
                    buttonPortrait.BackColor = selectedColor;
                    buttonAbility.BackColor = unselectedColor;
                    buttonLore.BackColor = unselectedColor;

                    panelLoreDetails.Visible = false;

                    labelHeader1.Text = selectedCard.Portrait.Title;
                    labelBody1.Visible = false;
                    labelHeader2.Visible = false;
                    labelBody2.Visible = false;
                    labelQuote.Visible = false;

                    labelAnimAvailable.Visible = selectedCard.Portrait.AnimFile != null;

                    while (backgroundWorkerLoadImage.IsBusy)
                    {
                        Application.DoEvents();
                    }
                    if (portraitImageStream != null)
                    {
                        pictureBoxCard.Image = portraitImage;
                    }
                    break;
                case 1:
                    buttonAbility.BackColor = selectedColor;
                    buttonPortrait.BackColor = unselectedColor;
                    buttonLore.BackColor = unselectedColor;

                    panelLoreDetails.Visible = false;

                    labelHeader1.Text = "Ability: " + selectedCard.Ability.AbilityName;
                    labelBody1.Visible = true;
                    labelBody1.Text = selectedCard.Ability.AbilityDesc;
                    labelHeader2.Visible = false;
                    labelBody2.Visible = false;
                    labelQuote.Visible = false;

                    labelAnimAvailable.Visible = selectedCard.Ability.AnimFile != null;

                    while (backgroundWorkerLoadImage.IsBusy)
                    {
                        Application.DoEvents();
                    }
                    if (abilityImageStream != null)
                    {
                        pictureBoxCard.Image = abilityImage;
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

                    labelBody1.Visible = false; // need to make the controls visible in a specific order to make sure they display correctly
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

                    while (backgroundWorkerLoadImage.IsBusy)
                    {
                        Application.DoEvents();
                    }
                    if (loreImageStream != null)
                    {
                        pictureBoxCard.Image = loreImage;
                    }
                    break;
            }

            this.Focus();
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
                            if (portraitAnim != null)
                            {
                                pictureBoxCard.Image = portraitAnim;
                            }
                            break;
                        case 1:
                            if (abilityAnim != null)
                            {
                                pictureBoxCard.Image = abilityAnim;
                            }
                            break;
                        case 2:
                            if (loreAnim != null)
                            {
                                pictureBoxCard.Image = loreAnim;
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
                            if (portraitImage != null)
                            {
                                pictureBoxCard.Image = portraitImage;
                            }
                            break;
                        case 1:
                            if (abilityImage != null)
                            {
                                pictureBoxCard.Image = abilityImage;
                            }
                            break;
                        case 2:
                            if (loreImage != null)
                            {
                                pictureBoxCard.Image = loreImage;
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
