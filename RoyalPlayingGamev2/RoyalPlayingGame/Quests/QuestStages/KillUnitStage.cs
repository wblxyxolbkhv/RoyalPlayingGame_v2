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


        public Unit Target { get; set; }
        public int RequiredAmount { get; set; }
        public int CurrentAmount { get; set; }
        
        private void OnSomeUnitDeath(Unit unit)
        {
            /*
            if (!IsCurrent)
                return;
            foreach(KillUnitStageGroup kusg in Targets)
            {
                if (kusg.Target.ID == unit.ID)
                    kusg.CurrentAmount++;
            }
            foreach(KillUnitStageGroup kusg in Targets)
            {
                if (kusg.CurrentAmount < kusg.RequiredAmount)
                    return;
            }
            Complete();
            */
        }
    }
}
