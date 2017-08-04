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



    //public RoyalPlayingGame.Units.Player player;
    



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
            //Debug.Log("D");
        }
        if (Input.GetKey(KeyCode.A))
        {
            move = -1f;
            //Debug.Log("A");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Cast();
        }
    }
    protected override void Update()
    {
        

        base.Update();


        switch (WalkDirection)
        {
            case Directions.Left:
                animator.SetBool("is_walking_left", true);
                animator.SetBool("is_walking_right", false);
                break;
            case Directions.Right:
                animator.SetBool("is_walking_left", false);
                animator.SetBool("is_walking_right", true);
                break;
            case Directions.NoneRight:
            case Directions.NoneLeft:
                animator.SetBool("is_walking_left", false);
                animator.SetBool("is_walking_right", false);
                break;
        }

    }
    
    protected override void Cast()
    {
        base.Cast();
    }

   

}
