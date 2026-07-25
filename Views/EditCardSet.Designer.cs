namespace CardViewer.Views
{
    partial class EditCardSet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCardSet));
            tabControl1 = new TabControl();
            tabDetails = new TabPage();
            pictureBoxRarity = new PictureBox();
            labelRarityName = new Label();
            labelRarity = new Label();
            labelRequired1 = new Label();
            labelSeries = new Label();
            inputCharSeries = new TextBox();
            labelNumber = new Label();
            labelName = new Label();
            buttonRarityDown = new Button();
            buttonRarityUp = new Button();
            inputCharName = new TextBox();
            inputCharNum = new NumericUpDown();
            tabPortrait = new TabPage();
            buttonRemovePortraitAnim = new Button();
            labelPortraitAnimName = new Label();
            labelPortraitImageName = new Label();
            labelRequired2 = new Label();
            labelPortraitAnim = new Label();
            labelTitle = new Label();
            labelPortraitImage = new Label();
            inputPortraitTitle = new TextBox();
            buttonUploadPortraitAnim = new Button();
            buttonUploadPortrait = new Button();
            tabAbility = new TabPage();
            buttonRemoveAbilityAnim = new Button();
            labelAbilityAnimName = new Label();
            labelAbilityImageName = new Label();
            labelAbilityAnim = new Label();
            labelAbilityImage = new Label();
            buttonUploadAbilityAnim = new Button();
            buttonUploadAbility = new Button();
            labelAbilityDesc = new Label();
            labelAbilityName = new Label();
            inputAbilityDesc = new TextBox();
            inputAbilityName = new TextBox();
            label9 = new Label();
            tabLore = new TabPage();
            buttonRemoveLoreAnim = new Button();
            label2 = new Label();
            label1 = new Label();
            labelLoreAnimName = new Label();
            labelLoreImageName = new Label();
            labelLoreAnim = new Label();
            labelLoreImage = new Label();
            buttonUploadLoreAnim = new Button();
            buttonUploadLore = new Button();
            labelRequired4 = new Label();
            labelDetail2 = new Label();
            labelDetail1 = new Label();
            labelQuote = new Label();
            labelStory2 = new Label();
            labelStory1 = new Label();
            inputQuote = new TextBox();
            inputStory2 = new TextBox();
            inputStory2Title = new TextBox();
            inputStory1 = new TextBox();
            inputStory1Title = new TextBox();
            inputDetail2 = new TextBox();
            inputDetail2Name = new TextBox();
            inputDetail1 = new TextBox();
            inputDetail1Name = new TextBox();
            buttonCancel = new Button();
            buttonFinish = new Button();
            openFileDialogPng = new OpenFileDialog();
            openFileDialogGif = new OpenFileDialog();
            tabControl1.SuspendLayout();
            tabDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRarity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inputCharNum).BeginInit();
            tabPortrait.SuspendLayout();
            tabAbility.SuspendLayout();
            tabLore.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabDetails);
            tabControl1.Controls.Add(tabPortrait);
            tabControl1.Controls.Add(tabAbility);
            tabControl1.Controls.Add(tabLore);
            tabControl1.Dock = DockStyle.Top;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(498, 374);
            tabControl1.TabIndex = 0;
            // 
            // tabDetails
            // 
            tabDetails.Controls.Add(pictureBoxRarity);
            tabDetails.Controls.Add(labelRarityName);
            tabDetails.Controls.Add(labelRarity);
            tabDetails.Controls.Add(labelRequired1);
            tabDetails.Controls.Add(labelSeries);
            tabDetails.Controls.Add(inputCharSeries);
            tabDetails.Controls.Add(labelNumber);
            tabDetails.Controls.Add(labelName);
            tabDetails.Controls.Add(buttonRarityDown);
            tabDetails.Controls.Add(buttonRarityUp);
            tabDetails.Controls.Add(inputCharName);
            tabDetails.Controls.Add(inputCharNum);
            tabDetails.Location = new Point(4, 24);
            tabDetails.Name = "tabDetails";
            tabDetails.Padding = new Padding(3);
            tabDetails.Size = new Size(490, 346);
            tabDetails.TabIndex = 0;
            tabDetails.Text = "Details";
            tabDetails.UseVisualStyleBackColor = true;
            // 
            // pictureBoxRarity
            // 
            pictureBoxRarity.InitialImage = Properties.Resources.rarityStar_Rare;
            pictureBoxRarity.Location = new Point(46, 73);
            pictureBoxRarity.Name = "pictureBoxRarity";
            pictureBoxRarity.Size = new Size(150, 25);
            pictureBoxRarity.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxRarity.TabIndex = 19;
            pictureBoxRarity.TabStop = false;
            // 
            // labelRarityName
            // 
            labelRarityName.Location = new Point(46, 129);
            labelRarityName.Name = "labelRarityName";
            labelRarityName.Size = new Size(150, 15);
            labelRarityName.TabIndex = 18;
            labelRarityName.Text = "Rare";
            labelRarityName.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelRarity
            // 
            labelRarity.Location = new Point(46, 26);
            labelRarity.Name = "labelRarity";
            labelRarity.Size = new Size(150, 15);
            labelRarity.TabIndex = 16;
            labelRarity.Text = "Rarity*";
            labelRarity.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelRequired1
            // 
            labelRequired1.AutoSize = true;
            labelRequired1.Location = new Point(342, 328);
            labelRequired1.Name = "labelRequired1";
            labelRequired1.Size = new Size(96, 15);
            labelRequired1.TabIndex = 15;
            labelRequired1.Text = "* = required field";
            // 
            // labelSeries
            // 
            labelSeries.AutoSize = true;
            labelSeries.Location = new Point(252, 83);
            labelSeries.Name = "labelSeries";
            labelSeries.Size = new Size(37, 15);
            labelSeries.TabIndex = 10;
            labelSeries.Text = "Series";
            // 
            // inputCharSeries
            // 
            inputCharSeries.Location = new Point(252, 101);
            inputCharSeries.Name = "inputCharSeries";
            inputCharSeries.Size = new Size(134, 23);
            inputCharSeries.TabIndex = 12;
            inputCharSeries.TextChanged += TextboxUpdatedEvent;
            // 
            // labelNumber
            // 
            labelNumber.AutoSize = true;
            labelNumber.Location = new Point(252, 134);
            labelNumber.Name = "labelNumber";
            labelNumber.Size = new Size(102, 15);
            labelNumber.TabIndex = 7;
            labelNumber.Text = "Collector Number";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(252, 26);
            labelName.Name = "labelName";
            labelName.Size = new Size(39, 15);
            labelName.TabIndex = 4;
            labelName.Text = "Name";
            // 
            // buttonRarityDown
            // 
            buttonRarityDown.Location = new Point(110, 105);
            buttonRarityDown.Name = "buttonRarityDown";
            buttonRarityDown.Size = new Size(23, 21);
            buttonRarityDown.TabIndex = 2;
            buttonRarityDown.Text = "⏷";
            buttonRarityDown.UseVisualStyleBackColor = true;
            buttonRarityDown.Click += buttonRarityDown_Click;
            // 
            // buttonRarityUp
            // 
            buttonRarityUp.Location = new Point(110, 45);
            buttonRarityUp.Name = "buttonRarityUp";
            buttonRarityUp.Size = new Size(23, 22);
            buttonRarityUp.TabIndex = 1;
            buttonRarityUp.Text = "⏶";
            buttonRarityUp.UseVisualStyleBackColor = true;
            buttonRarityUp.Click += buttonRarityUp_Click;
            // 
            // inputCharName
            // 
            inputCharName.Location = new Point(252, 44);
            inputCharName.Name = "inputCharName";
            inputCharName.Size = new Size(134, 23);
            inputCharName.TabIndex = 6;
            inputCharName.TextChanged += TextboxUpdatedEvent;
            // 
            // inputCharNum
            // 
            inputCharNum.Location = new Point(252, 152);
            inputCharNum.Name = "inputCharNum";
            inputCharNum.Size = new Size(134, 23);
            inputCharNum.TabIndex = 14;
            inputCharNum.ValueChanged += inputCharNum_ValueChanged;
            // 
            // tabPortrait
            // 
            tabPortrait.Controls.Add(buttonRemovePortraitAnim);
            tabPortrait.Controls.Add(labelPortraitAnimName);
            tabPortrait.Controls.Add(labelPortraitImageName);
            tabPortrait.Controls.Add(labelRequired2);
            tabPortrait.Controls.Add(labelPortraitAnim);
            tabPortrait.Controls.Add(labelTitle);
            tabPortrait.Controls.Add(labelPortraitImage);
            tabPortrait.Controls.Add(inputPortraitTitle);
            tabPortrait.Controls.Add(buttonUploadPortraitAnim);
            tabPortrait.Controls.Add(buttonUploadPortrait);
            tabPortrait.Location = new Point(4, 24);
            tabPortrait.Name = "tabPortrait";
            tabPortrait.Padding = new Padding(3);
            tabPortrait.Size = new Size(490, 346);
            tabPortrait.TabIndex = 1;
            tabPortrait.Text = "Portrait Card";
            tabPortrait.UseVisualStyleBackColor = true;
            // 
            // buttonRemovePortraitAnim
            // 
            buttonRemovePortraitAnim.Location = new Point(108, 317);
            buttonRemovePortraitAnim.Name = "buttonRemovePortraitAnim";
            buttonRemovePortraitAnim.Size = new Size(21, 23);
            buttonRemovePortraitAnim.TabIndex = 19;
            buttonRemovePortraitAnim.Text = "x";
            buttonRemovePortraitAnim.UseVisualStyleBackColor = true;
            buttonRemovePortraitAnim.Click += buttonRemovePortraitAnim_Click;
            // 
            // labelPortraitAnimName
            // 
            labelPortraitAnimName.AutoSize = true;
            labelPortraitAnimName.Location = new Point(135, 321);
            labelPortraitAnimName.Name = "labelPortraitAnimName";
            labelPortraitAnimName.Size = new Size(12, 15);
            labelPortraitAnimName.TabIndex = 18;
            labelPortraitAnimName.Text = "?";
            // 
            // labelPortraitImageName
            // 
            labelPortraitImageName.AutoSize = true;
            labelPortraitImageName.Location = new Point(108, 276);
            labelPortraitImageName.Name = "labelPortraitImageName";
            labelPortraitImageName.Size = new Size(12, 15);
            labelPortraitImageName.TabIndex = 17;
            labelPortraitImageName.Text = "?";
            // 
            // labelRequired2
            // 
            labelRequired2.AutoSize = true;
            labelRequired2.Location = new Point(342, 328);
            labelRequired2.Name = "labelRequired2";
            labelRequired2.Size = new Size(96, 15);
            labelRequired2.TabIndex = 16;
            labelRequired2.Text = "* = required field";
            // 
            // labelPortraitAnim
            // 
            labelPortraitAnim.AutoSize = true;
            labelPortraitAnim.Location = new Point(6, 299);
            labelPortraitAnim.Name = "labelPortraitAnim";
            labelPortraitAnim.Size = new Size(89, 15);
            labelPortraitAnim.TabIndex = 6;
            labelPortraitAnim.Text = "Card animation";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(25, 13);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(35, 15);
            labelTitle.TabIndex = 5;
            labelTitle.Text = "Title*";
            // 
            // labelPortraitImage
            // 
            labelPortraitImage.AutoSize = true;
            labelPortraitImage.Location = new Point(6, 254);
            labelPortraitImage.Name = "labelPortraitImage";
            labelPortraitImage.Size = new Size(73, 15);
            labelPortraitImage.TabIndex = 4;
            labelPortraitImage.Text = "Card image*";
            // 
            // inputPortraitTitle
            // 
            inputPortraitTitle.Location = new Point(25, 31);
            inputPortraitTitle.Name = "inputPortraitTitle";
            inputPortraitTitle.Size = new Size(186, 23);
            inputPortraitTitle.TabIndex = 3;
            inputPortraitTitle.TextChanged += TextboxUpdatedEvent;
            // 
            // buttonUploadPortraitAnim
            // 
            buttonUploadPortraitAnim.Location = new Point(6, 317);
            buttonUploadPortraitAnim.Name = "buttonUploadPortraitAnim";
            buttonUploadPortraitAnim.Size = new Size(96, 23);
            buttonUploadPortraitAnim.TabIndex = 2;
            buttonUploadPortraitAnim.Text = "Upload File";
            buttonUploadPortraitAnim.UseVisualStyleBackColor = true;
            buttonUploadPortraitAnim.Click += buttonUploadPortraitAnim_Click;
            // 
            // buttonUploadPortrait
            // 
            buttonUploadPortrait.Location = new Point(6, 272);
            buttonUploadPortrait.Name = "buttonUploadPortrait";
            buttonUploadPortrait.Size = new Size(96, 23);
            buttonUploadPortrait.TabIndex = 1;
            buttonUploadPortrait.Text = "Upload File";
            buttonUploadPortrait.UseVisualStyleBackColor = true;
            buttonUploadPortrait.Click += buttonUploadPortrait_Click;
            // 
            // tabAbility
            // 
            tabAbility.Controls.Add(buttonRemoveAbilityAnim);
            tabAbility.Controls.Add(labelAbilityAnimName);
            tabAbility.Controls.Add(labelAbilityImageName);
            tabAbility.Controls.Add(labelAbilityAnim);
            tabAbility.Controls.Add(labelAbilityImage);
            tabAbility.Controls.Add(buttonUploadAbilityAnim);
            tabAbility.Controls.Add(buttonUploadAbility);
            tabAbility.Controls.Add(labelAbilityDesc);
            tabAbility.Controls.Add(labelAbilityName);
            tabAbility.Controls.Add(inputAbilityDesc);
            tabAbility.Controls.Add(inputAbilityName);
            tabAbility.Controls.Add(label9);
            tabAbility.Location = new Point(4, 24);
            tabAbility.Name = "tabAbility";
            tabAbility.Padding = new Padding(3);
            tabAbility.Size = new Size(490, 346);
            tabAbility.TabIndex = 2;
            tabAbility.Text = "Ability Card";
            tabAbility.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveAbilityAnim
            // 
            buttonRemoveAbilityAnim.Location = new Point(108, 317);
            buttonRemoveAbilityAnim.Name = "buttonRemoveAbilityAnim";
            buttonRemoveAbilityAnim.Size = new Size(21, 23);
            buttonRemoveAbilityAnim.TabIndex = 27;
            buttonRemoveAbilityAnim.Text = "x";
            buttonRemoveAbilityAnim.UseVisualStyleBackColor = true;
            buttonRemoveAbilityAnim.Click += buttonRemoveAbilityAnim_Click;
            // 
            // labelAbilityAnimName
            // 
            labelAbilityAnimName.AutoSize = true;
            labelAbilityAnimName.Location = new Point(135, 321);
            labelAbilityAnimName.Name = "labelAbilityAnimName";
            labelAbilityAnimName.Size = new Size(12, 15);
            labelAbilityAnimName.TabIndex = 26;
            labelAbilityAnimName.Text = "?";
            // 
            // labelAbilityImageName
            // 
            labelAbilityImageName.AutoSize = true;
            labelAbilityImageName.Location = new Point(108, 276);
            labelAbilityImageName.Name = "labelAbilityImageName";
            labelAbilityImageName.Size = new Size(12, 15);
            labelAbilityImageName.TabIndex = 25;
            labelAbilityImageName.Text = "?";
            // 
            // labelAbilityAnim
            // 
            labelAbilityAnim.AutoSize = true;
            labelAbilityAnim.Location = new Point(6, 299);
            labelAbilityAnim.Name = "labelAbilityAnim";
            labelAbilityAnim.Size = new Size(89, 15);
            labelAbilityAnim.TabIndex = 24;
            labelAbilityAnim.Text = "Card animation";
            // 
            // labelAbilityImage
            // 
            labelAbilityImage.AutoSize = true;
            labelAbilityImage.Location = new Point(6, 254);
            labelAbilityImage.Name = "labelAbilityImage";
            labelAbilityImage.Size = new Size(73, 15);
            labelAbilityImage.TabIndex = 23;
            labelAbilityImage.Text = "Card image*";
            // 
            // buttonUploadAbilityAnim
            // 
            buttonUploadAbilityAnim.Location = new Point(6, 317);
            buttonUploadAbilityAnim.Name = "buttonUploadAbilityAnim";
            buttonUploadAbilityAnim.Size = new Size(96, 23);
            buttonUploadAbilityAnim.TabIndex = 22;
            buttonUploadAbilityAnim.Text = "Upload File";
            buttonUploadAbilityAnim.UseVisualStyleBackColor = true;
            buttonUploadAbilityAnim.Click += buttonUploadAbilityAnim_Click;
            // 
            // buttonUploadAbility
            // 
            buttonUploadAbility.Location = new Point(6, 272);
            buttonUploadAbility.Name = "buttonUploadAbility";
            buttonUploadAbility.Size = new Size(96, 23);
            buttonUploadAbility.TabIndex = 21;
            buttonUploadAbility.Text = "Upload File";
            buttonUploadAbility.UseVisualStyleBackColor = true;
            buttonUploadAbility.Click += buttonUploadAbility_Click;
            // 
            // labelAbilityDesc
            // 
            labelAbilityDesc.AutoSize = true;
            labelAbilityDesc.Location = new Point(24, 67);
            labelAbilityDesc.Name = "labelAbilityDesc";
            labelAbilityDesc.Size = new Size(108, 15);
            labelAbilityDesc.TabIndex = 20;
            labelAbilityDesc.Text = "Ability description*";
            // 
            // labelAbilityName
            // 
            labelAbilityName.AutoSize = true;
            labelAbilityName.Location = new Point(24, 21);
            labelAbilityName.Name = "labelAbilityName";
            labelAbilityName.Size = new Size(79, 15);
            labelAbilityName.TabIndex = 19;
            labelAbilityName.Text = "Ability name*";
            // 
            // inputAbilityDesc
            // 
            inputAbilityDesc.AcceptsReturn = true;
            inputAbilityDesc.Location = new Point(24, 85);
            inputAbilityDesc.Multiline = true;
            inputAbilityDesc.Name = "inputAbilityDesc";
            inputAbilityDesc.Size = new Size(393, 116);
            inputAbilityDesc.TabIndex = 18;
            inputAbilityDesc.TextChanged += TextboxUpdatedEvent;
            // 
            // inputAbilityName
            // 
            inputAbilityName.Location = new Point(24, 39);
            inputAbilityName.Name = "inputAbilityName";
            inputAbilityName.Size = new Size(150, 23);
            inputAbilityName.TabIndex = 17;
            inputAbilityName.TextChanged += TextboxUpdatedEvent;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(342, 328);
            label9.Name = "label9";
            label9.Size = new Size(96, 15);
            label9.TabIndex = 16;
            label9.Text = "* = required field";
            // 
            // tabLore
            // 
            tabLore.Controls.Add(buttonRemoveLoreAnim);
            tabLore.Controls.Add(label2);
            tabLore.Controls.Add(label1);
            tabLore.Controls.Add(labelLoreAnimName);
            tabLore.Controls.Add(labelLoreImageName);
            tabLore.Controls.Add(labelLoreAnim);
            tabLore.Controls.Add(labelLoreImage);
            tabLore.Controls.Add(buttonUploadLoreAnim);
            tabLore.Controls.Add(buttonUploadLore);
            tabLore.Controls.Add(labelRequired4);
            tabLore.Controls.Add(labelDetail2);
            tabLore.Controls.Add(labelDetail1);
            tabLore.Controls.Add(labelQuote);
            tabLore.Controls.Add(labelStory2);
            tabLore.Controls.Add(labelStory1);
            tabLore.Controls.Add(inputQuote);
            tabLore.Controls.Add(inputStory2);
            tabLore.Controls.Add(inputStory2Title);
            tabLore.Controls.Add(inputStory1);
            tabLore.Controls.Add(inputStory1Title);
            tabLore.Controls.Add(inputDetail2);
            tabLore.Controls.Add(inputDetail2Name);
            tabLore.Controls.Add(inputDetail1);
            tabLore.Controls.Add(inputDetail1Name);
            tabLore.Location = new Point(4, 24);
            tabLore.Name = "tabLore";
            tabLore.Padding = new Padding(3);
            tabLore.Size = new Size(490, 346);
            tabLore.TabIndex = 3;
            tabLore.Text = "Lore Card";
            tabLore.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveLoreAnim
            // 
            buttonRemoveLoreAnim.Location = new Point(108, 317);
            buttonRemoveLoreAnim.Name = "buttonRemoveLoreAnim";
            buttonRemoveLoreAnim.Size = new Size(21, 23);
            buttonRemoveLoreAnim.TabIndex = 35;
            buttonRemoveLoreAnim.Text = "x";
            buttonRemoveLoreAnim.UseVisualStyleBackColor = true;
            buttonRemoveLoreAnim.Click += buttonRemoveLoreAnim_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(415, 222);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 34;
            label2.Text = "\"";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(66, 222);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 33;
            label1.Text = "\"";
            // 
            // labelLoreAnimName
            // 
            labelLoreAnimName.AutoSize = true;
            labelLoreAnimName.Location = new Point(135, 321);
            labelLoreAnimName.Name = "labelLoreAnimName";
            labelLoreAnimName.Size = new Size(12, 15);
            labelLoreAnimName.TabIndex = 32;
            labelLoreAnimName.Text = "?";
            // 
            // labelLoreImageName
            // 
            labelLoreImageName.AutoSize = true;
            labelLoreImageName.Location = new Point(108, 276);
            labelLoreImageName.Name = "labelLoreImageName";
            labelLoreImageName.Size = new Size(12, 15);
            labelLoreImageName.TabIndex = 31;
            labelLoreImageName.Text = "?";
            // 
            // labelLoreAnim
            // 
            labelLoreAnim.AutoSize = true;
            labelLoreAnim.Location = new Point(6, 299);
            labelLoreAnim.Name = "labelLoreAnim";
            labelLoreAnim.Size = new Size(89, 15);
            labelLoreAnim.TabIndex = 30;
            labelLoreAnim.Text = "Card animation";
            // 
            // labelLoreImage
            // 
            labelLoreImage.AutoSize = true;
            labelLoreImage.Location = new Point(6, 254);
            labelLoreImage.Name = "labelLoreImage";
            labelLoreImage.Size = new Size(73, 15);
            labelLoreImage.TabIndex = 29;
            labelLoreImage.Text = "Card image*";
            // 
            // buttonUploadLoreAnim
            // 
            buttonUploadLoreAnim.Location = new Point(6, 317);
            buttonUploadLoreAnim.Name = "buttonUploadLoreAnim";
            buttonUploadLoreAnim.Size = new Size(96, 23);
            buttonUploadLoreAnim.TabIndex = 28;
            buttonUploadLoreAnim.Text = "Upload File";
            buttonUploadLoreAnim.UseVisualStyleBackColor = true;
            buttonUploadLoreAnim.Click += buttonUploadLoreAnim_Click;
            // 
            // buttonUploadLore
            // 
            buttonUploadLore.Location = new Point(6, 272);
            buttonUploadLore.Name = "buttonUploadLore";
            buttonUploadLore.Size = new Size(96, 23);
            buttonUploadLore.TabIndex = 27;
            buttonUploadLore.Text = "Upload File";
            buttonUploadLore.UseVisualStyleBackColor = true;
            buttonUploadLore.Click += buttonUploadLore_Click;
            // 
            // labelRequired4
            // 
            labelRequired4.AutoSize = true;
            labelRequired4.Location = new Point(388, 328);
            labelRequired4.Name = "labelRequired4";
            labelRequired4.Size = new Size(96, 15);
            labelRequired4.TabIndex = 16;
            labelRequired4.Text = "* = required field";
            // 
            // labelDetail2
            // 
            labelDetail2.AutoSize = true;
            labelDetail2.Location = new Point(252, 19);
            labelDetail2.Name = "labelDetail2";
            labelDetail2.Size = new Size(51, 15);
            labelDetail2.TabIndex = 14;
            labelDetail2.Text = "Detail 2*";
            // 
            // labelDetail1
            // 
            labelDetail1.AutoSize = true;
            labelDetail1.Location = new Point(77, 19);
            labelDetail1.Name = "labelDetail1";
            labelDetail1.Size = new Size(51, 15);
            labelDetail1.TabIndex = 12;
            labelDetail1.Text = "Detail 1*";
            // 
            // labelQuote
            // 
            labelQuote.AutoSize = true;
            labelQuote.Location = new Point(220, 201);
            labelQuote.Name = "labelQuote";
            labelQuote.Size = new Size(45, 15);
            labelQuote.TabIndex = 11;
            labelQuote.Text = "Quote*";
            // 
            // labelStory2
            // 
            labelStory2.AutoSize = true;
            labelStory2.Location = new Point(265, 85);
            labelStory2.Name = "labelStory2";
            labelStory2.Size = new Size(48, 15);
            labelStory2.TabIndex = 10;
            labelStory2.Text = "Story 2*";
            // 
            // labelStory1
            // 
            labelStory1.AutoSize = true;
            labelStory1.Location = new Point(47, 88);
            labelStory1.Name = "labelStory1";
            labelStory1.Size = new Size(48, 15);
            labelStory1.TabIndex = 9;
            labelStory1.Text = "Story 1*";
            // 
            // inputQuote
            // 
            inputQuote.Location = new Point(77, 219);
            inputQuote.Name = "inputQuote";
            inputQuote.Size = new Size(339, 23);
            inputQuote.TabIndex = 8;
            inputQuote.TextChanged += TextboxUpdatedEvent;
            // 
            // inputStory2
            // 
            inputStory2.AcceptsReturn = true;
            inputStory2.Location = new Point(252, 114);
            inputStory2.Multiline = true;
            inputStory2.Name = "inputStory2";
            inputStory2.Size = new Size(230, 81);
            inputStory2.TabIndex = 7;
            inputStory2.TextChanged += TextboxUpdatedEvent;
            // 
            // inputStory2Title
            // 
            inputStory2Title.Location = new Point(314, 85);
            inputStory2Title.Name = "inputStory2Title";
            inputStory2Title.Size = new Size(100, 23);
            inputStory2Title.TabIndex = 6;
            inputStory2Title.TextChanged += TextboxUpdatedEvent;
            // 
            // inputStory1
            // 
            inputStory1.AcceptsReturn = true;
            inputStory1.Location = new Point(4, 114);
            inputStory1.Multiline = true;
            inputStory1.Name = "inputStory1";
            inputStory1.Size = new Size(230, 81);
            inputStory1.TabIndex = 5;
            inputStory1.TextChanged += TextboxUpdatedEvent;
            // 
            // inputStory1Title
            // 
            inputStory1Title.Location = new Point(101, 85);
            inputStory1Title.Name = "inputStory1Title";
            inputStory1Title.Size = new Size(100, 23);
            inputStory1Title.TabIndex = 4;
            inputStory1Title.TextChanged += TextboxUpdatedEvent;
            // 
            // inputDetail2
            // 
            inputDetail2.Location = new Point(252, 45);
            inputDetail2.Name = "inputDetail2";
            inputDetail2.Size = new Size(157, 23);
            inputDetail2.TabIndex = 3;
            inputDetail2.TextChanged += TextboxUpdatedEvent;
            // 
            // inputDetail2Name
            // 
            inputDetail2Name.Location = new Point(309, 16);
            inputDetail2Name.Name = "inputDetail2Name";
            inputDetail2Name.Size = new Size(100, 23);
            inputDetail2Name.TabIndex = 2;
            inputDetail2Name.TextChanged += TextboxUpdatedEvent;
            // 
            // inputDetail1
            // 
            inputDetail1.Location = new Point(77, 45);
            inputDetail1.Name = "inputDetail1";
            inputDetail1.Size = new Size(157, 23);
            inputDetail1.TabIndex = 1;
            inputDetail1.TextChanged += TextboxUpdatedEvent;
            // 
            // inputDetail1Name
            // 
            inputDetail1Name.Location = new Point(134, 16);
            inputDetail1Name.Name = "inputDetail1Name";
            inputDetail1Name.Size = new Size(100, 23);
            inputDetail1Name.TabIndex = 0;
            inputDetail1Name.TextChanged += TextboxUpdatedEvent;
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(165, 376);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonFinish
            // 
            buttonFinish.Enabled = false;
            buttonFinish.Location = new Point(256, 376);
            buttonFinish.Name = "buttonFinish";
            buttonFinish.Size = new Size(75, 23);
            buttonFinish.TabIndex = 2;
            buttonFinish.Text = "Finish";
            buttonFinish.UseVisualStyleBackColor = true;
            buttonFinish.Click += buttonFinish_Click;
            // 
            // openFileDialogPng
            // 
            openFileDialogPng.Filter = "Image files|*.png";
            openFileDialogPng.InitialDirectory = "%userhome%";
            openFileDialogPng.ShowPreview = true;
            // 
            // openFileDialogGif
            // 
            openFileDialogGif.Filter = "GIF files|*.gif";
            openFileDialogGif.InitialDirectory = "%userhome%";
            // 
            // EditCardSet
            // 
            AcceptButton = buttonFinish;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(498, 408);
            Controls.Add(buttonFinish);
            Controls.Add(buttonCancel);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "EditCardSet";
            Text = "Edit Card Set - ExLa Card Viewer";
            tabControl1.ResumeLayout(false);
            tabDetails.ResumeLayout(false);
            tabDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRarity).EndInit();
            ((System.ComponentModel.ISupportInitialize)inputCharNum).EndInit();
            tabPortrait.ResumeLayout(false);
            tabPortrait.PerformLayout();
            tabAbility.ResumeLayout(false);
            tabAbility.PerformLayout();
            tabLore.ResumeLayout(false);
            tabLore.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabDetails;
        private TabPage tabPortrait;
        private Button buttonRarityDown;
        private Button buttonRarityUp;
        private TabPage tabAbility;
        private TabPage tabLore;
        private Label labelName;
        private TextBox inputCharName;
        private Label labelSeries;
        private Label labelNumber;
        private NumericUpDown inputCharNum;
        private TextBox inputCharSeries;
        private Button buttonCancel;
        private Button buttonFinish;
        private Label labelRarity;
        private Label labelRequired1;
        private Label labelRarityName;
        private TextBox inputPortraitTitle;
        private Button buttonUploadPortraitAnim;
        private Button buttonUploadPortrait;
        private OpenFileDialog openFileDialogPng;
        private OpenFileDialog openFileDialogGif;
        private Label labelPortraitAnim;
        private Label labelTitle;
        private Label labelPortraitImage;
        private Label labelRequired2;
        private Label labelPortraitAnimName;
        private Label labelPortraitImageName;
        private TextBox inputDetail1;
        private TextBox inputDetail1Name;
        private TextBox inputStory2Title;
        private TextBox inputStory1;
        private TextBox inputStory1Title;
        private TextBox inputDetail2;
        private TextBox inputDetail2Name;
        private TextBox inputQuote;
        private TextBox inputStory2;
        private Label labelQuote;
        private Label labelStory2;
        private Label labelStory1;
        private Label labelDetail2;
        private Label labelDetail1;
        private Label label9;
        private Label labelRequired4;
        private Label labelAbilityAnimName;
        private Label labelAbilityImageName;
        private Label labelAbilityAnim;
        private Label labelAbilityImage;
        private Button buttonUploadAbilityAnim;
        private Button buttonUploadAbility;
        private Label labelAbilityDesc;
        private Label labelAbilityName;
        private TextBox inputAbilityDesc;
        private TextBox inputAbilityName;
        private Label labelLoreAnimName;
        private Label labelLoreImageName;
        private Label labelLoreAnim;
        private Label labelLoreImage;
        private Button buttonUploadLoreAnim;
        private Button buttonUploadLore;
        private Label label2;
        private Label label1;
        private PictureBox pictureBoxRarity;
        private Button buttonRemovePortraitAnim;
        private Button buttonRemoveAbilityAnim;
        private Button buttonRemoveLoreAnim;
    }
}