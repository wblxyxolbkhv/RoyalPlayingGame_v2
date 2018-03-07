using System;
using RoyalPlayingGame.Quests;
/* Назначение: Базовый класс для реплик
 * предполагается, что диалог будет графом из реплик
 * Автор: Никитенко А.В.
 */
namespace RoyalPlayingGame.Dialogs
{
    public abstract class Replic
    {
        public Replic()
        {
            QuestManager.ReplicHidden += OnAnyReplicHidden;
            QuestManager.ReplicShown += OnAnyReplicShown;

            IsHidden = false;
        }

        private void OnAnyReplicShown(int replicID)
        {
            if (replicID.ToString() == ID)
                IsHidden = false;
        }

        private void OnAnyReplicHidden(int replicID)
        {
            if (replicID.ToString() == ID)
                IsHidden = true;
        }
        /// <summary>
        /// используется для формирования графа из реплик
        /// </summary>
        /// <param name="replic"></param>
        /// <returns></returns>
        public Replic AddNext(Replic replic)
        {
            this.Next = replic;
            return replic;
        }
        public string ID
        {
            get;set;
        }
        public Replic Next
        {
            get; set;
        }
        public int Duration
        {
            get; set;
        } = 1000;
        public int CurrentDuration
        {
            get; set;
        } = 0;
        /// <summary>
        /// квести, который начинается с этой репликой (его ID)
        /// </summary>
        public Quest PassedQuest { get; set; } = null;
        /// <summary>
        /// квести, который заканчивается с этой репликой (его ID)
        /// </summary>
        public Quest ReceiveQuest { get; set; } = null;
        /// <summary>
        /// возвращает следующую за этой реплику
        /// </summary>
        /// <returns></returns>
        public virtual Replic GetNextReplic()
        {
            return Next;
        }

        public bool IsHidden { get; set; }
    }
}
