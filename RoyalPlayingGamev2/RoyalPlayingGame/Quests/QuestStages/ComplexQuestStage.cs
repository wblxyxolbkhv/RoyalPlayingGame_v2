using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalPlayingGame.Quests.QuestStages
{
    public class ComplexQuestStage: QuestStage
    {
        public List<QuestStage> Stages
        {
            get { return stages; }
            set
            {
                stages = value;
                stages.ForEach(s => s.QuestStageCompleted += OnSomeShildStageCompleted);
            }
        }

        private void OnSomeShildStageCompleted(bool obj)
        {
            if (stages.FindAll(s => !s.IsCompleted).Count == 0)
                Complete();
        }

        List<QuestStage> stages;

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
