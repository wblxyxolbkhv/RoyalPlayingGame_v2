using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalPlayingGame.Quests.QuestStages
{
    public class ToPointStageGroup
    {
        public ToPointStageGroup()
        {

        }
        public ToPointStageGroup(string ID, string objective)
        {
            this.ID = ID;
            Objective = objective;
        }
        public string ID { get; set; }
        public string Objective { get; set; }
    }
}
