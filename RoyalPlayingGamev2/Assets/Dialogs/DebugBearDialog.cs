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
            Phrase =  "Ну привет, герой. Долго же ты добирался.",
            Duration = 2000
        };
        var a1 = new Answer
        {
            ID = "DBG_bear_hello",
            Phrase = "Привет, добрый курящий медведь! Где я? Что за дерьмо происходит?",
            Duration = 2000
        };
        var a2 = new Answer
        {
            ID = "DBG_bear_exit",
            Phrase = "Я лучше пойду",
            Duration = 2000,
            Next = null
        };
        var r2 = new NPCReplic
        {
            Phrase = "Конечно, можешь сделать кое что для меня. Прогуляйся и замочи морковку.",
            Duration = 2000
        };
        var a3 = new Answer
        {
            ID = "DBG_bear_job",
            Phrase = "Чем я могу заняться в этом безумном мире?",
            Duration = 2000,
            Next = r2
        };
        var aa1 = new Answer
        {
            ID = "DBG_end_replic",
            Phrase = "Готово, я сходил вперед и назад!",
            Duration = 2000,
            IsHidden = true
        };
        var choice = new PlayerChoice
        {
            Answers = new List<Answer>
            {
                a1, a2, a3, aa1
            }
        };
        RootReplic.AddNext(choice);
        var r1 = new NPCReplic
        {
            Phrase = "Ты в дебаге, дружок",
            Duration = 2000,
            Next = choice
        };
        var r3 = new NPCReplic
        {
            Phrase = "Тогда вперед! А потом назад.",
            Duration = 2000,
            Next = choice
        };
        var r4 = new NPCReplic
        {
            Phrase = "На нет и суда нет",
            Duration = 2000,
            Next = choice
        };
        var a4 = new Answer
        {
            ID = "DBG_give_job",
            Phrase = "Да, запросто",
            Duration = 2000,
            Next = r3,
            ReceiveQuest = "DBG_Quest"
        };
        var a5 = new Answer
        {
            ID = "DBG_lost_job",
            Phrase = "Нет, спасибо",
            Duration = 2000,
            Next = r4
        };
        var choice1 = new PlayerChoice
        {
            Answers = new List<Answer>
            {
                a4, a5
            }
        };
        a1.AddNext(r1);
        r2.AddNext(choice1);
        
    }

}
