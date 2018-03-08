using System;
using System.Collections.Generic;
using System.Text;
using RoyalPlayingGame.Items;

namespace RoyalPlayingGame.Quests.QuestStages
{
    public class ToPointStage : QuestStage
    {
        public ToPointStage(string triggerID)
        {
            TriggerID = triggerID;
            GlobalListener.TriggerDetected += OnQuestTriggerDetected;
        }
        public string TriggerID;

        public void OnQuestTriggerDetected(string triggerID)
        {
            if (TriggerID == triggerID)
                Complete();
        }

        public override string ToString()
        {
            string repr = "";
            if (IsCompleted)
                repr = " (1/1)";
            else
                repr = " (0/1)";

            repr = Name + repr;

            return repr;
        }
    }
}
