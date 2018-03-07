using System;
using System.Collections.Generic;
using System.Text;
/* Назначение: Выбор следующей реплики для игрока
 * Автор: Никитенко А.В.
 */
namespace RoyalPlayingGame.Dialogs
{
    /// <summary>
    /// выбор следующей реплики для игрока
    /// </summary>
    public class PlayerChoice : Replic
    {
        public PlayerChoice() : base()
        {
            Duration = 100000;
        }
        public List<Answer> Answers
        {
            get; set;
        }
        public override Replic GetNextReplic()
        {
            return Answers[0];
        }
    }
}
