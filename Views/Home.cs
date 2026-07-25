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

        private CardSet? selectedCard = null;
        private bool cardAnimated = false;

        private MemoryStream? portraitImageStream;
        private MemoryStream? portraitAnimStream;
        private MemoryStream? abilityImageStream;
        private MemoryStream? abilityAnimStream;
        private MemoryStream? loreImageStream;
        private MemoryStream? loreAnimStream;

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

            foreach (string cardName in normalCards.Keys.OrderBy(SortCards))
            {
                int nodeIndex = treeViewCards.Nodes[0].Nodes.Add(new TreeNode(cardName));
                foreach (CardSet.RarityTier rarity in normalCards[cardName].Keys.Order())
                {
                    if (!CheckValidPaths(normalCards[cardName][rarity]))
                    {
                        corruptCards.AddLast(new Tuple<string, CardSet.RarityTier>(cardName, rarity));
                        continue;
                    }

                    treeViewCards.Nodes[0].Nodes[nodeIndex].Nodes.Add(new TreeNode(RarityNames[rarity]));
                }

                if (treeViewCards.Nodes[0].Nodes[nodeIndex].Nodes.Count == 0)
                {
                    treeViewCards.Nodes[0].Nodes[nodeIndex].Remove();
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

            foreach (var card in favoriteCards)
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

        private string SortCards(string name)
        {
            var subDict = normalCards[name];
            var card = subDict[subDict.Keys.ElementAt(0)];
            return $"{card.Series}|{card.Number}";
        }

        private void buttonAddCard_Click(object sender, EventArgs e)
        {
            CardSet newSet = new CardSet();
            Form editCardForm = new EditCardSet(ref newSet);
            DialogResult result = editCardForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (newSet.Rarity == CardSet.RarityTier.Mythic)
                {
                    mythicCards.Add(newSet.Name, newSet);
                    treeViewCards.Nodes[1].Nodes.Add(new TreeNode(newSet.Name));

                    backgroundWorkerSaveData.RunWorkerAsync("m");
                }
                else
                {
                    int nodeIndex = -1;
                    if (normalCards.TryGetValue(newSet.Name, out var innerDict))
                    {
                        innerDict.Add(newSet.Rarity, newSet);
                        foreach (TreeNode node in treeViewCards.Nodes[0].Nodes)
                        {
                            if (node.Text == newSet.Name)
                            {
                                nodeIndex = treeViewCards.Nodes[0].Nodes.IndexOf(node);
                                break;
                            }
                        }
                    }
                    else
                    {
                        normalCards.Add(newSet.Name, new Dictionary<CardSet.RarityTier, CardSet>());
                        normalCards[newSet.Name].Add(newSet.Rarity, newSet);
                        nodeIndex = treeViewCards.Nodes[0].Nodes.Add(new TreeNode(newSet.Name));
                    }
                    TreeNode newNode = new TreeNode(RarityNames[newSet.Rarity]);
                    treeViewCards.Nodes[0].Nodes[nodeIndex].Nodes.Add(newNode);

                    backgroundWorkerSaveData.RunWorkerAsync("n");
                }
                treeViewCards.Refresh();
            }
        }

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

        private void backgroundWorkerLoadImage_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument == null || e.Argument is not CardSet)
            {
                throw new ArgumentException("Argument must be a CardSet");
            }

            CardSet set = (CardSet) e.Argument;

            portraitImageStream?.Dispose();
            portraitImageStream = new MemoryStream();
            using (FileStream fs = File.OpenRead(set.Portrait.ImageFile))
            {
                fs.CopyTo(portraitImageStream);
            }
            pictureBoxPortrait.Image = Image.FromStream(portraitImageStream);

            if (set.Portrait.AnimFile != null)
            {
                portraitAnimStream?.Dispose();
                portraitAnimStream = new MemoryStream();
                using (FileStream fs = File.OpenRead(set.Portrait.AnimFile))
                {
                    fs.CopyTo(portraitAnimStream);
                }
            }

            abilityImageStream?.Dispose();
            abilityImageStream = new MemoryStream();
            using (FileStream fs = File.OpenRead(set.Ability.ImageFile))
            {
                fs.CopyTo(abilityImageStream);
            }
            pictureBoxAbility.Image = Image.FromStream(abilityImageStream);

            if (set.Ability.AnimFile != null)
            {
                abilityAnimStream?.Dispose();
                abilityAnimStream = new MemoryStream();
                using (FileStream fs = File.OpenRead(set.Ability.AnimFile))
                {
                    fs.CopyTo(abilityAnimStream);
                }
            }

            loreImageStream?.Dispose();
            loreImageStream = new MemoryStream();
            using (FileStream fs = File.OpenRead(set.Lore.ImageFile))
            {
                fs.CopyTo(loreImageStream);
            }
            pictureBoxLore.Image = Image.FromStream(loreImageStream);

            if (set.Lore.AnimFile != null)
            {
                loreAnimStream?.Dispose();
                loreAnimStream = new MemoryStream();
                using (FileStream fs = File.OpenRead(set.Lore.AnimFile))
                {
                    fs.CopyTo(loreAnimStream);
                }
            }
        }

        // disabling null reference warnings here since most things are implicitly null checked and the compiler isn't good at catching that
#pragma warning disable CS8600, CS8602
        private void treeViewCards_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeViewCards.SelectedNode;
            if (node.Level == 0 || (node.Level == 1 && node.Parent.Name == "nodeStandardCards"))
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

            cardDisplay.Visible = true;

            labelNamePortrait.Text = selectedCard.Name;
            labelNameAbility.Text = selectedCard.Name;
            labelNameLore.Text = selectedCard.Name;

            if (favoriteCards.Contains(new Tuple<string, CardSet.RarityTier>(selectedCard.Name, selectedCard.Rarity)))
            {
                buttonFavoritePortrait.Text = "Remove from Favorites";
                buttonFavoriteAbility.Text = "Remove from Favorites";
                buttonFavoriteLore.Text = "Remove from Favorites";
            }
            else
            {
                buttonFavoritePortrait.Text = "Add to Favorites";
                buttonFavoriteAbility.Text = "Add to Favorites";
                buttonFavoriteLore.Text = "Add to Favorites";
            }

            cardDisplay.SelectedIndex = 0;

            UpdateDisplay();
        }
#pragma warning restore CS8600, CS8602

        private void editCard_Click(object sender, EventArgs e)
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

        private void deleteCard_Click(object sender, EventArgs e)
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
            cardDisplay.Visible = false;

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
                foreach (TreeNode node in treeViewCards.Nodes[0].Nodes)
                {
                    if (node.Text == set.Name)
                    {
                        foreach (TreeNode subNode in node.Nodes)
                        {
                            if (subNode.Text == RarityNames[set.Rarity])
                            {
                                subNode.Remove();
                                break;
                            }
                        }
                        if (node.Nodes.Count == 0)
                        {
                            node.Remove();
                        }
                        break;
                    }
                }
            }
            backgroundWorkerSaveData.RunWorkerAsync("a");
        }

        private void toggleFavorite_Click(object sender, EventArgs e)
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

                buttonFavoritePortrait.Text = "Add to Favorites";
                buttonFavoriteAbility.Text = "Add to Favorites";
                buttonFavoriteLore.Text = "Add to Favorites";
            }
            else
            {
                favoriteCards.Add(cardTuple);
                treeViewCards.Nodes[2].Nodes.Add(new TreeNode(nodeName));

                buttonFavoritePortrait.Text = "Remove from Favorites";
                buttonFavoriteAbility.Text = "Remove from Favorites";
                buttonFavoriteLore.Text = "Remove from Favorites";
            }

            backgroundWorkerSaveData.RunWorkerAsync("f");
        }

        private void UpdateDisplay()
        {
            if (selectedCard == null)
            {
                throw new InvalidOperationException();
            }

            backgroundWorkerLoadImage.RunWorkerAsync(selectedCard);

            string series = $"{selectedCard.Series} Series #{selectedCard.Number}";
            labelSeriesPortrait.Text = series;
            labelSeriesAbility.Text = series;
            labelSeriesLore.Text = series;
            
            labelPortraitAnim.Visible = selectedCard.Portrait.AnimFile != null;

            labelPortraitTitle.Text = selectedCard.Portrait.Title;

            labelAbilityAnim.Visible = selectedCard.Ability.AnimFile != null;

            labelAbilityName.Text = "Ability: " + selectedCard.Ability.AbilityName;
            labelAbility.Text = selectedCard.Ability.AbilityDesc;

            labelLoreAnim.Visible = selectedCard.Lore.AnimFile != null;

            labelDetail1Name.Text = selectedCard.Lore.Detail1Name;
            labelDetail1.Text = selectedCard.Lore.Detail1;
            labelDetail2Name.Text = selectedCard.Lore.Detail2Name;
            labelDetail2.Text = selectedCard.Lore.Detail2;
            labelStory1Title.Text = selectedCard.Lore.Story1Title;
            labelStory1.Text = selectedCard.Lore.Story1;
            labelStory2Title.Text = selectedCard.Lore.Story2Title;
            labelStory2.Text = selectedCard.Lore.Story2;
            labelQuote.Text = $"\"{selectedCard.Lore.Quote}\"";

            switch (selectedCard.Rarity)
            {
                case (CardSet.RarityTier.Rare):
                    pictureBoxRarityPortrait.Image = Properties.Resources.rarityStar_Rare;
                    pictureBoxRarityAbility.Image = Properties.Resources.rarityStar_Rare;
                    pictureBoxRarityLore.Image = Properties.Resources.rarityStar_Rare;
                    break;
                case (CardSet.RarityTier.SuperRare):
                    pictureBoxRarityPortrait.Image = Properties.Resources.rarityStar_SR;
                    pictureBoxRarityAbility.Image = Properties.Resources.rarityStar_SR;
                    pictureBoxRarityLore.Image = Properties.Resources.rarityStar_SR;
                    break;
                case (CardSet.RarityTier.SuperSuperRare):
                    pictureBoxRarityPortrait.Image = Properties.Resources.rarityStar_SSR;
                    pictureBoxRarityAbility.Image = Properties.Resources.rarityStar_SSR;
                    pictureBoxRarityLore.Image = Properties.Resources.rarityStar_SSR;
                    break;
                case (CardSet.RarityTier.Mythic):
                    pictureBoxRarityPortrait.Image = Properties.Resources.rarityStar_Mythic;
                    pictureBoxRarityAbility.Image = Properties.Resources.rarityStar_Mythic;
                    pictureBoxRarityLore.Image = Properties.Resources.rarityStar_Mythic;
                    break;
            }

            cardDisplay.Refresh();
        }

        private void cardDisplay_Selecting(object sender, EventArgs e)
        {
            if (cardAnimated)
            {
                StopAnimation();
            }
        }

        private void cardDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                if (!cardAnimated)
                {
                    StartAnimation();
                }
                else
                {
                    StopAnimation();
                }
            }
        }

        private void StartAnimation()
        {
            if (selectedCard == null || cardAnimated)
            {
                return;
            }

            switch (cardDisplay.SelectedIndex)
            {
                case 0:
                    if (portraitAnimStream != null)
                    {
                        pictureBoxPortrait.Image = Image.FromStream(portraitAnimStream);
                    }
                    break;
                case 1:
                    if (abilityAnimStream != null)
                    {
                        pictureBoxAbility.Image = Image.FromStream(abilityAnimStream);
                    }
                    break;
                case 2:
                    if (loreAnimStream != null)
                    {
                        pictureBoxLore.Image = Image.FromStream(loreAnimStream);
                    }
                    break;
            }

            cardAnimated = true;
        }

        private void StopAnimation()
        {
            if (selectedCard == null || !cardAnimated)
            {
                return;
            }

            pictureBoxPortrait.Image = Image.FromStream(portraitImageStream);
            pictureBoxAbility.Image = Image.FromStream(abilityImageStream);
            pictureBoxLore.Image = Image.FromStream(loreImageStream);

            cardAnimated = false;
        }
    }
}
