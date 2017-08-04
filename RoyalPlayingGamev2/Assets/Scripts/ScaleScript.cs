using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleScript: MonoBehaviour {

    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            if (health != value)
            {
                prevHealth = health;
                health = value;
                ChangeProcent();
            }
        }
    }
    
    public Transform HPBar;
    public TextMesh text;
    private float health;
    private float prevHealth = 100;
    private float maxHealth = 100;
    //private Mesh HealthMesh;
	// Use this for initialization
	void Start ()
    {
        //HealthMesh = this.GetComponentInChildren<Mesh>();
	}
    
    private void ChangeProcent()
    {
        HPBar.transform.localScale = new Vector2(health / maxHealth, HPBar.transform.localScale.y);
        //var t= HPBar.transform.position; //= new Vector2(HPBar.transform.position.x - (health / maxHealth/2), HPBar.transform.position.y);
        HPBar.localPosition = new Vector2(HPBar.localPosition.x - ((prevHealth-health)/maxHealth/2), HPBar.localPosition.y);
        //var g = HPBar.position;
        text.text = health.ToString() + "/" + maxHealth.ToString();
    }
}
