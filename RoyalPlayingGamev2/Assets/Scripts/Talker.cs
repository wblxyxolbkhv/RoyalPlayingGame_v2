using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoyalPlayingGame.Dialogs;

/// <summary>
/// персонаж, с которым можно поговорить
/// </summary>
public class Talker : MonoBehaviour {

    public Dialog currentDialog;

    public string Name
    {
        get { return GetComponent<UnitScript>().Name; }
    }

	// Use this for initialization
	void Start () {
        currentDialog = new DebugBearDialog();
        currentDialog.LoadDialog(null);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// актирирует диалог с персонажем
    /// </summary>
    public void Activate()
    {
        currentDialog.GoToDialogBeginning();
    }
}
