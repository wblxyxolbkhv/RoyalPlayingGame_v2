using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoyalPlayingGame.Units;
using Assets.Utils;

/// <summary>
/// враг, который просто бегает взад - вперед и наносит урон прикосновением
/// </summary>
public class SimpleEnemyScript : MovingObjectScript
{
    public int damage;
    public TurnPointScript turnPoint;

    private Unit enemy = new RoyalPlayingGame.Units.Enemy(100, 10, 10, 10, 1, 1);

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        move = 1;

        turnPoint.Turn += OnTurn;
        enemy.Death += OnEnemyDeath;
    }

    private void OnEnemyDeath(bool obj)
    {
        collider2d.enabled = false;
        turnPoint.Disable();
        rigidbody2d.bodyType = RigidbodyType2D.Static;
        animator.SetBool("death", true);
    }

    private void OnTurn(Collider2D collision)
    {
        var damageble = collision.gameObject.GetComponent<Damageble>();
        if (damageble != null)
            damageble.Damage(damage);
        move = -move;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        var scale = move > 0 ? 1 : -1;
        transform.localScale = new Vector3(scale, 1, 1);
        
    }

    public void Damage(int damage)
    {
        enemy.GotDamaged(damage, DamageType.Physical);
    }

    private void OnGUI()
    {
        int health = enemy.RealHealth;
        int maxHealth = enemy.Health;

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
