using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RoyalPlayingGamev2.Spells
{
    public class RPGStaticSpell : RPGMovingSpell
    {

        float destroyTime;

        // Use this for initialization
        protected override void Start()
        {
            Speed = 0;
            animator = GetComponent<Animator>();
            destroyTime = animator.GetCurrentAnimatorStateInfo(0).length;
        }

        // Update is called once per frame
        protected override void Update()
        {
            if (destroyTime < 0)
                Destroy(this.gameObject);
            destroyTime -= Time.deltaTime;
        }
    }
}