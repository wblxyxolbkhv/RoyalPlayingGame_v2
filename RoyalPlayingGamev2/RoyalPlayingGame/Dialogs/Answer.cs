using System;
using System.Collections.Generic;
using System.Text;

/* Назначение: Ответ игрока в диалоге
 * Автор: Никитенко А.В.
 */

namespace RoyalPlayingGame.Dialogs
{
    /// <summary>
    /// один из ответов игрока в диалоге
    /// </summary>
    public class Answer : Replic
    {
        public Answer() : base()
        {
        }
        /// <summary>
        /// набор фраз, говоримые подряд персонажем
        /// </summary>
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
