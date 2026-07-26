using System;
using System.Collections.Generic;
using System.Text;

namespace CardViewer.Models
{
    public class PortraitCard : ICloneable
    {
        public string ImageFile { get; set; }
        public string? AnimFile { get; set; }
        public string Title { get; set; }

        /// <summary>
        /// Creates an empty card to be filled in later
        /// </summary>
        public PortraitCard()
        {
            ImageFile = "";
            Title = "";
        }

        public PortraitCard(string imageFile, string title)
        {
            ImageFile = imageFile;
            Title = title;
        }

        public PortraitCard(string imageFile, string title, string? animFile)
        {
            ImageFile = imageFile;
            AnimFile = animFile;
            Title = title;
        }

        public object Clone()
        {
            return new PortraitCard(this.ImageFile, this.Title, this.AnimFile);
        }
    }
}
