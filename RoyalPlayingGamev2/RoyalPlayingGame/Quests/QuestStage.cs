using System;
using System.Collections.Generic;
using System.Text;
using RoyalPlayingGame.Items;

namespace RoyalPlayingGame.Quests
{
    /// <summary>
    /// Квестовая стадия, автор: Жифарский Д.А.
    /// </summary>
    public abstract class QuestStage
    {
        public QuestStage(int moneyReward, int experieneReward, List<Item> itemReward, string name, string description, int index)
        {
            Name = name;
            Description = description;
            ExperienceReward = experieneReward;
            ItemReward = itemReward;
            MoneyReward = moneyReward;
            IsCompleted = false;
            IsCurrent = false;
        }
        public QuestStage(string name, string description, int index)
        {
            Name = name;
            Description = description;
            MoneyReward = 0;
            ExperienceReward = 10;
            ItemReward = new List<Item>();
            IsCompleted = false;
            IsCurrent = false;
        }

        public QuestStage()
        {
            MoneyReward = 0;
            ExperienceReward = 10;
            ItemReward = new List<Item>();
            IsCompleted = false;
            IsCurrent = false;
        }
        //public List<string> Objective { get; set; }
        public event Action<bool> QuestStageCompleted;
        public int MoneyReward { get; set; }
        public List<Item> ItemReward { get; set; }
        public int ExperienceReward { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public string ID { get; set; }
        public bool IsCurrent { get; set; }


        public string ShownReplic { get; set; }
        public string HiddenReplic { get; set; }

        public void CallQSCEvent()
        {
            if (!string.IsNullOrEmpty(ShownReplic))
                QuestManager.ReplicShow(Convert.ToInt32(ShownReplic));

            if (!string.IsNullOrEmpty(HiddenReplic))
                QuestManager.ReplicHide(Convert.ToInt32(HiddenReplic));

            QuestManager.CompleteQuestStage(ID);
            if (QuestStageCompleted != null)
                QuestStageCompleted(true);
            IsCompleted = true;
        }
    }
}
