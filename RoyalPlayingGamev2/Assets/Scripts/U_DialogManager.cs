using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoyalPlayingGame.Dialogs;

public class U_DialogManager : MonoBehaviour
{

    public static U_DialogManager Instance;

    public Dialog CurrentDialog;

    public Talker PotentialTalker;

    public Texture ChoiceBoxTexture;


    // Use this for initialization
    void Start()
    {
        U_DialogManager.Instance = this;

        DialogListener.AnswerSelected += OnAnswerChoosen;
    }

    // Update is called once per frame
    void Update()
    {
        if (PotentialTalker != null && Input.GetKey(KeyCode.E))
        {
            PotentialTalker.Activate();
            CurrentDialog = PotentialTalker.currentDialog;
            CurrentDialog.IsActive = true;
        }
        if (CurrentDialog == null)
            return;
        CurrentDialog.OnTimerTick((int)(Time.deltaTime * 1000));
    }


    float replicWidth = 500;
    float replicHeight = 100;
    float marginBottom = 50;
    float marginTop = 50;
    
    float buttonWidth = 500;

    void OnGUI()
    {
        // если диалог идет в данный момент
        if (CurrentDialog != null && CurrentDialog.IsActive)
        {
            U_GameManager.Instance.SetPlayerInteraction(false);

            var centeredStyle = GUI.skin.GetStyle("Label");
            centeredStyle.alignment = TextAnchor.UpperCenter;
            centeredStyle.fontSize = 20;
            // рисуем реплики
            if (CurrentDialog.CurrentReplic is NPCReplic)
                GUI.Label(new Rect(Screen.width / 2 - replicWidth / 2, Screen.height - replicHeight - marginBottom, replicWidth, replicHeight),
                          PotentialTalker.Name + ": " + CurrentDialog.CurrentReplic.ToString(),
                          centeredStyle);
            else if (CurrentDialog.CurrentReplic is Answer)
                GUI.Label(new Rect(Screen.width / 2 - replicWidth / 2, Screen.height - replicHeight - marginBottom, replicWidth, replicHeight),
                          "Игрок: " + CurrentDialog.CurrentReplic.ToString(),
                          centeredStyle);
            else
            {
                // или рисуем окно выбора ответа
                var choice = CurrentDialog.CurrentReplic as PlayerChoice;
                if (choice == null || choice.Answers == null || choice.Answers.Count == 0)
                    return;


                var buttonStyle = GUI.skin.GetStyle("Button");
                buttonStyle.fontSize = 20;
                buttonStyle.stretchHeight = true;
                buttonStyle.wordWrap = true;

                var margin = marginTop;
                for (int i = 0; i < choice.Answers.Count; i++)
                {
                    var ans = choice.Answers[i];
                    if (ans.IsHidden)
                        continue;
                    var height = buttonStyle.CalcHeight(new GUIContent(ans.ToString()), buttonWidth);
                    if (GUI.Button(new Rect(Screen.width / 2 - replicWidth / 2, margin, buttonWidth, height),
                        ans.ToString()))
                        OnAnswerChoosen(ans);
                    margin += height + 5;
                }
            }
        }
        else
        {
            U_GameManager.Instance.SetPlayerInteraction(true);
            if (PotentialTalker != null)
                GUI.Label(new Rect(Screen.width / 2 - replicWidth / 2, Screen.height / 2 - replicHeight / 2, replicWidth, replicHeight),
                          "Нажмите Е, чтобы поговорить");
        }

    }

    private void OnAnswerChoosen(Replic answer)
    {
        Answer a = answer as Answer;
        if (CurrentDialog == null)
            return;
        CurrentDialog.CurrentReplic = a;
        a.CurrentDuration = 0;
    }


}