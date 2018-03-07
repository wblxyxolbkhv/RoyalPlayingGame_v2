using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using RoyalPlayingGame;

public class PlayerScript : UnitScript {
    

    
    
    
    public float jumpForce = 700f;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    private bool grounded = false;








    // префаб для каста
    public GameObject fireball;



    public GameObject rightFreePoint;


    // Use this for initialization
    protected override void Start () {

        base.Start();

        animator = GetComponent<Animator>();

        WalkDirection = Directions.NoneRight;
    }
    protected void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        if (grounded && (Input.GetKeyDown(KeyCode.W)))
        {
            rigidbody2d.AddForce(new Vector2(0f, jumpForce));
        }

        move = 0f;
        if (Input.GetKeyUp(KeyCode.D) && move > 0 || Input.GetKeyUp(KeyCode.A) && move < 0)
            move = 0f;
        if (Input.GetKey(KeyCode.D))
        {
            move = 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            move = -1f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Cast();
        }
    }
    protected override void Update()
    {
        base.Update();

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

        RaycastHit2D hit = Physics2D.Raycast(rightFreePoint.transform.position, direction, 4);
        if (hit.collider != null)
        {
            var talker = hit.collider.gameObject.GetComponent<Talker>();
            if (talker != null)
                DialogManager.Instance.PotentialTalker = talker;
            else
                DialogManager.Instance.PotentialTalker = null;
        }
        else
            DialogManager.Instance.PotentialTalker = null;

    }
    
    protected override void Cast()
    {
        base.Cast();
    }

   

}
