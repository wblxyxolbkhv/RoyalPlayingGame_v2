using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoyalPlayingGame;
using RoyalPlayingGame.Quests;
using RoyalPlayingGame.Quests.QuestStages;

public class DebugQuest : Quest {
    
    public override void LoadQuest(string path)
    {
        this.ID = "DBG_Quest";
        this.Name = "Нежданное путешествие";
        var s1 = new ToPointStage(triggerID: "DBG_Right_edge")
        {
            ID = "DBG_To_right_edge",
            Name = "Сходи на правый конец света"
        };
        var s2 = new ToPointStage(triggerID: "DBG_Left_edge")
        {
            ID = "DBG_To_left_edge",
            Name = "Сходи на левый конец света",
            ShownReplics = new List<string> { "DBG_end_replic" }
        };
        var s3 = new ToUnitStage(replicID: "DBG_end_replic")
        {
            ID = "DBG_return",
            Name = "Вернись к медведю"
        };
        AddQuestStage(s1);
        AddQuestStage(s2);
        AddQuestStage(s3);
    }
    public override void OnQuestStarted()
    {
        GlobalListener.ReplicHide("DBG_bear_job");
    }
    public override void OnQuestEnded()
    {
        GlobalListener.ReplicHide("DBG_end_replic");
    }
}
