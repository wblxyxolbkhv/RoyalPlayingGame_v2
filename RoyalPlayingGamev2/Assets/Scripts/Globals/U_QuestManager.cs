using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoyalPlayingGame.Quests;
using RoyalPlayingGame;

namespace RoyalPlayingGamev2.Globals
{
    public class U_QuestManager : MonoBehaviour
    {

        public bool isActiveQuestHidden = false;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }




        float activeQuestWidth = 200;
        float marginRight = 15;
        float marginTop = 15;
        private void OnGUI()
        {
            Quest quest = QuestManager.ActiveQuests.Find(q => q.IsActive = true);
            if (!isActiveQuestHidden && quest != null)
            {
                var leftLabelStyle = GUI.skin.GetStyle("Label");
                leftLabelStyle.alignment = TextAnchor.UpperLeft;
                leftLabelStyle.wordWrap = true;
                leftLabelStyle.stretchHeight = true;
                leftLabelStyle.fontSize = 16;

                var height = leftLabelStyle.CalcHeight(new GUIContent(quest.Name), activeQuestWidth);

                GUI.Label(new Rect(Screen.width - activeQuestWidth - marginRight,
                                   marginTop,
                                   activeQuestWidth,
                                   height),
                          quest.Name,
                          leftLabelStyle);
                var h = leftLabelStyle.CalcHeight(new GUIContent(quest.CurrentQuestStage.ToString()), activeQuestWidth);
                GUI.Label(new Rect(Screen.width - activeQuestWidth - marginRight,
                                   marginTop + height + 5,
                                   activeQuestWidth,
                                   h),
                          quest.CurrentQuestStage.ToString(),
                          leftLabelStyle);
            }
        }
    }
}