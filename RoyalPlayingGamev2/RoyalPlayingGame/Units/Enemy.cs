using System;
using System.Collections.Generic;
using System.Text;
using RoyalPlayingGame.Items;

namespace RoyalPlayingGame.Units
{
    public class Enemy:Unit
    {
        public Enemy(string id, int health, int intellegence, int strength, int agility, int physicalDamageReduction, int magicalDamegeReduction):base()
        {
            ID = id;
            Health = RealHealth = health;
            Strength = RealStrength = strength;
            Intelligence = RealIntelligence = intellegence;
            Agility = RealAgility = agility;
            PhysicalDamageReduction = RealPhysicalDamageReduction = physicalDamageReduction;
            MagicalDamageReduction = RealMagicalDamageReduction = magicalDamegeReduction;
            Loot = new List<Item>();
        }
        
        public Enemy(string id):base()
        {
            Health = RealHealth = 30;
            Strength = RealStrength = 3;
            Intelligence = RealIntelligence = 4;
            Agility = RealAgility = 4;
            PhysicalDamageReduction = RealPhysicalDamageReduction = 5;
            MagicalDamageReduction = RealMagicalDamageReduction = 8;
            Loot = new List<Item>();
        }

       
        
    }
}
