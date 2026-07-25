using CardViewer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CardViewer.Views
{
    public partial class EditCardSet : Form
    {
        private CardSet set;
        private bool editMode;

        private int rarity;

        private string portraitImagePath = "";
        private string portraitAnimPath = "";
        private string abilityImagePath = "";
        private string abilityAnimPath = "";
        private string loreImagePath = "";
        private string loreAnimPath = "";

        /// <summary>
        /// Opens an existing card set in the editor.
        /// </summary>
        /// <param name="caller">The calling form (should only be Home)</param>
        /// <param name="set">The existing card set to edit</param>
        public EditCardSet(ref CardSet set, bool editMode = false)
        {
            this.set = set;
            this.editMode = editMode;

            InitializeComponent();

            if (editMode)
            {
                inputCharName.Enabled = false;
                buttonRarityUp.Enabled = false;
                buttonRarityDown.Enabled = false;
            }

            rarity = (int)set.Rarity;
            if (rarity == 6)
            {
                buttonRarityUp.Enabled = false;
            }
            else if (rarity == 1)
            {
                buttonRarityDown.Enabled = false;
            }
            UpdateRarity();

            inputCharName.Text = set.Name;
            inputCharSeries.Text = set.Series;
            inputCharNum.Value = set.Number;

            inputPortraitTitle.Text = set.Portrait.Title;
            portraitImagePath = set.Portrait.ImageFile;
            labelPortraitImageName.Text = set.Portrait.ImageFile == string.Empty ? "?" : Path.GetFileName(set.Portrait.ImageFile);
            portraitAnimPath = set.Portrait.AnimFile ?? string.Empty;
            labelPortraitAnimName.Text = Path.GetFileName(set.Portrait.AnimFile) ?? "?";

            inputAbilityName.Text = set.Ability.AbilityName;
            inputAbilityDesc.Text = set.Ability.AbilityDesc;
            labelAbilityImageName.Text = set.Ability.ImageFile == string.Empty ? "?" : Path.GetFileName(set.Ability.ImageFile);
            abilityImagePath = set.Ability.ImageFile;
            labelAbilityAnimName.Text = Path.GetFileName(set.Ability.AnimFile) ?? "?";
            abilityAnimPath = set.Ability.AnimFile ?? string.Empty;

            inputDetail1Name.Text = set.Lore.Detail1Name;
            inputDetail1.Text = set.Lore.Detail1;
            inputDetail2Name.Text = set.Lore.Detail2Name;
            inputDetail2.Text = set.Lore.Detail2;
            inputStory1Title.Text = set.Lore.Story1Title;
            inputStory1.Text = set.Lore.Story1;
            inputStory2Title.Text = set.Lore.Story2Title;
            inputStory2.Text = set.Lore.Story2;
            inputQuote.Text = set.Lore.Quote;
            labelLoreImageName.Text = set.Lore.ImageFile == string.Empty ? "?" : Path.GetFileName(set.Lore.ImageFile);
            loreImagePath = set.Lore.ImageFile;
            labelLoreAnimName.Text = Path.GetFileName(set.Lore.AnimFile) ?? "?";
            loreAnimPath = set.Lore.AnimFile ?? string.Empty;

            ValidateRequiredControls();
        }

        // ----- Details page events -----

        private void buttonRarityUp_Click(object sender, EventArgs e)
        {
            if (rarity >= 5)
            {
                rarity = 6;
                buttonRarityUp.Enabled = false;
            }
            else
            {
                if (rarity <= 1)
                {
                    buttonRarityDown.Enabled = true;
                }
                rarity += 2;
            }
            UpdateRarity();
        }

        private void buttonRarityDown_Click(object sender, EventArgs e)
        {
            if (rarity >= 6)
            {
                rarity = 5;
                buttonRarityUp.Enabled = true;
            }
            else 
            {
                rarity -= 2;
                if (rarity <= 1)
                {
                    buttonRarityDown.Enabled = false;
                }
            }
            UpdateRarity();
        }

        private void UpdateRarity()
        {
            labelRarityName.Text = Home.RarityNames[(CardSet.RarityTier)rarity];
            switch (rarity)
            {
                case 1:
                    pictureBoxRarity.Image = Properties.Resources.rarityStar_Rare;
                    break;
                case 3:
                    pictureBoxRarity.Image = Properties.Resources.rarityStar_SR;
                    break;
                case 5:
                    pictureBoxRarity.Image = Properties.Resources.rarityStar_SSR;
                    break;
                case 6:
                    pictureBoxRarity.Image = Properties.Resources.rarityStar_Mythic;
                    break;
            }

            if (rarity == 6)
            {
                inputCharSeries.Text = "Mythic";
                inputCharSeries.Enabled = false;
            }
            else
            {
                inputCharSeries.Text = string.Empty;
                inputCharSeries.Enabled = true;
            }
        }

        private void inputCharNum_ValueChanged(object sender, EventArgs e)
        {
            ValidateRequiredControls();
        }

        // ----- Portrait card page events -----

        private void buttonUploadPortrait_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogPng.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (Path.GetExtension(openFileDialogPng.FileName) != ".png")
                {
                    Alert form = new Alert("Card image must be a .png file.");
                    form.ShowDialog();
                }
                else
                {
                    portraitImagePath = openFileDialogPng.FileName;
                    labelPortraitImageName.Text = Path.GetFileName(portraitImagePath);
                    labelPortraitImageName.Refresh();
                    ValidateRequiredControls();
                }
            }
        }

        private void buttonUploadPortraitAnim_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogGif.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (Path.GetExtension(openFileDialogGif.FileName) != ".gif")
                {
                    Alert form = new Alert("Card animation must be a .gif file.");
                    form.ShowDialog();
                }
                else
                {
                    portraitAnimPath = openFileDialogGif.FileName;
                    labelPortraitAnimName.Text = Path.GetFileName(portraitAnimPath);
                    labelPortraitAnimName.Refresh();
                    ValidateRequiredControls();
                }
            }
        }
        private void buttonRemovePortraitAnim_Click(object sender, EventArgs e)
        {
            portraitAnimPath = string.Empty;
            labelPortraitAnimName.Text = "?";
        }

        // ----- Ability card page events -----

        private void buttonUploadAbility_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogPng.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (Path.GetExtension(openFileDialogPng.FileName) != ".png")
                {
                    Alert form = new Alert("Card image must be a .png file.");
                    form.ShowDialog();
                }
                else
                {
                    abilityImagePath = openFileDialogPng.FileName;
                    labelAbilityImageName.Text = Path.GetFileName(abilityImagePath);
                    labelAbilityImageName.Refresh();
                    ValidateRequiredControls();
                }
            }
        }

        private void buttonUploadAbilityAnim_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogGif.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (Path.GetExtension(openFileDialogGif.FileName) != ".gif")
                {
                    Alert form = new Alert("Card animation must be a .gif file.");
                    form.ShowDialog();
                }
                else
                {
                    abilityAnimPath = openFileDialogGif.FileName;
                    labelAbilityAnimName.Text = Path.GetFileName(abilityAnimPath);
                    labelAbilityAnimName.Refresh();
                    ValidateRequiredControls();
                }
            }
        }

        private void buttonRemoveAbilityAnim_Click(object sender, EventArgs e)
        {
            abilityAnimPath = string.Empty;
            labelAbilityAnimName.Text = "?";
        }


        // ----- Lore card page events -----

        private void buttonUploadLore_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogPng.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (Path.GetExtension(openFileDialogPng.FileName) != ".png")
                {
                    Alert form = new Alert("Card image must be a .png file.");
                    form.ShowDialog();
                }
                else
                {
                    loreImagePath = openFileDialogPng.FileName;
                    labelLoreImageName.Text = Path.GetFileName(loreImagePath);
                    labelLoreImageName.Refresh();
                    ValidateRequiredControls();
                }
            }
        }

        private void buttonUploadLoreAnim_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogGif.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (Path.GetExtension(openFileDialogGif.FileName) != ".gif")
                {
                    Alert form = new Alert("Card animation must be a .gif file.");
                    form.ShowDialog();
                }
                else
                {
                    loreAnimPath = openFileDialogGif.FileName;
                    labelLoreAnimName.Text = Path.GetFileName(loreAnimPath);
                    labelLoreAnimName.Refresh();
                    ValidateRequiredControls();
                }
            }
        }

        private void buttonRemoveLoreAnim_Click(object sender, EventArgs e)
        {
            loreAnimPath = string.Empty;
            labelLoreAnimName.Text = "?";
        }

        // ----- Validation & Finish button -----

        // Generic event called by every text box
        private void TextboxUpdatedEvent(object sender, EventArgs e)
        {
            ValidateRequiredControls();
        }

        private void ValidateRequiredControls()
        {
            // not sure if there is a better way to do this tbh
            if (inputCharName.Text != string.Empty &&
                inputCharSeries.Text != string.Empty &&
                inputCharNum.Value > 0 &&
                inputPortraitTitle.Text != string.Empty &&
                portraitImagePath != string.Empty &&
                inputAbilityName.Text != string.Empty &&
                inputAbilityDesc.Text != string.Empty &&
                abilityImagePath != string.Empty &&
                inputDetail1Name.Text != string.Empty &&
                inputDetail1.Text != string.Empty &&
                inputDetail2Name.Text != string.Empty &&
                inputDetail2.Text != string.Empty &&
                inputQuote.Text != string.Empty &&
                inputStory1Title.Text != string.Empty &&
                inputStory1.Text != string.Empty &&
                inputStory2Title.Text != string.Empty &&
                inputStory2.Text != string.Empty &&
                loreImagePath != string.Empty)
            {
                buttonFinish.Enabled = true;
            }
            else
            {
                buttonFinish.Enabled = false;
            }
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            if (!editMode)
            {
                // make sure a character with the same name and rarity doesn't already exist
                if (rarity == 6)
                {
                    if (Home._instance.mythicCards.ContainsKey(inputCharName.Text))
                    {
                        Alert form = new Alert("A character with the same name and rarity already exists.");
                        form.ShowDialog();
                        return;
                    }
                }
                else
                {
                    Dictionary<CardSet.RarityTier, CardSet> innerDict;
                    if (Home._instance.normalCards.TryGetValue(inputCharName.Text, out innerDict))
                    {
                        if (innerDict.ContainsKey((CardSet.RarityTier)rarity))
                        {
                            Alert form = new Alert("A character with the same name and rarity already exists.");
                            form.ShowDialog();
                            return;
                        }
                    }
                }
            }

            set.Name = inputCharName.Text;
            set.Series = inputCharSeries.Text;
            set.Number = (int)inputCharNum.Value;
            set.Rarity = (CardSet.RarityTier)rarity;

            set.Portrait.Title = inputPortraitTitle.Text;

            set.Ability.AbilityName = inputAbilityName.Text;
            set.Ability.AbilityDesc = inputAbilityDesc.Text;

            set.Lore.Detail1Name = inputDetail1Name.Text;
            set.Lore.Detail1 = inputDetail1.Text;
            set.Lore.Detail2Name = inputDetail2Name.Text;
            set.Lore.Detail2 = inputDetail2.Text;
            set.Lore.Story1Title = inputStory1Title.Text;
            set.Lore.Story1 = inputStory1.Text;
            set.Lore.Story2Title = inputStory2Title.Text;
            set.Lore.Story2 = inputStory2.Text;
            set.Lore.Quote = inputQuote.Text;

            MatchCollection matches = Regex.Matches(set.Name.ToLower(), "[a-z]+");
            StringBuilder sb = new StringBuilder();
            foreach (Match match in matches)
            {
                sb.Append(match.Value);
            }

            string safeName = sb.ToString();

            // Image files need to be copied to AppData and given standardized names
            if (!Directory.Exists(Home.AppDataDir + "\\images"))
            {
                Directory.CreateDirectory(Home.AppDataDir + "\\images");
            }

            if (set.Portrait.ImageFile != portraitImagePath)
            {
                set.Portrait.ImageFile = $"{Home.AppDataDir}\\images\\{safeName}_{rarity}_P.png";
                File.Copy(portraitImagePath, set.Portrait.ImageFile, true);
            }

            if (set.Portrait.AnimFile != portraitAnimPath)
            {
                if (portraitAnimPath != string.Empty)
                {
                    set.Portrait.AnimFile = $"{Home.AppDataDir}\\images\\{safeName}_{rarity}_PA.gif";
                    File.Copy(portraitAnimPath, set.Portrait.AnimFile, true);
                }
                else if (set.Portrait.AnimFile != null)
                {
                    File.Delete(set.Portrait.AnimFile);
                    set.Portrait.AnimFile = null;
                }
            }

            if (set.Ability.ImageFile != abilityImagePath)
            {
                set.Ability.ImageFile = $"{Home.AppDataDir}\\images\\{safeName}_{rarity}_A.png";
                File.Copy(abilityImagePath, set.Ability.ImageFile, true);
            }

            if (set.Ability.AnimFile != abilityAnimPath)
            {
                if (abilityAnimPath != string.Empty)
                {
                    set.Ability.AnimFile = $"{Home.AppDataDir}\\images\\{safeName}_{rarity}_AA.gif";
                    File.Copy(abilityAnimPath, set.Ability.AnimFile, true);
                }
                else if (set.Ability.AnimFile != null)
                {
                    File.Delete(set.Ability.AnimFile);
                    set.Ability.AnimFile = null;
                }
            }

            if (set.Lore.ImageFile != loreImagePath)
            {
                set.Lore.ImageFile = $"{Home.AppDataDir}\\images\\{safeName}_{rarity}_L.png";
                File.Copy(loreImagePath, set.Lore.ImageFile, true);
            }

            if (set.Lore.AnimFile != loreAnimPath)
            {
                if (loreAnimPath != string.Empty)
                {
                    set.Lore.AnimFile = $"{Home.AppDataDir}\\images\\{safeName}_{rarity}_LA.gif";
                    File.Copy(loreAnimPath, set.Lore.AnimFile, true);
                }
                else if (set.Lore.AnimFile != null)
                {
                    File.Delete(set.Lore.AnimFile);
                    set.Lore.AnimFile = null;
                }
            }

            DialogResult = DialogResult.OK;
        }
    }
}
