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
            GlobalListener.ReplicHidden += OnAnyReplicHidden;
            GlobalListener.ReplicShown += OnAnyReplicShown;

            IsHidden = false;
        }

        private void OnAnyReplicShown(string replicID)
        {
            if (replicID.ToString() == ID)
                IsHidden = false;
        }

        private void OnAnyReplicHidden(string replicID)
        {
            if (replicID == ID)
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
        /// квести, который заканчивается с этой репликой (его ID)
        /// </summary>
        public string ReceiveQuest { get; set; } = null;
        /// <summary>
        /// квестовая стадия, которая выполнится на этой реплике
        /// </summary>
        public string PassedQuestStage { get; set; } = null;
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
