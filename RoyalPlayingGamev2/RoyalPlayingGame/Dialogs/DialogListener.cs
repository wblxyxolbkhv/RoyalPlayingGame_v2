using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalPlayingGame.Dialogs
{
    public delegate void ReplicChangeHandler(Replic replic);
    public static class DialogListener
    {
        public static event ReplicChangeHandler AnswerSelected;
        public static void OnAnswerSelected(Answer answer)
        {
            AnswerSelected(answer);
        }
    }
}
