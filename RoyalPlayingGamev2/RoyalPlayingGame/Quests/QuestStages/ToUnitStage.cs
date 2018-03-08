using System;
using System.Collections.Generic;
using System.Text;
using RoyalPlayingGame.Items;
using RoyalPlayingGame;

namespace RoyalPlayingGame.Quests.QuestStages
{
    public class ToUnitStage : QuestStage
    {
        public ToUnitStage(string replicID)
        {
            ReplicID = replicID;
            QuestManager.QuestStageComplited += OnSomeReplicTalked;
        }
        public string ReplicID;
        private void OnSomeReplicTalked(string replicID)
        {
            if (replicID == ReplicID)
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
