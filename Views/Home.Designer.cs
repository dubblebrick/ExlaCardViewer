namespace CardViewer.Views
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TreeNode treeNode1 = new TreeNode("Standard Cards");
            TreeNode treeNode2 = new TreeNode("Mythic Cards");
            TreeNode treeNode3 = new TreeNode("Favorites");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            treeViewCards = new TreeView();
            cardDisplay = new TabControl();
            tabPortrait = new TabPage();
            panelPortrait = new Panel();
            labelPortraitAnim = new Label();
            buttonDeletePortrait = new Button();
            pictureBoxRarityPortrait = new PictureBox();
            buttonEditPortrait = new Button();
            labelPortraitTitle = new Label();
            buttonFavoritePortrait = new Button();
            labelNamePortrait = new Label();
            labelSeriesPortrait = new Label();
            pictureBoxPortrait = new PictureBox();
            tabAbility = new TabPage();
            panelAbility = new Panel();
            labelAbilityAnim = new Label();
            buttonFavoriteAbility = new Button();
            buttonEditAbility = new Button();
            buttonDeleteAbility = new Button();
            pictureBoxRarityAbility = new PictureBox();
            labelAbility = new Label();
            labelAbilityName = new Label();
            labelNameAbility = new Label();
            labelSeriesAbility = new Label();
            pictureBoxAbility = new PictureBox();
            tabLore = new TabPage();
            panel1 = new Panel();
            labelLoreAnim = new Label();
            buttonDeleteLore = new Button();
            labelQuote = new Label();
            buttonEditLore = new Button();
            pictureBoxRarityLore = new PictureBox();
            buttonFavoriteLore = new Button();
            labelStory2 = new Label();
            labelSeriesLore = new Label();
            labelNameLore = new Label();
            labelStory2Title = new Label();
            labelStory1 = new Label();
            labelDetail2Name = new Label();
            labelStory1Title = new Label();
            labelDetail2 = new Label();
            labelDetail1Name = new Label();
            labelDetail1 = new Label();
            pictureBoxLore = new PictureBox();
            buttonAddCard = new Button();
            backgroundWorkerSaveData = new System.ComponentModel.BackgroundWorker();
            labelVersion = new Label();
            backgroundWorkerLoadImage = new System.ComponentModel.BackgroundWorker();
            cardDisplay.SuspendLayout();
            tabPortrait.SuspendLayout();
            panelPortrait.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRarityPortrait).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPortrait).BeginInit();
            tabAbility.SuspendLayout();
            panelAbility.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRarityAbility).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAbility).BeginInit();
            tabLore.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRarityLore).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLore).BeginInit();
            SuspendLayout();
            // 
            // treeViewCards
            // 
            treeViewCards.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            treeViewCards.Location = new Point(17, 12);
            treeViewCards.Name = "treeViewCards";
            treeNode1.Name = "nodeStandardCards";
            treeNode1.Text = "Standard Cards";
            treeNode2.Name = "nodeMythicCards";
            treeNode2.Text = "Mythic Cards";
            treeNode3.Name = "nodeFavoriteCards";
            treeNode3.Text = "Favorites";
            treeViewCards.Nodes.AddRange(new TreeNode[] { treeNode1, treeNode2, treeNode3 });
            treeViewCards.Size = new Size(211, 696);
            treeViewCards.TabIndex = 1;
            treeViewCards.AfterSelect += treeViewCards_AfterSelect;
            treeViewCards.KeyPress += cardDisplay_KeyPress;
            // 
            // cardDisplay
            // 
            cardDisplay.Controls.Add(tabPortrait);
            cardDisplay.Controls.Add(tabAbility);
            cardDisplay.Controls.Add(tabLore);
            cardDisplay.Dock = DockStyle.Right;
            cardDisplay.Location = new Point(250, 0);
            cardDisplay.Name = "cardDisplay";
            cardDisplay.SelectedIndex = 0;
            cardDisplay.Size = new Size(934, 761);
            cardDisplay.TabIndex = 3;
            cardDisplay.Visible = false;
            cardDisplay.Selecting += cardDisplay_Selecting;
            cardDisplay.KeyPress += cardDisplay_KeyPress;
            // 
            // tabPortrait
            // 
            tabPortrait.Controls.Add(panelPortrait);
            tabPortrait.Controls.Add(pictureBoxPortrait);
            tabPortrait.Location = new Point(4, 24);
            tabPortrait.Name = "tabPortrait";
            tabPortrait.Padding = new Padding(3);
            tabPortrait.Size = new Size(926, 733);
            tabPortrait.TabIndex = 0;
            tabPortrait.Text = "Portrait";
            tabPortrait.UseVisualStyleBackColor = true;
            // 
            // panelPortrait
            // 
            panelPortrait.Controls.Add(labelPortraitAnim);
            panelPortrait.Controls.Add(buttonDeletePortrait);
            panelPortrait.Controls.Add(pictureBoxRarityPortrait);
            panelPortrait.Controls.Add(buttonEditPortrait);
            panelPortrait.Controls.Add(labelPortraitTitle);
            panelPortrait.Controls.Add(buttonFavoritePortrait);
            panelPortrait.Controls.Add(labelNamePortrait);
            panelPortrait.Controls.Add(labelSeriesPortrait);
            panelPortrait.Dock = DockStyle.Fill;
            panelPortrait.Location = new Point(523, 3);
            panelPortrait.Name = "panelPortrait";
            panelPortrait.Size = new Size(400, 727);
            panelPortrait.TabIndex = 8;
            // 
            // labelPortraitAnim
            // 
            labelPortraitAnim.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelPortraitAnim.AutoSize = true;
            labelPortraitAnim.Location = new Point(6, 648);
            labelPortraitAnim.Name = "labelPortraitAnim";
            labelPortraitAnim.Size = new Size(311, 15);
            labelPortraitAnim.TabIndex = 21;
            labelPortraitAnim.Text = "Animated card available! Press space to toggle animation.";
            // 
            // buttonDeletePortrait
            // 
            buttonDeletePortrait.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonDeletePortrait.Location = new Point(207, 697);
            buttonDeletePortrait.Margin = new Padding(3, 3, 6, 3);
            buttonDeletePortrait.Name = "buttonDeletePortrait";
            buttonDeletePortrait.Size = new Size(190, 25);
            buttonDeletePortrait.TabIndex = 6;
            buttonDeletePortrait.Text = "Delete Card";
            buttonDeletePortrait.UseVisualStyleBackColor = true;
            buttonDeletePortrait.Click += deleteCard_Click;
            // 
            // pictureBoxRarityPortrait
            // 
            pictureBoxRarityPortrait.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxRarityPortrait.InitialImage = Properties.Resources.rarityStar_Rare;
            pictureBoxRarityPortrait.Location = new Point(0, 35);
            pictureBoxRarityPortrait.Name = "pictureBoxRarityPortrait";
            pictureBoxRarityPortrait.Size = new Size(400, 25);
            pictureBoxRarityPortrait.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxRarityPortrait.TabIndex = 20;
            pictureBoxRarityPortrait.TabStop = false;
            // 
            // buttonEditPortrait
            // 
            buttonEditPortrait.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonEditPortrait.Location = new Point(6, 697);
            buttonEditPortrait.Margin = new Padding(6, 3, 3, 3);
            buttonEditPortrait.Name = "buttonEditPortrait";
            buttonEditPortrait.Size = new Size(190, 25);
            buttonEditPortrait.TabIndex = 5;
            buttonEditPortrait.Text = "Edit Card";
            buttonEditPortrait.UseVisualStyleBackColor = true;
            buttonEditPortrait.Click += editCard_Click;
            // 
            // labelPortraitTitle
            // 
            labelPortraitTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelPortraitTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPortraitTitle.Location = new Point(0, 104);
            labelPortraitTitle.Margin = new Padding(3, 11, 3, 0);
            labelPortraitTitle.Name = "labelPortraitTitle";
            labelPortraitTitle.Size = new Size(400, 22);
            labelPortraitTitle.TabIndex = 7;
            labelPortraitTitle.Text = "portrait title";
            labelPortraitTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // buttonFavoritePortrait
            // 
            buttonFavoritePortrait.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonFavoritePortrait.Location = new Point(6, 666);
            buttonFavoritePortrait.Name = "buttonFavoritePortrait";
            buttonFavoritePortrait.Size = new Size(391, 25);
            buttonFavoritePortrait.TabIndex = 4;
            buttonFavoritePortrait.Text = "Add to Favorites";
            buttonFavoritePortrait.UseVisualStyleBackColor = true;
            buttonFavoritePortrait.Click += toggleFavorite_Click;
            // 
            // labelNamePortrait
            // 
            labelNamePortrait.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelNamePortrait.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNamePortrait.Location = new Point(0, 63);
            labelNamePortrait.Name = "labelNamePortrait";
            labelNamePortrait.Size = new Size(400, 30);
            labelNamePortrait.TabIndex = 1;
            labelNamePortrait.Text = "name";
            labelNamePortrait.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelSeriesPortrait
            // 
            labelSeriesPortrait.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelSeriesPortrait.Location = new Point(0, 0);
            labelSeriesPortrait.Name = "labelSeriesPortrait";
            labelSeriesPortrait.Size = new Size(400, 15);
            labelSeriesPortrait.TabIndex = 2;
            labelSeriesPortrait.Text = "series";
            labelSeriesPortrait.TextAlign = ContentAlignment.TopRight;
            // 
            // pictureBoxPortrait
            // 
            pictureBoxPortrait.Dock = DockStyle.Left;
            pictureBoxPortrait.Location = new Point(3, 3);
            pictureBoxPortrait.Name = "pictureBoxPortrait";
            pictureBoxPortrait.Size = new Size(520, 727);
            pictureBoxPortrait.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPortrait.TabIndex = 0;
            pictureBoxPortrait.TabStop = false;
            // 
            // tabAbility
            // 
            tabAbility.Controls.Add(panelAbility);
            tabAbility.Controls.Add(pictureBoxAbility);
            tabAbility.Location = new Point(4, 24);
            tabAbility.Name = "tabAbility";
            tabAbility.Padding = new Padding(3);
            tabAbility.Size = new Size(926, 733);
            tabAbility.TabIndex = 1;
            tabAbility.Text = "Ability";
            tabAbility.UseVisualStyleBackColor = true;
            // 
            // panelAbility
            // 
            panelAbility.Controls.Add(labelAbilityAnim);
            panelAbility.Controls.Add(buttonFavoriteAbility);
            panelAbility.Controls.Add(buttonEditAbility);
            panelAbility.Controls.Add(buttonDeleteAbility);
            panelAbility.Controls.Add(pictureBoxRarityAbility);
            panelAbility.Controls.Add(labelAbility);
            panelAbility.Controls.Add(labelAbilityName);
            panelAbility.Controls.Add(labelNameAbility);
            panelAbility.Controls.Add(labelSeriesAbility);
            panelAbility.Dock = DockStyle.Fill;
            panelAbility.Location = new Point(523, 3);
            panelAbility.Name = "panelAbility";
            panelAbility.Size = new Size(400, 727);
            panelAbility.TabIndex = 15;
            // 
            // labelAbilityAnim
            // 
            labelAbilityAnim.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelAbilityAnim.AutoSize = true;
            labelAbilityAnim.Location = new Point(6, 648);
            labelAbilityAnim.Name = "labelAbilityAnim";
            labelAbilityAnim.Size = new Size(311, 15);
            labelAbilityAnim.TabIndex = 22;
            labelAbilityAnim.Text = "Animated card available! Press space to toggle animation.";
            // 
            // buttonFavoriteAbility
            // 
            buttonFavoriteAbility.Location = new Point(6, 666);
            buttonFavoriteAbility.Name = "buttonFavoriteAbility";
            buttonFavoriteAbility.Size = new Size(391, 25);
            buttonFavoriteAbility.TabIndex = 10;
            buttonFavoriteAbility.Text = "Add to Favorites";
            buttonFavoriteAbility.UseVisualStyleBackColor = true;
            buttonFavoriteAbility.Click += toggleFavorite_Click;
            // 
            // buttonEditAbility
            // 
            buttonEditAbility.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonEditAbility.Location = new Point(6, 697);
            buttonEditAbility.Margin = new Padding(6, 3, 3, 3);
            buttonEditAbility.Name = "buttonEditAbility";
            buttonEditAbility.Size = new Size(190, 25);
            buttonEditAbility.TabIndex = 11;
            buttonEditAbility.Text = "Edit Card";
            buttonEditAbility.UseVisualStyleBackColor = true;
            buttonEditAbility.Click += editCard_Click;
            // 
            // buttonDeleteAbility
            // 
            buttonDeleteAbility.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonDeleteAbility.Location = new Point(207, 697);
            buttonDeleteAbility.Margin = new Padding(3, 3, 6, 3);
            buttonDeleteAbility.Name = "buttonDeleteAbility";
            buttonDeleteAbility.Size = new Size(190, 25);
            buttonDeleteAbility.TabIndex = 12;
            buttonDeleteAbility.Text = "Delete Card";
            buttonDeleteAbility.UseVisualStyleBackColor = true;
            buttonDeleteAbility.Click += deleteCard_Click;
            // 
            // pictureBoxRarityAbility
            // 
            pictureBoxRarityAbility.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxRarityAbility.InitialImage = Properties.Resources.rarityStar_Rare;
            pictureBoxRarityAbility.Location = new Point(0, 35);
            pictureBoxRarityAbility.Name = "pictureBoxRarityAbility";
            pictureBoxRarityAbility.Size = new Size(400, 25);
            pictureBoxRarityAbility.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxRarityAbility.TabIndex = 21;
            pictureBoxRarityAbility.TabStop = false;
            // 
            // labelAbility
            // 
            labelAbility.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelAbility.Location = new Point(0, 126);
            labelAbility.Name = "labelAbility";
            labelAbility.Size = new Size(400, 200);
            labelAbility.TabIndex = 14;
            labelAbility.Text = "Ability";
            // 
            // labelAbilityName
            // 
            labelAbilityName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAbilityName.Location = new Point(0, 104);
            labelAbilityName.Margin = new Padding(3, 11, 3, 0);
            labelAbilityName.Name = "labelAbilityName";
            labelAbilityName.Size = new Size(400, 22);
            labelAbilityName.TabIndex = 13;
            labelAbilityName.Text = "Ability name";
            labelAbilityName.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelNameAbility
            // 
            labelNameAbility.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNameAbility.Location = new Point(0, 63);
            labelNameAbility.Name = "labelNameAbility";
            labelNameAbility.Size = new Size(400, 30);
            labelNameAbility.TabIndex = 8;
            labelNameAbility.Text = "name";
            labelNameAbility.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelSeriesAbility
            // 
            labelSeriesAbility.Dock = DockStyle.Top;
            labelSeriesAbility.Location = new Point(0, 0);
            labelSeriesAbility.Name = "labelSeriesAbility";
            labelSeriesAbility.Size = new Size(400, 15);
            labelSeriesAbility.TabIndex = 9;
            labelSeriesAbility.Text = "series";
            labelSeriesAbility.TextAlign = ContentAlignment.TopRight;
            // 
            // pictureBoxAbility
            // 
            pictureBoxAbility.Dock = DockStyle.Left;
            pictureBoxAbility.Location = new Point(3, 3);
            pictureBoxAbility.Name = "pictureBoxAbility";
            pictureBoxAbility.Size = new Size(520, 727);
            pictureBoxAbility.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxAbility.TabIndex = 7;
            pictureBoxAbility.TabStop = false;
            // 
            // tabLore
            // 
            tabLore.Controls.Add(panel1);
            tabLore.Controls.Add(pictureBoxLore);
            tabLore.Location = new Point(4, 24);
            tabLore.Name = "tabLore";
            tabLore.Padding = new Padding(3);
            tabLore.Size = new Size(926, 733);
            tabLore.TabIndex = 2;
            tabLore.Text = "Lore";
            tabLore.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(labelLoreAnim);
            panel1.Controls.Add(buttonDeleteLore);
            panel1.Controls.Add(labelQuote);
            panel1.Controls.Add(buttonEditLore);
            panel1.Controls.Add(pictureBoxRarityLore);
            panel1.Controls.Add(buttonFavoriteLore);
            panel1.Controls.Add(labelStory2);
            panel1.Controls.Add(labelSeriesLore);
            panel1.Controls.Add(labelNameLore);
            panel1.Controls.Add(labelStory2Title);
            panel1.Controls.Add(labelStory1);
            panel1.Controls.Add(labelDetail2Name);
            panel1.Controls.Add(labelStory1Title);
            panel1.Controls.Add(labelDetail2);
            panel1.Controls.Add(labelDetail1Name);
            panel1.Controls.Add(labelDetail1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(523, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 727);
            panel1.TabIndex = 23;
            // 
            // labelLoreAnim
            // 
            labelLoreAnim.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelLoreAnim.AutoSize = true;
            labelLoreAnim.Location = new Point(6, 648);
            labelLoreAnim.Name = "labelLoreAnim";
            labelLoreAnim.Size = new Size(311, 15);
            labelLoreAnim.TabIndex = 23;
            labelLoreAnim.Text = "Animated card available! Press space to toggle animation.";
            // 
            // buttonDeleteLore
            // 
            buttonDeleteLore.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonDeleteLore.Location = new Point(207, 697);
            buttonDeleteLore.Margin = new Padding(3, 3, 6, 3);
            buttonDeleteLore.Name = "buttonDeleteLore";
            buttonDeleteLore.Size = new Size(190, 25);
            buttonDeleteLore.TabIndex = 12;
            buttonDeleteLore.Text = "Delete Card";
            buttonDeleteLore.UseVisualStyleBackColor = true;
            buttonDeleteLore.Click += deleteCard_Click;
            // 
            // labelQuote
            // 
            labelQuote.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelQuote.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelQuote.Location = new Point(0, 555);
            labelQuote.Margin = new Padding(3, 11, 3, 0);
            labelQuote.Name = "labelQuote";
            labelQuote.Size = new Size(399, 60);
            labelQuote.TabIndex = 21;
            labelQuote.Text = "quote";
            labelQuote.TextAlign = ContentAlignment.TopCenter;
            // 
            // buttonEditLore
            // 
            buttonEditLore.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonEditLore.Location = new Point(6, 697);
            buttonEditLore.Margin = new Padding(6, 3, 3, 3);
            buttonEditLore.Name = "buttonEditLore";
            buttonEditLore.Size = new Size(190, 25);
            buttonEditLore.TabIndex = 11;
            buttonEditLore.Text = "Edit Card";
            buttonEditLore.UseVisualStyleBackColor = true;
            buttonEditLore.Click += editCard_Click;
            // 
            // pictureBoxRarityLore
            // 
            pictureBoxRarityLore.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxRarityLore.InitialImage = Properties.Resources.rarityStar_Rare;
            pictureBoxRarityLore.Location = new Point(0, 35);
            pictureBoxRarityLore.Name = "pictureBoxRarityLore";
            pictureBoxRarityLore.Size = new Size(400, 25);
            pictureBoxRarityLore.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxRarityLore.TabIndex = 22;
            pictureBoxRarityLore.TabStop = false;
            // 
            // buttonFavoriteLore
            // 
            buttonFavoriteLore.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonFavoriteLore.Location = new Point(6, 666);
            buttonFavoriteLore.Name = "buttonFavoriteLore";
            buttonFavoriteLore.Size = new Size(391, 25);
            buttonFavoriteLore.TabIndex = 10;
            buttonFavoriteLore.Text = "Add to Favorites";
            buttonFavoriteLore.UseVisualStyleBackColor = true;
            buttonFavoriteLore.Click += toggleFavorite_Click;
            // 
            // labelStory2
            // 
            labelStory2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelStory2.Location = new Point(0, 359);
            labelStory2.Name = "labelStory2";
            labelStory2.Size = new Size(399, 185);
            labelStory2.TabIndex = 20;
            labelStory2.Text = "story 2";
            // 
            // labelSeriesLore
            // 
            labelSeriesLore.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelSeriesLore.Location = new Point(0, 0);
            labelSeriesLore.Name = "labelSeriesLore";
            labelSeriesLore.Size = new Size(400, 15);
            labelSeriesLore.TabIndex = 9;
            labelSeriesLore.Text = "series";
            labelSeriesLore.TextAlign = ContentAlignment.TopRight;
            // 
            // labelNameLore
            // 
            labelNameLore.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelNameLore.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNameLore.Location = new Point(0, 63);
            labelNameLore.Name = "labelNameLore";
            labelNameLore.Size = new Size(400, 30);
            labelNameLore.TabIndex = 8;
            labelNameLore.Text = "name";
            labelNameLore.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelStory2Title
            // 
            labelStory2Title.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelStory2Title.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStory2Title.Location = new Point(0, 334);
            labelStory2Title.Margin = new Padding(3, 11, 3, 0);
            labelStory2Title.Name = "labelStory2Title";
            labelStory2Title.Size = new Size(399, 25);
            labelStory2Title.TabIndex = 17;
            labelStory2Title.Text = "story 2 title";
            labelStory2Title.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelStory1
            // 
            labelStory1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelStory1.Location = new Point(0, 174);
            labelStory1.Name = "labelStory1";
            labelStory1.Size = new Size(399, 185);
            labelStory1.TabIndex = 19;
            labelStory1.Text = "story 1";
            // 
            // labelDetail2Name
            // 
            labelDetail2Name.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelDetail2Name.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelDetail2Name.Location = new Point(207, 104);
            labelDetail2Name.Margin = new Padding(3, 11, 3, 0);
            labelDetail2Name.Name = "labelDetail2Name";
            labelDetail2Name.Size = new Size(190, 22);
            labelDetail2Name.TabIndex = 15;
            labelDetail2Name.Text = "detail 2 name";
            labelDetail2Name.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelStory1Title
            // 
            labelStory1Title.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelStory1Title.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStory1Title.Location = new Point(0, 152);
            labelStory1Title.Margin = new Padding(3, 11, 3, 0);
            labelStory1Title.Name = "labelStory1Title";
            labelStory1Title.Size = new Size(400, 22);
            labelStory1Title.TabIndex = 18;
            labelStory1Title.Text = "story 1 title";
            labelStory1Title.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelDetail2
            // 
            labelDetail2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelDetail2.Location = new Point(208, 126);
            labelDetail2.Name = "labelDetail2";
            labelDetail2.Size = new Size(191, 15);
            labelDetail2.TabIndex = 16;
            labelDetail2.Text = "detail 2";
            labelDetail2.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelDetail1Name
            // 
            labelDetail1Name.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDetail1Name.Location = new Point(-2, 104);
            labelDetail1Name.Margin = new Padding(3, 11, 3, 0);
            labelDetail1Name.Name = "labelDetail1Name";
            labelDetail1Name.Size = new Size(198, 22);
            labelDetail1Name.TabIndex = 13;
            labelDetail1Name.Text = "detail 1 name";
            labelDetail1Name.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelDetail1
            // 
            labelDetail1.Location = new Point(-1, 126);
            labelDetail1.Name = "labelDetail1";
            labelDetail1.Size = new Size(198, 15);
            labelDetail1.TabIndex = 14;
            labelDetail1.Text = "detail 1\r\n";
            labelDetail1.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictureBoxLore
            // 
            pictureBoxLore.Dock = DockStyle.Left;
            pictureBoxLore.Location = new Point(3, 3);
            pictureBoxLore.Name = "pictureBoxLore";
            pictureBoxLore.Size = new Size(520, 727);
            pictureBoxLore.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLore.TabIndex = 7;
            pictureBoxLore.TabStop = false;
            // 
            // buttonAddCard
            // 
            buttonAddCard.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAddCard.Location = new Point(17, 714);
            buttonAddCard.Name = "buttonAddCard";
            buttonAddCard.Size = new Size(211, 25);
            buttonAddCard.TabIndex = 5;
            buttonAddCard.Text = "Add Card";
            buttonAddCard.UseVisualStyleBackColor = true;
            buttonAddCard.Click += buttonAddCard_Click;
            // 
            // backgroundWorkerSaveData
            // 
            backgroundWorkerSaveData.DoWork += backgroundWorkerSaveData_DoWork;
            // 
            // labelVersion
            // 
            labelVersion.AutoSize = true;
            labelVersion.Location = new Point(12, 742);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(23, 15);
            labelVersion.TabIndex = 6;
            labelVersion.Text = "ver";
            // 
            // backgroundWorkerLoadImage
            // 
            backgroundWorkerLoadImage.DoWork += backgroundWorkerLoadImage_DoWork;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1184, 761);
            Controls.Add(labelVersion);
            Controls.Add(buttonAddCard);
            Controls.Add(treeViewCards);
            Controls.Add(cardDisplay);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Home";
            Text = "ExLa Card Viewer";
            cardDisplay.ResumeLayout(false);
            tabPortrait.ResumeLayout(false);
            panelPortrait.ResumeLayout(false);
            panelPortrait.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRarityPortrait).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPortrait).EndInit();
            tabAbility.ResumeLayout(false);
            panelAbility.ResumeLayout(false);
            panelAbility.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRarityAbility).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAbility).EndInit();
            tabLore.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRarityLore).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLore).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TreeView treeViewCards;
        private TabControl cardDisplay;
        private TabPage tabAbility;
        private TabPage tabPortrait;
        private TabPage tabLore;
        private Button buttonAddCard;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSaveData;
        private PictureBox pictureBoxPortrait;
        private Label labelSeriesPortrait;
        private Label labelNamePortrait;
        private Button buttonDeletePortrait;
        private Button buttonEditPortrait;
        private Button buttonFavoritePortrait;
        private Button buttonDeleteAbility;
        private Button buttonEditAbility;
        private Button buttonFavoriteAbility;
        private Label labelSeriesAbility;
        private Label labelNameAbility;
        private PictureBox pictureBoxAbility;
        private Button buttonDeleteLore;
        private Button buttonEditLore;
        private Button buttonFavoriteLore;
        private Label labelSeriesLore;
        private Label labelNameLore;
        private PictureBox pictureBoxLore;
        private Label labelDetail2;
        private Label labelDetail2Name;
        private Label labelDetail1;
        private Label labelDetail1Name;
        private Label labelPortraitTitle;
        private Label labelAbility;
        private Label labelAbilityName;
        private Label labelStory2;
        private Label labelStory1;
        private Label labelStory1Title;
        private Label labelStory2Title;
        private Label labelQuote;
        private Panel panelAbility;
        private Panel panelPortrait;
        private PictureBox pictureBoxRarityPortrait;
        private PictureBox pictureBoxRarityAbility;
        private PictureBox pictureBoxRarityLore;
        private Panel panel1;
        private Label labelPortraitAnim;
        private Label labelAbilityAnim;
        private Label labelLoreAnim;
        private Label labelVersion;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLoadImage;
    }
}
