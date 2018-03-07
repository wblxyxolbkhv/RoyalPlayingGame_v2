using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoyalPlayingGame.Dialogs;

public class DialogManager : MonoBehaviour {

    public static DialogManager Instance;

    public Dialog CurrentDialog;

    public Talker PotentialTalker;


	// Use this for initialization
	void Start ()
    {
        DialogManager.Instance = GetComponent<DialogManager>();

        DialogListener.AnswerSelected += OnAnswerChoosen;
	}
	
	// Update is called once per frame
	void Update () {
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

    void OnGUI()
    {
        if (CurrentDialog != null && CurrentDialog.IsActive)
        {
            if (CurrentDialog.CurrentReplic is NPCReplic)
                GUI.Label(new Rect(150, 200, 500, 100), "NPC: " + CurrentDialog.CurrentReplic.ToString());
            else if (CurrentDialog.CurrentReplic is Answer)
                GUI.Label(new Rect(150, 200, 500, 100), "Игрок: " + CurrentDialog.CurrentReplic.ToString());
            else
            {
                var choice = CurrentDialog.CurrentReplic as PlayerChoice;
                GUI.Box(new Rect(100, 50, 600, choice.Answers.Count * 20), GUIContent.none);
                for (int i =0;i< choice.Answers.Count;i++)
                {
                    var ans = choice.Answers[i];
                    if (GUI.Button(new Rect(150, 50+i*20, 500, 20), ans.ToString()))
                        OnAnswerChoosen(ans);
                }
            }
        }
        else
        {
            if (PotentialTalker != null)
                GUI.Label(new Rect(100, 100, 500, 100), "Нажмите Е, чтобы поговорить");
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
