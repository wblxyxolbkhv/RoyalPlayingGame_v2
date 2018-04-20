using System;
using System.Collections.Generic;
using System.Text;
using RoyalPlayingGame;
using RoyalPlayingGame.Items;
using RoyalPlayingGame.Units;

namespace RoyalPlayingGame.Quests.QuestStages
{
    public class KillUnitStage:QuestStage
    {
        public KillUnitStage():base()
        {
            GlobalListener.DeathSomeUnit += OnSomeUnitDeath;
        }
        
        public string TargetID { get; set; }
        public int RequiredAmount { get; set; }
        public int CurrentAmount { get; set; }
        
        private void OnSomeUnitDeath(Unit unit)
        {
            if (unit.ID == TargetID && RequiredAmount > CurrentAmount)
                CurrentAmount++;
            if (RequiredAmount == CurrentAmount)
                Complete();
            
        }

        public override string ToString()
        {
            return Name + string.Format("({0}/{1})", CurrentAmount, RequiredAmount);
        }
    }
}
