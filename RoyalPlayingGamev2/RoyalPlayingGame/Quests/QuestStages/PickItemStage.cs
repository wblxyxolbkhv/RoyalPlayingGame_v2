using System;
using System.Collections.Generic;
using System.Text;
using RoyalPlayingGame.Items;
using RoyalPlayingGame.Units;

namespace RoyalPlayingGame.Quests.QuestStages
{
    public class PickItemStage : QuestStage
    {
        public PickItemStage():base()
        {
            //Unit.QuestItemPicked += OnItemPicked;
            //Unit.QuestItemDroped += OnItemDroped;
        }

        //private List<PickItemStageGroup> PickedQuestItems { get; set; }
        /*
        public void AddQuestItem(string ID, string name, int maxAmount, string objective)
        {
            Item item = new Item(ID, name, maxAmount);
            PickItemStageGroup pisg = new PickItemStageGroup(item, objective);
            PickedQuestItems.Add(pisg);
        }

        public void RemoveQuestItem(PickItemStageGroup pisg)
        {
            PickedQuestItems.Remove(pisg);
        }

        private void OnItemDroped(string ID)
        {
            foreach(PickItemStageGroup pisg in PickedQuestItems)
            {
                if (pisg.Item.ID == ID)
                if (pisg.Item.Amount > 0)
                        pisg.Item.Amount--;
            }
        }

        private void OnItemPicked(string ID)
        {
            if (!IsCurrent)
                return;
         foreach (PickItemStageGroup pisg in PickedQuestItems)
            {
                if (pisg.Item.ID == ID)
                    pisg.Item.Amount++;
            }
         foreach(PickItemStageGroup pisg in PickedQuestItems)
            {
                if (pisg.Item.Amount < pisg.Item.MaxAmount)
                    return;
            }
            Complete();
        }
        */

    }
}
