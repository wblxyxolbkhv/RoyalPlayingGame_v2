using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RoyalPlayingGame.Dialogs;

public class ChoiceBox : MonoBehaviour {

    public List<Button> buttons;

    private PlayerChoice choice;
    public PlayerChoice Choice
    {
        get
        {
            return choice;
        }
        set
        {
            choice = value;
            buttons.ForEach(b => SetLabel(b, ""));
            for (int i = 0; i<choice.Answers.Count; i++)
            {
                SetLabel(i, choice.Answers[i].Phrase);
            }
        }
    }





    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void SetLabel(int index, string text)
    {
        buttons[index].gameObject.GetComponentInChildren<Text>().text = text;
    }
    private void SetLabel(Button button, string text)
    {
        button.gameObject.GetComponentInChildren<Text>().text = text;
    }
    private void onButtonClick(int index)
    {
        if (Choice.Answers.Count >= index)
        {
            Answer a = Choice.Answers[index];
            DialogListener.OnAnswerSelected(a);
        }
    }
}
