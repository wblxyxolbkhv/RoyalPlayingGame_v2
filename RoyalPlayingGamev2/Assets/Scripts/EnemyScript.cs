using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoyalPlayingGame.Units;

public class EnemyScript : UnitScript {

    public UnitScript target;
    public float agressiveDistanse = 5f;
    public Vector3 patrolPoint = new Vector3(-100,-100);
    public float patrolRadius = 5f;


    public Transform eyes;

    private Enemy enemy = new Enemy();


    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        if (patrolPoint.x == -100 && patrolPoint.y == -100)
            patrolPoint = transform.position;

        move = 1f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        MakeDecision();

        if (move < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
    }

    protected virtual void MakeDecision()
    {
        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach (Collider2D c in colliders) { c.enabled = false; }
        RaycastHit2D r = Physics2D.Raycast(eyes!=null?eyes.position:transform.position, target.gameObject.transform.position);
        foreach (Collider2D c in colliders) { c.enabled = true; }

        // отладочный костыль
        GetComponent<LineRenderer>().SetPositions(new Vector3[] { eyes.position, target.gameObject.transform.position });

        GetComponent<BoxCollider2D>().enabled = true;
        if (r.collider== null)
            return;
        if (r.distance >= agressiveDistanse)
            Patrol();
        else
            Haunt();
    }

    protected virtual void Patrol()
    {
        if (Mathf.Abs(transform.position.x - patrolPoint.x) > patrolRadius )
        {
            if (move > 0 && patrolPoint.x < transform.position.x)
                move = -move;
            if (move < 0 && patrolPoint.x > transform.position.x)
                move = -move;
        }
    }
    protected virtual void Haunt()
    {
        if (Mathf.Abs(transform.position.x - target.gameObject.transform.position.x) > agressiveDistanse )
        {
            if (move > 0 && target.gameObject.transform.position.x < transform.position.x)
                move = -move;
            if (move < 0 && target.gameObject.transform.position.x > transform.position.x)
                move = -move;
        }
    }
    protected virtual void Attack()
    {

    }
}
