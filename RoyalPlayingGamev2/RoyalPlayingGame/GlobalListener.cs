using System;
using System.Collections.Generic;
using System.Text;
using RoyalPlayingGame.Units;
/* Назначение: Глобаный слушатель всех событий в игре
 * он уведомляет классы, которым это нужно об этих событиях
 * 
 * Автор: Никитенко А.В.
 */
namespace RoyalPlayingGame
{
    public delegate void DeathSomeUnitHandler(Unit unit);
    public static class GlobalListener
    {
        // слушает все смерти в игре
        public static event DeathSomeUnitHandler DeathSomeUnit;
        public static void SomeUnitDeath(Unit unit)
        {
            if (unit == null)
                return;
            DeathSomeUnit?.Invoke(unit);
        }

        //  слушает все столкновения с квестовыми триггерами
        public static event Action<string> TriggerDetected;
        public static void SomeTriggerDetected(string triggerID)
        {
            TriggerDetected?.Invoke(triggerID);
        }


        // события и методы для скрытия/открытия реплик в диалогах
        public static event ReplicVisibleChange ReplicHidden;
        public static event ReplicVisibleChange ReplicShown;

        public static void ReplicHide(string replicID)
        {
            ReplicHidden?.Invoke(replicID);
        }
        public static void ReplicShow(string replicID)
        {
            ReplicShown?.Invoke(replicID);
        }
        
    }
}
