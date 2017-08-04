using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalPlayingGame.Spell.NegativeSpells
{
    public class IceWave:NegativeSpell
    {
        public const string name = "icewave";
        public const int castTime = 2;
        public const int manaCost = 30;
        public const int coolDown = 1;

        public IceWave(int realIntelligence, int realAgility):base(realIntelligence,realAgility,name,castTime,manaCost,coolDown)
        {
            BasicSpellDamage = 20;
        }
    }
}
