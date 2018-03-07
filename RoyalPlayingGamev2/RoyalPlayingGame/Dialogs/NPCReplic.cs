using System;
using System.Collections.Generic;
using System.Text;
/* Назначение: Реплика NPC
 * Автор: Никитенко А.В.
 */
namespace RoyalPlayingGame.Dialogs
{
    public delegate void QuestHandler(int questID);
    /// <summary>
    /// реплика NPC
    /// </summary>
    public class NPCReplic : Replic
    {
        public NPCReplic() : base()
        {
        }
        public string Phrase
        {
            get; set;
        }
        public override string ToString()
        {
            return Phrase;
        }
    }
}
