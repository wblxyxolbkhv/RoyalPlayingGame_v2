using System;
using System.Collections.Generic;
using System.Text;
using RoyalPlayingGame.Items;
using RoyalPlayingGame;

namespace RoyalPlayingGame.Quests.QuestStages
{
    public class ToUnitStage : QuestStage
    {
        public ToUnitStage(int moneyReward, int experieneReward, List<Item> itemReward, string name, string description, int index) 
            : base(moneyReward, experieneReward, itemReward, name, description, index)
        {

        }

        public ToUnitStage(string name, string description, int index):base(name,description,index)
        {

        }
        public ToUnitStage():base()
        {

        }
    }
}
