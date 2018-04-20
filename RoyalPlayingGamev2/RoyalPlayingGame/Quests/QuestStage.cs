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
        public QuestStage()
        {
            MoneyReward = 0;
            ExperienceReward = 10;
            ItemReward = new List<Item>();
            IsCompleted = false;
            IsCurrent = false;
        }
        public event Action<bool> QuestStageCompleted;
        
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int MoneyReward { get; set; }
        public int ExperienceReward { get; set; }
        public List<Item> ItemReward { get; set; }

        public bool IsCompleted { get; protected set; }
        public bool IsCurrent { get; set; }
        
        public List<string> ShownReplics { get; set; }
        public List<string> HiddenReplics { get; set; }

        public void Complete()
        {
            if (ShownReplics != null)
                ShownReplics.ForEach(replicID => GlobalListener.ReplicShow(replicID));

            if (HiddenReplics != null)
                HiddenReplics.ForEach(replicID => GlobalListener.ReplicHide(replicID));

            IsCompleted = true;
            QuestManager.CompleteQuestStage(ID);
            if (QuestStageCompleted != null)
                QuestStageCompleted(true);
        }

        public Predicate<object> CompleteDelegate;
        public virtual bool IsCompteted()
        {
            if (CompleteDelegate != null)
                return CompleteDelegate(null);
            return false;
        }
    }
}
