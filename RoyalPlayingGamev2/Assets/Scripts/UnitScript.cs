using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoyalPlayingGame;

public class UnitScript : MovingObjectScript {

    public GameObject defaultSpell;

    public string Name = "";

	// Use this for initialization
	protected override void Start () {
        base.Start();

        var quest = new DebugQuest();
        quest.LoadQuest(null);
        QuestManager.QuestRepository.Add(quest);
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

            switch (WalkDirection)
            {
                case Directions.Left:
                case Directions.NoneLeft:
                    spell.transform.position = new Vector3(transform.position.x - 0.7f, transform.position.y, transform.position.z);
                    spell.transform.localScale = new Vector3(-1, 1, 1);
                    spell.GetComponent<MovingSpellScript>().Launch(Directions.Left, gameObject);
                    break;
                case Directions.Right:
                case Directions.NoneRight:
                    spell.transform.position = new Vector3(transform.position.x + 0.7f, transform.position.y, transform.position.z);
                    spell.GetComponent<MovingSpellScript>().Launch(Directions.Right, gameObject);
                    break;
            }
        }
        else
        {

        }
    }
}
