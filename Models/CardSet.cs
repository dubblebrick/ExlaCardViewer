using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CardViewer.Models
{
    public class CardSet
    {
        public string Name { get; set; }
        public string Series { get; set; }
        public int Number { get; set; }
        public RarityTier Rarity { get; set; }
        public PortraitCard Portrait { get; init; }
        public AbilityCard Ability { get; init; }
        public LoreCard Lore { get; init; }

        public CardSet()
        {
            Name = "";
            Series = "";
            Number = 0;
            Rarity = RarityTier.Rare;
            Portrait = new PortraitCard();
            Ability = new AbilityCard();
            Lore = new LoreCard();
        }

        public CardSet(string name, string series, int number, RarityTier rarity, PortraitCard portrait, AbilityCard ability, LoreCard lore)
        {
            Name = name;
            Series = series;
            Number = number;
            Rarity = rarity;
            Portrait = portrait;
            Ability = ability;
            Lore = lore;
        }

        public enum RarityTier
        {
            Rare = 1,
            SuperRare = 3,
            SuperSuperRare = 5,
            Mythic = 6,
        }
    }
}
