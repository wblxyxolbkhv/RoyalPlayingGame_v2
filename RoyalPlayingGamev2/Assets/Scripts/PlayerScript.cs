using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoyalPlayingGame.Units;

public class PlayerScript : UnitScript {
    

    
    
    // передвижение
    public float jumpForce = 700f;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    private bool grounded = false;



    public bool interactionEnabled = true;


    public LayerMask whereIsTalkers;


    private Player player;



    public float CoolDown;
    private float currentCoolDown;


    // для диалогов
    public GameObject rightFreePoint;


    // Use this for initialization
    protected override void Start () {

        base.Start();

        player = new Player();

        animator = GetComponent<Animator>();

        WalkDirection = Directions.NoneRight;
    }
    protected void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        if (grounded && (Input.GetKey(KeyCode.W)) && interactionEnabled)
        {
            rigidbody2d.AddForce(new Vector2(0f, jumpForce));
        }

        move = 0f;
        if (Input.GetKeyUp(KeyCode.D) && move > 0 || Input.GetKeyUp(KeyCode.A) && move < 0)
            move = 0f;
        if (Input.GetKey(KeyCode.D) && interactionEnabled)
        {
            move = 1f;
        }
        if (Input.GetKey(KeyCode.A) && interactionEnabled)
        {
            move = -1f;
        }
        if (Input.GetKey(KeyCode.Alpha1) && interactionEnabled)
        {
            Cast();
        }
    }
    protected override void Update()
    {
        base.Update();

        currentCoolDown -= Time.deltaTime;
        currentCoolDown = Math.Max(currentCoolDown, 0);

        Vector2 direction = transform.position;

        switch (WalkDirection)
        {
            case Directions.Left:
                animator.SetBool("is_walking_left", true);
                animator.SetBool("is_walking_right", false);
                direction = new Vector2(-1, 0);
                break;
            case Directions.Right:
                animator.SetBool("is_walking_left", false);
                animator.SetBool("is_walking_right", true);
                direction = new Vector2(1, 0);
                break;
            case Directions.NoneRight:
            case Directions.NoneLeft:
                direction = WalkDirection == Directions.NoneLeft ? new Vector2(-1, 0) : new Vector2(1, 0);
                animator.SetBool("is_walking_left", false);
                animator.SetBool("is_walking_right", false);
                break;
        }

        RaycastHit2D hit = Physics2D.Raycast(rightFreePoint.transform.position, direction, 2, whereIsTalkers.value);
        if (hit.collider != null)
        {
            var talker = hit.collider.gameObject.GetComponent<Talker>();
            if (talker != null)
                U_DialogManager.Instance.PotentialTalker = talker;
            else
                U_DialogManager.Instance.PotentialTalker = null;
        }
        else
            U_DialogManager.Instance.PotentialTalker = null;

    }
    
    protected override void Cast()
    {
        if (currentCoolDown > 0)
            return;
        currentCoolDown = CoolDown;
        base.Cast();
    }

    public int GetHealth()
    {
        return player.RealHealth;
    }
    public int GetMaxHealth()
    {
        return player.Health;
    }
    public void Damage(int damage)
    {
        player.GotDamaged(damage, DamageType.Physical);
    }

}
