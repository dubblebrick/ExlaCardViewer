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
            pictureBoxCard = new PictureBox();
            panelCardDetails = new Panel();
            panelCardText = new Panel();
            labelSeries = new Label();
            labelQuote = new Label();
            labelBody2 = new Label();
            labelHeader2 = new Label();
            labelBody1 = new Label();
            labelHeader1 = new Label();
            panelLoreDetails = new Panel();
            labelDetail2 = new Label();
            labelDetail1 = new Label();
            labelDetail2Name = new Label();
            labelDetail1Name = new Label();
            panelCardButtons = new Panel();
            labelAnimAvailable = new Label();
            buttonExport = new Button();
            buttonDelete = new Button();
            buttonEdit = new Button();
            buttonFavorite = new Button();
            pictureBoxRarity = new PictureBox();
            panelName = new Panel();
            labelCharName = new Label();
            buttonAddCard = new Button();
            labelVersion = new Label();
            buttonImportCard = new Button();
            openFileImportCard = new OpenFileDialog();
            saveFileExportCard = new SaveFileDialog();
            panelSidebar = new Panel();
            panelCardDisplay = new Panel();
            panelButtons = new Panel();
            buttonLore = new Button();
            buttonAbility = new Button();
            buttonPortrait = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCard).BeginInit();
            panelCardDetails.SuspendLayout();
            panelCardText.SuspendLayout();
            panelLoreDetails.SuspendLayout();
            panelCardButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRarity).BeginInit();
            panelName.SuspendLayout();
            panelSidebar.SuspendLayout();
            panelCardDisplay.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // treeViewCards
            // 
            treeViewCards.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            treeViewCards.Location = new Point(28, 26);
            treeViewCards.Margin = new Padding(6);
            treeViewCards.Name = "treeViewCards";
            treeNode1.Name = "nodeStandardCards";
            treeNode1.Text = "Standard Cards";
            treeNode2.Name = "nodeMythicCards";
            treeNode2.Text = "Mythic Cards";
            treeNode3.Name = "nodeFavoriteCards";
            treeNode3.Text = "Favorites";
            treeViewCards.Nodes.AddRange(new TreeNode[] { treeNode1, treeNode2, treeNode3 });
            treeViewCards.Size = new Size(387, 1329);
            treeViewCards.TabIndex = 1;
            treeViewCards.AfterSelect += treeViewCards_AfterSelect;
            treeViewCards.KeyPress += KeyPressEvent;
            // 
            // pictureBoxCard
            // 
            pictureBoxCard.Dock = DockStyle.Fill;
            pictureBoxCard.Location = new Point(19, 21);
            pictureBoxCard.Margin = new Padding(6);
            pictureBoxCard.Name = "pictureBoxCard";
            pictureBoxCard.Size = new Size(896, 1410);
            pictureBoxCard.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxCard.TabIndex = 0;
            pictureBoxCard.TabStop = false;
            // 
            // panelCardDetails
            // 
            panelCardDetails.Controls.Add(panelCardText);
            panelCardDetails.Controls.Add(panelCardButtons);
            panelCardDetails.Controls.Add(pictureBoxRarity);
            panelCardDetails.Controls.Add(panelName);
            panelCardDetails.Dock = DockStyle.Right;
            panelCardDetails.Location = new Point(915, 21);
            panelCardDetails.Margin = new Padding(6);
            panelCardDetails.Name = "panelCardDetails";
            panelCardDetails.Size = new Size(819, 1410);
            panelCardDetails.TabIndex = 8;
            // 
            // panelCardText
            // 
            panelCardText.AutoScroll = true;
            panelCardText.BackColor = Color.WhiteSmoke;
            panelCardText.BorderStyle = BorderStyle.Fixed3D;
            panelCardText.Controls.Add(labelSeries);
            panelCardText.Controls.Add(labelQuote);
            panelCardText.Controls.Add(labelBody2);
            panelCardText.Controls.Add(labelHeader2);
            panelCardText.Controls.Add(labelBody1);
            panelCardText.Controls.Add(labelHeader1);
            panelCardText.Controls.Add(panelLoreDetails);
            panelCardText.Dock = DockStyle.Fill;
            panelCardText.Location = new Point(0, 298);
            panelCardText.Margin = new Padding(6);
            panelCardText.Name = "panelCardText";
            panelCardText.Size = new Size(819, 877);
            panelCardText.TabIndex = 23;
            // 
            // labelSeries
            // 
            labelSeries.Dock = DockStyle.Bottom;
            labelSeries.Location = new Point(0, 756);
            labelSeries.Margin = new Padding(6, 0, 6, 0);
            labelSeries.Name = "labelSeries";
            labelSeries.Padding = new Padding(37, 43, 37, 43);
            labelSeries.Size = new Size(815, 117);
            labelSeries.TabIndex = 2;
            labelSeries.Text = "series";
            labelSeries.TextAlign = ContentAlignment.TopRight;
            // 
            // labelQuote
            // 
            labelQuote.AutoSize = true;
            labelQuote.Dock = DockStyle.Top;
            labelQuote.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelQuote.Location = new Point(0, 362);
            labelQuote.Margin = new Padding(6, 0, 6, 0);
            labelQuote.MaximumSize = new Size(812, 0);
            labelQuote.Name = "labelQuote";
            labelQuote.Padding = new Padding(37, 43, 37, 0);
            labelQuote.Size = new Size(147, 75);
            labelQuote.TabIndex = 12;
            labelQuote.Text = "quote";
            // 
            // labelBody2
            // 
            labelBody2.AutoSize = true;
            labelBody2.Dock = DockStyle.Top;
            labelBody2.Location = new Point(0, 330);
            labelBody2.Margin = new Padding(6, 0, 6, 0);
            labelBody2.MaximumSize = new Size(812, 0);
            labelBody2.Name = "labelBody2";
            labelBody2.Padding = new Padding(37, 0, 37, 0);
            labelBody2.Size = new Size(162, 32);
            labelBody2.TabIndex = 11;
            labelBody2.Text = "body 2";
            // 
            // labelHeader2
            // 
            labelHeader2.AutoSize = true;
            labelHeader2.Dock = DockStyle.Top;
            labelHeader2.Font = new Font("Press Start 2P", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelHeader2.Location = new Point(0, 243);
            labelHeader2.Margin = new Padding(6, 23, 6, 0);
            labelHeader2.MaximumSize = new Size(812, 213);
            labelHeader2.MinimumSize = new Size(812, 0);
            labelHeader2.Name = "labelHeader2";
            labelHeader2.Padding = new Padding(0, 43, 0, 0);
            labelHeader2.Size = new Size(812, 87);
            labelHeader2.TabIndex = 13;
            labelHeader2.Text = "header 2";
            labelHeader2.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelBody1
            // 
            labelBody1.AutoSize = true;
            labelBody1.Dock = DockStyle.Top;
            labelBody1.Location = new Point(0, 211);
            labelBody1.Margin = new Padding(6, 0, 6, 0);
            labelBody1.MaximumSize = new Size(812, 0);
            labelBody1.Name = "labelBody1";
            labelBody1.Padding = new Padding(37, 0, 37, 0);
            labelBody1.Size = new Size(162, 32);
            labelBody1.TabIndex = 9;
            labelBody1.Text = "body 1";
            // 
            // labelHeader1
            // 
            labelHeader1.AutoSize = true;
            labelHeader1.Dock = DockStyle.Top;
            labelHeader1.Font = new Font("Press Start 2P", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelHeader1.Location = new Point(0, 124);
            labelHeader1.Margin = new Padding(6, 23, 6, 0);
            labelHeader1.MaximumSize = new Size(812, 213);
            labelHeader1.MinimumSize = new Size(812, 0);
            labelHeader1.Name = "labelHeader1";
            labelHeader1.Padding = new Padding(0, 43, 0, 0);
            labelHeader1.Size = new Size(812, 87);
            labelHeader1.TabIndex = 7;
            labelHeader1.Text = "header 1";
            labelHeader1.TextAlign = ContentAlignment.TopCenter;
            // 
            // panelLoreDetails
            // 
            panelLoreDetails.Controls.Add(labelDetail2);
            panelLoreDetails.Controls.Add(labelDetail1);
            panelLoreDetails.Controls.Add(labelDetail2Name);
            panelLoreDetails.Controls.Add(labelDetail1Name);
            panelLoreDetails.Dock = DockStyle.Top;
            panelLoreDetails.Location = new Point(0, 0);
            panelLoreDetails.Margin = new Padding(6);
            panelLoreDetails.Name = "panelLoreDetails";
            panelLoreDetails.Size = new Size(815, 124);
            panelLoreDetails.TabIndex = 8;
            // 
            // labelDetail2
            // 
            labelDetail2.Location = new Point(412, 87);
            labelDetail2.Margin = new Padding(6, 0, 6, 0);
            labelDetail2.Name = "labelDetail2";
            labelDetail2.Size = new Size(403, 36);
            labelDetail2.TabIndex = 3;
            labelDetail2.Text = "lore 2";
            labelDetail2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelDetail1
            // 
            labelDetail1.Location = new Point(-2, 87);
            labelDetail1.Margin = new Padding(6, 0, 6, 0);
            labelDetail1.Name = "labelDetail1";
            labelDetail1.Size = new Size(401, 36);
            labelDetail1.TabIndex = 2;
            labelDetail1.Text = "lore 1";
            labelDetail1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelDetail2Name
            // 
            labelDetail2Name.Font = new Font("Press Start 2P", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDetail2Name.Location = new Point(412, -4);
            labelDetail2Name.Margin = new Padding(6, 0, 6, 0);
            labelDetail2Name.Name = "labelDetail2Name";
            labelDetail2Name.Padding = new Padding(0, 43, 0, 0);
            labelDetail2Name.Size = new Size(403, 85);
            labelDetail2Name.TabIndex = 1;
            labelDetail2Name.Text = "lore 2";
            labelDetail2Name.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelDetail1Name
            // 
            labelDetail1Name.Font = new Font("Press Start 2P", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDetail1Name.Location = new Point(-4, -4);
            labelDetail1Name.Margin = new Padding(6, 0, 6, 0);
            labelDetail1Name.Name = "labelDetail1Name";
            labelDetail1Name.Padding = new Padding(0, 43, 0, 0);
            labelDetail1Name.Size = new Size(403, 87);
            labelDetail1Name.TabIndex = 0;
            labelDetail1Name.Text = "lore 1";
            labelDetail1Name.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelCardButtons
            // 
            panelCardButtons.Controls.Add(labelAnimAvailable);
            panelCardButtons.Controls.Add(buttonExport);
            panelCardButtons.Controls.Add(buttonDelete);
            panelCardButtons.Controls.Add(buttonEdit);
            panelCardButtons.Controls.Add(buttonFavorite);
            panelCardButtons.Dock = DockStyle.Bottom;
            panelCardButtons.Location = new Point(0, 1175);
            panelCardButtons.Margin = new Padding(6, 43, 6, 6);
            panelCardButtons.Name = "panelCardButtons";
            panelCardButtons.Size = new Size(819, 235);
            panelCardButtons.TabIndex = 25;
            // 
            // labelAnimAvailable
            // 
            labelAnimAvailable.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelAnimAvailable.AutoSize = true;
            labelAnimAvailable.ForeColor = SystemColors.ControlDark;
            labelAnimAvailable.Location = new Point(0, 6);
            labelAnimAvailable.Margin = new Padding(6);
            labelAnimAvailable.Name = "labelAnimAvailable";
            labelAnimAvailable.Size = new Size(628, 32);
            labelAnimAvailable.TabIndex = 21;
            labelAnimAvailable.Text = "Animated card available! Press space to toggle animation.";
            // 
            // buttonExport
            // 
            buttonExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonExport.BackColor = Color.FromArgb(68, 68, 68);
            buttonExport.FlatAppearance.BorderColor = Color.White;
            buttonExport.FlatAppearance.BorderSize = 2;
            buttonExport.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 42, 109);
            buttonExport.FlatStyle = FlatStyle.Flat;
            buttonExport.Font = new Font("Press Start 2P", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonExport.ForeColor = Color.White;
            buttonExport.Location = new Point(0, 145);
            buttonExport.Margin = new Padding(6);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(403, 81);
            buttonExport.TabIndex = 22;
            buttonExport.Text = "EXPORT CARD";
            buttonExport.UseVisualStyleBackColor = false;
            buttonExport.Click += exportCard_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonDelete.BackColor = Color.FromArgb(68, 68, 68);
            buttonDelete.FlatAppearance.BorderColor = Color.White;
            buttonDelete.FlatAppearance.BorderSize = 2;
            buttonDelete.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 42, 109);
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("Press Start 2P", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(416, 51);
            buttonDelete.Margin = new Padding(6, 6, 11, 6);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(403, 81);
            buttonDelete.TabIndex = 6;
            buttonDelete.Text = "DELETE CARD";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonEdit.BackColor = Color.FromArgb(68, 68, 68);
            buttonEdit.FlatAppearance.BorderColor = Color.White;
            buttonEdit.FlatAppearance.BorderSize = 2;
            buttonEdit.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 42, 109);
            buttonEdit.FlatStyle = FlatStyle.Flat;
            buttonEdit.Font = new Font("Press Start 2P", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonEdit.ForeColor = Color.White;
            buttonEdit.Location = new Point(416, 145);
            buttonEdit.Margin = new Padding(11, 6, 6, 6);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(403, 81);
            buttonEdit.TabIndex = 5;
            buttonEdit.Text = "EDIT CARD";
            buttonEdit.UseVisualStyleBackColor = false;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonFavorite
            // 
            buttonFavorite.BackColor = Color.FromArgb(68, 68, 68);
            buttonFavorite.FlatAppearance.BorderColor = Color.White;
            buttonFavorite.FlatAppearance.BorderSize = 2;
            buttonFavorite.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 42, 109);
            buttonFavorite.FlatStyle = FlatStyle.Flat;
            buttonFavorite.Font = new Font("Press Start 2P", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonFavorite.ForeColor = Color.White;
            buttonFavorite.Location = new Point(0, 51);
            buttonFavorite.Margin = new Padding(6);
            buttonFavorite.Name = "buttonFavorite";
            buttonFavorite.Size = new Size(403, 81);
            buttonFavorite.TabIndex = 4;
            buttonFavorite.Text = "REMOVE FAVORITE";
            buttonFavorite.UseVisualStyleBackColor = false;
            buttonFavorite.Click += buttonFavorite_Click;
            // 
            // pictureBoxRarity
            // 
            pictureBoxRarity.Dock = DockStyle.Top;
            pictureBoxRarity.InitialImage = Properties.Resources.rarityStar_Rare;
            pictureBoxRarity.Location = new Point(0, 213);
            pictureBoxRarity.Margin = new Padding(6);
            pictureBoxRarity.Name = "pictureBoxRarity";
            pictureBoxRarity.Padding = new Padding(0, 40, 0, 40);
            pictureBoxRarity.Size = new Size(819, 85);
            pictureBoxRarity.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxRarity.TabIndex = 20;
            pictureBoxRarity.TabStop = false;
            // 
            // panelName
            // 
            panelName.BackgroundImage = Properties.Resources.scroll;
            panelName.BackgroundImageLayout = ImageLayout.Zoom;
            panelName.Controls.Add(labelCharName);
            panelName.Dock = DockStyle.Top;
            panelName.Location = new Point(0, 0);
            panelName.Margin = new Padding(6, 6, 6, 43);
            panelName.Name = "panelName";
            panelName.Size = new Size(819, 213);
            panelName.TabIndex = 24;
            // 
            // labelCharName
            // 
            labelCharName.Dock = DockStyle.Fill;
            labelCharName.Font = new Font("Press Start 2P", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCharName.Location = new Point(0, 0);
            labelCharName.Margin = new Padding(6, 0, 6, 0);
            labelCharName.Name = "labelCharName";
            labelCharName.Padding = new Padding(0, 32, 0, 0);
            labelCharName.Size = new Size(819, 213);
            labelCharName.TabIndex = 1;
            labelCharName.Text = "name";
            labelCharName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonAddCard
            // 
            buttonAddCard.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAddCard.BackColor = Color.FromArgb(68, 68, 68);
            buttonAddCard.FlatAppearance.BorderColor = Color.White;
            buttonAddCard.FlatAppearance.BorderSize = 2;
            buttonAddCard.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 42, 109);
            buttonAddCard.FlatStyle = FlatStyle.Flat;
            buttonAddCard.Font = new Font("Press Start 2P", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonAddCard.ForeColor = Color.White;
            buttonAddCard.Location = new Point(28, 1372);
            buttonAddCard.Margin = new Padding(6);
            buttonAddCard.Name = "buttonAddCard";
            buttonAddCard.Padding = new Padding(0, 11, 0, 0);
            buttonAddCard.Size = new Size(390, 81);
            buttonAddCard.TabIndex = 5;
            buttonAddCard.Text = "ADD CARD";
            buttonAddCard.UseVisualStyleBackColor = false;
            buttonAddCard.Click += buttonAddCard_Click;
            // 
            // labelVersion
            // 
            labelVersion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelVersion.AutoSize = true;
            labelVersion.BackColor = Color.Transparent;
            labelVersion.Font = new Font("Press Start 2P", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelVersion.ForeColor = SystemColors.Control;
            labelVersion.Location = new Point(28, 1553);
            labelVersion.Margin = new Padding(6, 0, 6, 0);
            labelVersion.Name = "labelVersion";
            labelVersion.Padding = new Padding(2, 21, 2, 2);
            labelVersion.Size = new Size(91, 56);
            labelVersion.TabIndex = 6;
            labelVersion.Text = "ver";
            // 
            // buttonImportCard
            // 
            buttonImportCard.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonImportCard.BackColor = Color.FromArgb(68, 68, 68);
            buttonImportCard.FlatAppearance.BorderColor = Color.White;
            buttonImportCard.FlatAppearance.BorderSize = 2;
            buttonImportCard.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 42, 109);
            buttonImportCard.FlatStyle = FlatStyle.Flat;
            buttonImportCard.Font = new Font("Press Start 2P", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonImportCard.ForeColor = Color.White;
            buttonImportCard.Location = new Point(28, 1466);
            buttonImportCard.Margin = new Padding(6);
            buttonImportCard.Name = "buttonImportCard";
            buttonImportCard.Padding = new Padding(0, 11, 0, 0);
            buttonImportCard.Size = new Size(390, 81);
            buttonImportCard.TabIndex = 7;
            buttonImportCard.Text = "IMPORT CARD";
            buttonImportCard.UseVisualStyleBackColor = false;
            buttonImportCard.Click += buttonImportCard_Click;
            // 
            // openFileImportCard
            // 
            openFileImportCard.InitialDirectory = "%userhome%";
            // 
            // saveFileExportCard
            // 
            saveFileExportCard.DefaultExt = "json";
            saveFileExportCard.Filter = "JSON files|*.json";
            saveFileExportCard.InitialDirectory = "%userhome%";
            saveFileExportCard.Title = "Export Card";
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.Transparent;
            panelSidebar.Controls.Add(treeViewCards);
            panelSidebar.Controls.Add(labelVersion);
            panelSidebar.Controls.Add(buttonImportCard);
            panelSidebar.Controls.Add(buttonAddCard);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Margin = new Padding(6);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(446, 1623);
            panelSidebar.TabIndex = 8;
            // 
            // panelCardDisplay
            // 
            panelCardDisplay.BackColor = Color.Transparent;
            panelCardDisplay.Controls.Add(pictureBoxCard);
            panelCardDisplay.Controls.Add(panelCardDetails);
            panelCardDisplay.Dock = DockStyle.Fill;
            panelCardDisplay.Location = new Point(446, 171);
            panelCardDisplay.Margin = new Padding(6);
            panelCardDisplay.Name = "panelCardDisplay";
            panelCardDisplay.Padding = new Padding(19, 21, 19, 21);
            panelCardDisplay.Size = new Size(1753, 1452);
            panelCardDisplay.TabIndex = 8;
            panelCardDisplay.Visible = false;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.Transparent;
            panelButtons.Controls.Add(buttonLore);
            panelButtons.Controls.Add(buttonAbility);
            panelButtons.Controls.Add(buttonPortrait);
            panelButtons.Dock = DockStyle.Top;
            panelButtons.Location = new Point(446, 0);
            panelButtons.Margin = new Padding(6);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1753, 171);
            panelButtons.TabIndex = 9;
            // 
            // buttonLore
            // 
            buttonLore.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonLore.BackColor = Color.FromArgb(68, 68, 68);
            buttonLore.FlatAppearance.BorderColor = Color.White;
            buttonLore.FlatAppearance.BorderSize = 3;
            buttonLore.FlatStyle = FlatStyle.Flat;
            buttonLore.Font = new Font("Press Start 2P", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonLore.ForeColor = Color.White;
            buttonLore.Location = new Point(1189, 26);
            buttonLore.Margin = new Padding(19, 6, 19, 6);
            buttonLore.Name = "buttonLore";
            buttonLore.Padding = new Padding(0, 11, 0, 0);
            buttonLore.Size = new Size(546, 109);
            buttonLore.TabIndex = 2;
            buttonLore.Text = "LORE CARD";
            buttonLore.UseVisualStyleBackColor = false;
            buttonLore.Click += buttonLore_Click;
            // 
            // buttonAbility
            // 
            buttonAbility.Anchor = AnchorStyles.Top;
            buttonAbility.BackColor = Color.FromArgb(68, 68, 68);
            buttonAbility.FlatAppearance.BorderColor = Color.White;
            buttonAbility.FlatAppearance.BorderSize = 3;
            buttonAbility.FlatStyle = FlatStyle.Flat;
            buttonAbility.Font = new Font("Press Start 2P", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonAbility.ForeColor = Color.White;
            buttonAbility.Location = new Point(607, 26);
            buttonAbility.Margin = new Padding(19, 6, 19, 6);
            buttonAbility.Name = "buttonAbility";
            buttonAbility.Padding = new Padding(0, 11, 0, 0);
            buttonAbility.Size = new Size(546, 109);
            buttonAbility.TabIndex = 1;
            buttonAbility.Text = "ABILITY CARD";
            buttonAbility.UseVisualStyleBackColor = false;
            buttonAbility.Click += buttonAbility_Click;
            // 
            // buttonPortrait
            // 
            buttonPortrait.BackColor = Color.FromArgb(68, 68, 68);
            buttonPortrait.FlatAppearance.BorderColor = Color.White;
            buttonPortrait.FlatAppearance.BorderSize = 3;
            buttonPortrait.FlatStyle = FlatStyle.Flat;
            buttonPortrait.Font = new Font("Press Start 2P", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonPortrait.ForeColor = Color.White;
            buttonPortrait.Location = new Point(24, 26);
            buttonPortrait.Margin = new Padding(19, 6, 19, 6);
            buttonPortrait.Name = "buttonPortrait";
            buttonPortrait.Padding = new Padding(0, 11, 0, 0);
            buttonPortrait.Size = new Size(546, 109);
            buttonPortrait.TabIndex = 0;
            buttonPortrait.Text = "PORTRAIT CARD";
            buttonPortrait.UseVisualStyleBackColor = false;
            buttonPortrait.Click += buttonPortrait_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = Properties.Resources.stoneDungeon;
            ClientSize = new Size(2199, 1623);
            Controls.Add(panelCardDisplay);
            Controls.Add(panelButtons);
            Controls.Add(panelSidebar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(6);
            Name = "Home";
            Text = "ExLa Card Viewer";
            Load += Home_Load;
            KeyPress += KeyPressEvent;
            ((System.ComponentModel.ISupportInitialize)pictureBoxCard).EndInit();
            panelCardDetails.ResumeLayout(false);
            panelCardText.ResumeLayout(false);
            panelCardText.PerformLayout();
            panelLoreDetails.ResumeLayout(false);
            panelCardButtons.ResumeLayout(false);
            panelCardButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRarity).EndInit();
            panelName.ResumeLayout(false);
            panelSidebar.ResumeLayout(false);
            panelSidebar.PerformLayout();
            panelCardDisplay.ResumeLayout(false);
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TreeView treeViewCards;
        private Button buttonAddCard;
        private PictureBox pictureBoxCard;
        private Label labelSeries;
        private Label labelCharName;
        private Button buttonDelete;
        private Button buttonEdit;
        private Button buttonFavorite;
        private Label labelDetail1;
        private Label labelDetail2Name;
        private Label labelHeader1;
        private PictureBox pictureBoxRarity;
        private Label labelAnimAvailable;
        private Label labelVersion;
        private Button buttonImportCard;
        private Button buttonExport;
        private OpenFileDialog openFileImportCard;
        private SaveFileDialog saveFileExportCard;
        private Panel panelSidebar;
        private Panel panelCardDisplay;
        private Panel panelCardDetails;
        private Panel panelButtons;
        private Button buttonLore;
        private Button buttonAbility;
        private Button buttonPortrait;
        private Panel panelCardText;
        private Panel panelLoreDetails;
        private Label labelDetail2;
        private Label labelDetail1Name;
        private Label labelQuote;
        private Label labelBody2;
        private Label labelHeader2;
        private Label labelBody1;
        private Panel panelName;
        private Panel panelCardButtons;
    }
}
