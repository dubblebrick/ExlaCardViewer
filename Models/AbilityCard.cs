using System;
using System.Collections.Generic;
using System.Text;

namespace CardViewer.Models
{
    public class AbilityCard : ICloneable
    {
        /// <summary>
        /// Path to card image
        /// </summary>
        public string ImageFile { get; set; }
        /// <summary>
        /// Path to animated card image, if available
        /// </summary>
        public string? AnimFile { get; set; }
        public string AbilityName { get; set; }
        public string AbilityDesc { get; set; }

        public AbilityCard()
        {
            ImageFile = "";
            AbilityName = "";
            AbilityDesc = "";
        }

        public AbilityCard(string imageFile, string abilityName, string abilityDesc)
        {
            ImageFile = imageFile;
            AbilityName = abilityName;
            AbilityDesc = abilityDesc;
        }

        public AbilityCard(string imageFile, string abilityName, string abilityDesc, string? animFile)
        {
            ImageFile = imageFile;
            AbilityName = abilityName;
            AbilityDesc = abilityDesc;
            AnimFile = animFile;
        }

        public object Clone()
        {
            return new AbilityCard(this.ImageFile, this.AbilityName, this.AbilityDesc, this.AnimFile);
        }
    }
}
