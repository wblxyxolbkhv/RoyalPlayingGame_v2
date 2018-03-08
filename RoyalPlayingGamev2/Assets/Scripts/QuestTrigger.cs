using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoyalPlayingGame;

public class QuestTrigger : MonoBehaviour {

    public string TriggerID;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
            GlobalListener.SomeTriggerDetected(TriggerID);
    }
}
