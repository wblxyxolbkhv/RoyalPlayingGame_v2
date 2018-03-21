using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSpellScript : MovingObjectScript {

    public int Damage = 10;

    // Use this for initialization
    protected override void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        collider2d = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    protected override void Update () {
        base.Update();
        
        animator.SetBool("is_launched", true);
        
    }

    public void Launch(Directions d)
    {
        switch(d)
        {
            case Directions.Left:
                move = -1;
                break;
            case Directions.Right:
                move = 1;
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        var dmgble = collision.gameObject.GetComponent<Damageble>();
        if (dmgble != null)
            dmgble.Damage(Damage);
    }
}
