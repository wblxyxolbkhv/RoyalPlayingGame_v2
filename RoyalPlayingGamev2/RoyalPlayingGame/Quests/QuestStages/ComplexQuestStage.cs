using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalPlayingGame.Quests.QuestStages
{
    public class ComplexQuestStage: QuestStage
    {
        public List<QuestStage> Stages = new List<QuestStage>();

        public override string ToString()
        {
            var res = "";
            foreach (var s in Stages)
            {
                res += s.ToString() + "\n";
            }
            return res;
        }
    }
}
