using System;
using System.Collections.Generic;
using System.Text;
using RoyalPlayingGame.Quests;
/* Назначение: Слушатель для координации работы между диалогами и репликам
 * Автор: Никитенко А.В.
 */
namespace RoyalPlayingGame
{
    public delegate void QuestHandler(string questID);
    public delegate void QuestStageHandler(string stageID);
    public delegate void ReplicVisibleChange(string replicID);
    public static class QuestManager
    {
        public static List<Quest> ActiveQuests = new List<Quest>();
        public static List<Quest> PassedQuests = new List<Quest>();
        public static List<Quest> FailedQuest = new List<Quest>();

        public static List<Quest> QuestRepository = new List<Quest>();
        
        

        // события и методы для дачи/принятия квеста
        public static event QuestHandler QuestPassed;
        public static event QuestHandler QuestReceived;

        /// <summary>
        /// сдать квест
        /// </summary>
        /// <param name="quest"></param>
        public static void CompleteQuest(string questID)
        {
            Quest quest = null;
            if ((quest = ActiveQuests.Find(q => q.ID == questID)) != null)
            {
                ActiveQuests.Remove(quest);
                PassedQuests.Add(quest);
                QuestPassed?.Invoke(questID);
            }
        }
        /// <summary>
        /// получить новый квест
        /// </summary>
        /// <param name="quest"></param>
        public static void ReceiveQuest(string questID)
        {
            if (ActiveQuests.Find(q => q.ID == questID) == null)
            {
                var quest = QuestRepository.Find(q => q.ID == questID);
                QuestReceived?.Invoke(questID);
                ActiveQuests.ForEach(q => q.IsActive = false);
                ActiveQuests.Add(quest);
                quest.Start();
                quest.IsActive = true;
            }
        }
        

        // события и методы для отлова событий на окончание квестовой стадии
        public static event QuestStageHandler QuestStageComplited;
        public static void CompleteQuestStage(string stageID)
        {
            QuestStageComplited?.Invoke(stageID);
        }
    }
}
