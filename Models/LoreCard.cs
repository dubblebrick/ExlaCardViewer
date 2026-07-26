using System;
using System.Collections.Generic;
using System.Text;

namespace CardViewer.Models
{
    public class LoreCard : ICloneable
    {
        public string ImageFile { get; set; }
        public string? AnimFile { get; set; }
        public string Detail1Name { get; set; }
        public string Detail1 { get; set; }
        public string Detail2Name { get; set; }
        public string Detail2 { get; set; }
        public string Story1Title { get; set; }
        public string Story1 { get; set; }
        public string Story2Title { get; set; }
        public string Story2 { get; set; }
        public string Quote { get; set; }

        public LoreCard()
        {
            ImageFile = "";
            Detail1Name = "";
            Detail1 = "";
            Detail2Name = "";
            Detail2 = "";
            Story1Title = "";
            Story1 = "";
            Story2Title = "";
            Story2 = "";
            Quote = "";
        }

        public LoreCard(string imageFile, string detail1Name, string detail1, string detail2Name, string detail2, string story1Title, string story1, string story2Title, string story2, string quote)
        {
            ImageFile = imageFile;
            Detail1Name = detail1Name;
            Detail1 = detail1;
            Detail2Name = detail2Name;
            Detail2 = detail2;
            Story1Title = story1Title;
            Story1 = story1;
            Story2Title = story2Title;
            Story2 = story2;
            Quote = quote;
        }

        public LoreCard(string imageFile, string detail1Name, string detail1, string detail2Name, string detail2, string story1Title, string story1, string story2Title, string story2, string quote, string? animFile)
        {
            ImageFile = imageFile;
            AnimFile = animFile;
            Detail1Name = detail1Name;
            Detail1 = detail1;
            Detail2Name = detail2Name;
            Detail2 = detail2;
            Story1Title = story1Title;
            Story1 = story1;
            Story2Title = story2Title;
            Story2 = story2;
            Quote = quote;
        }

        public object Clone()
        {
            return new LoreCard(this.ImageFile, this.Detail1Name, this.Detail1, this.Detail2Name, this.Detail2, this.Story1Title, this.Story1, this.Story2Title, this.Story2, this.Quote, this.AnimFile);
        }
    }
}
