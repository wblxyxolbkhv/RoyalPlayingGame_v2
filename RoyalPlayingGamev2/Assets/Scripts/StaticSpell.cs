using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSpell : MovingSpellScript {

    float destroyTime;

	// Use this for initialization
	protected override void Start () {
        Speed = 0;
        animator = GetComponent<Animator>();
        destroyTime = animator.GetCurrentAnimatorStateInfo(0).length;
    }

    // Update is called once per frame
    protected override void Update ()
    {
        if (destroyTime < 0)
            Destroy(this.gameObject);
        destroyTime -= Time.deltaTime;
	}
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Caster)
            return;
        var dmgble = collision.gameObject.GetComponent<Damageble>();
        if (dmgble != null)
            dmgble.Damage(Damage);
    }
}
