using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoyalPlayingGame.Units;
using RoyalPlayingGame;
using Assets.Utils;

using RoyalPlayingGamev2.Globals;

namespace RoyalPlayingGamev2.Units
{
    /// <summary>
    /// враг, который просто бегает взад - вперед и наносит урон прикосновением
    /// </summary>
    public class RPGSimpleEnemy : RPGUnit
    {
        public int damage;
        public RPGTurnPoint turnPoint;

        public GameObject greenBar;
        public GameObject blackBar;
        
        // Use this for initialization
        protected override void Start()
        {
            base.Start();
            move = 1;

            // TODO: тестовый кусок дерьма
            unit = new RoyalPlayingGame.Units.Enemy("DBG_carrot", 1000, 10, 10, 10, 10, 10);

            turnPoint.Turn += OnTurn;
            unit.Death += OnEnemyDeath;
        }

        private void OnEnemyDeath(bool obj)
        {
            collider2d.enabled = false;
            turnPoint.Disable();
            rigidbody2d.bodyType = RigidbodyType2D.Static;
            GlobalListener.SomeUnitDeath(unit);
            //animator.SetBool("death", true);
        }

        private void OnTurn(Collider2D collision)
        {
            var damageble = collision.gameObject.GetComponent<RPGUnit>();
            if (damageble != null)
                damageble.GetDamage(damage);
            move = -move;
        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();

            var scale = move > 0 ? 1 : -1;
            transform.localScale = new Vector3(scale, 1, 1);


            int health = unit.Health;
            int maxHealth = unit.MaxHealth;

            greenBar.transform.parent.localScale = new Vector3(
                greenBar.transform.parent.localScale.x * health/maxHealth,
                greenBar.transform.parent.localScale.y,
                greenBar.transform.parent.localScale.z);
        }
        
        private void OnGUI()
        {
            int health = unit.Health;
            int maxHealth = unit.MaxHealth;

            Vector2 pos = Camera.main.WorldToScreenPoint(new Vector2(
                transform.position.x - collider2d.bounds.size.x / 2,
                transform.position.y + collider2d.bounds.size.y / 2 + 0.2f));
            Vector2 size = new Vector2(collider2d.bounds.size.x * Camera.main.PixelsPerUnit(), 3);

            Rect bar = new Rect(pos, size);

            var style = GUI.skin.GetStyle("Label");
            style.normal.background = U_UIManager.blackTexture;
            GUI.Label(bar, GUIContent.none, style);
            bar.width *= (float)health / (float)maxHealth;
            style.normal.background = U_UIManager.greenTexture;
            GUI.Label(bar, GUIContent.none, style);
        }
    }
}