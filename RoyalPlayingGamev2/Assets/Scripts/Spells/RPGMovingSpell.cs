using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoyalPlayingGamev2.Units;
using RoyalPlayingGamev2.Globals;

namespace RoyalPlayingGamev2.Spells
{
    public class RPGMovingSpell : RPGMovingObject
    {

        public int Damage = 10;
        protected GameObject Caster;

        // Use this for initialization
        protected override void Start()
        {
            rigidbody2d = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();

            collider2d = GetComponent<Collider2D>();
        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();

            animator.SetBool("is_launched", true);

        }

        public void Launch(Directions d, GameObject caster)
        {
            Caster = caster;
            switch (d)
            {
                case Directions.Left:
                    move = -1;
                    break;
                case Directions.Right:
                    move = 1;
                    break;
            }
        }
        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject == Caster)
                return;
            var dmgble = collision.gameObject.GetComponent<RPGUnit>();
            if (dmgble != null)
                dmgble.GetDamage(Damage);
            //Destroy(gameObject);
        }
    }
}