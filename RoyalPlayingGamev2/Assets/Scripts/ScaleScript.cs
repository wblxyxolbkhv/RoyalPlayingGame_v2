using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleScript : MonoBehaviour {

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            if (health != value)
            {
                health = value;
                ChangeProcent();
            }
        }
    }
    private int health;
    private int maxHealth = 100;

    private Mesh HealthMesh;
	// Use this for initialization
	void Start ()
    {
        HealthMesh = this.GetComponentInChildren<Mesh>();
	}
    
    private void ChangeProcent()
    {
    }
}
