using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageble : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Damage(int damage)
    {
        var player = this.GetComponent<PlayerScript>();
        if (player != null)
        {
            player.Damage(damage);
        }
        else
        {
            var enemy = GetComponent<SimpleEnemyScript>();
            if (enemy != null)
            {
                enemy.Damage(damage);
            }
        }
    }
}
