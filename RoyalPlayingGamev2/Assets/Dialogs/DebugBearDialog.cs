using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoyalPlayingGame.Dialogs;

public class DebugBearDialog : Dialog {

    public override void LoadDialog(string path)
    {
        this.RootReplic = new NPCReplic
        {
            ID = "DBG_bear_root",
            Phrase =  "Ну привет, герой."+ "Долго же ты добирался.",
            Duration = 2000
        };
        var a1 = new Answer
        {
            ID = "DBG_bear_hello",
            Phrase = "Привет, добрый курящий медведь!" + "Где я? Что за дерьмо происходит?",
            Duration = 2000
        };
        var a2 = new Answer
        {
            ID = "DBG_bear_exit",
            Phrase = "Я лучше пойду",
            Duration = 2000,
            Next = null
        };
        var choice = new PlayerChoice
        {
            Answers = new List<Answer>
            {
                a1, a2
            }
        };
        RootReplic.AddNext(choice);
        var r1 = new NPCReplic
        {
            ID = "",
            Phrase = "Ты в дебаге, дружок",
            Duration = 2000,
            Next = choice
        };
        a1.AddNext(r1);
        
    }

}
