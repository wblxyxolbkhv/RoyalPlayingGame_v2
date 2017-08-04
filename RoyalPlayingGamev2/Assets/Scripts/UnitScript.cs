using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MovingObjectScript {

    public GameObject defaultSpell;

	// Use this for initialization
	protected override void Start () {
        base.Start();
	}

    // Update is called once per frame
    protected override void Update () {
        base.Update();
	}

    protected virtual void Cast()
    {
        if (defaultSpell != null)
        {
            GameObject spell = Instantiate(defaultSpell);
            spell.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            switch (WalkDirection)
            {
                case Directions.Left:
                case Directions.NoneLeft:
                    spell.transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
                    spell.transform.localScale = new Vector3(-1, 1, 1);
                    spell.GetComponent<MovingSpellScript>().Launch(Directions.Left);
                    break;
                case Directions.Right:
                case Directions.NoneRight:
                    spell.transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
                    spell.GetComponent<MovingSpellScript>().Launch(Directions.Right);
                    break;
            }
        }
        else
        {

        }
    }
}
