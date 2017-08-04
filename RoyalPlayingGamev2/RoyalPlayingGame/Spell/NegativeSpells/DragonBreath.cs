using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalPlayingGame.Spell.NegativeSpells
{
    public class DragonBreath:NegativeSpell
    {
        public const string name = "dragonBreath";
        public const int castTime = 2;
        public const int manaCost = 50;
        public const int coolDown = 1;
        public DragonBreath(int realIntelligence, int realAgility):base(realIntelligence,realAgility,name,castTime,manaCost,coolDown)
        {
            BasicSpellDamage = 50;
        }
    }
}
