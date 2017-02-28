using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float Speed = 1000f;
    public LayerMask blockingLayer;


    private BoxCollider2D boxCollider;
    private Rigidbody2D rigidbody2d;

    private Animator animator;
    
    public float jumpForce = 700f;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    private Directions WalkDirection;
    private float move;
    private bool grounded = false;

    // Use this for initialization
    void Start () {

        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        rigidbody2d = GetComponent<Rigidbody2D>();

        WalkDirection = Directions.NoneRight;
    }
    void FixedUpdate()
    {


        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        //if (!Input.GetKeyDown(KeyCode.D) && WalkDirection == Directions.Right)
        //    move = 0f;
        //if (!Input.GetKeyDown(KeyCode.A) && WalkDirection == Directions.Left)
            move = 0f;
        if (Input.GetKeyUp(KeyCode.D) && move > 0 || Input.GetKeyUp(KeyCode.A) && move < 0)
            move = 0f;
        if (Input.GetKey(KeyCode.D))
            move = 1f;
        if (Input.GetKey(KeyCode.A))
            move = -1f;

    }
    private void Update()
    {
        if (grounded && (Input.GetKeyDown(KeyCode.W)))
        {
            rigidbody2d.AddForce(new Vector2(0f, jumpForce));
        }
        rigidbody2d.velocity = new Vector2(move * Speed, rigidbody2d.velocity.y);
        if (move > 0)
            WalkDirection = Directions.Right;
        else if (move < 0)
            WalkDirection = Directions.Left;
        else if (WalkDirection == Directions.Right)
            WalkDirection = Directions.NoneRight;
        else if (WalkDirection == Directions.Left)
            WalkDirection = Directions.NoneLeft;

        switch (WalkDirection)
        {
            case Directions.Left:
                //Debug.Log("Left");
                animator.SetBool("is_walking_left", true);
                animator.SetBool("is_walking_right", false);
                break;
            case Directions.Right:
                //Debug.Log("Right");
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

    private void Move(Directions d)
    {
        RaycastHit2D hit;
        Vector2 start = transform.position;
        Vector2 end = start;
        switch (d)
        {
            case Directions.Left:
                end = start + new Vector2(-Speed * Time.deltaTime, 0);
                break;
            case Directions.Right:
                end = start + new Vector2(Speed * Time.deltaTime, 0);
                break;
        }

        

        boxCollider.enabled = false;
        hit = Physics2D.Linecast(start, end, blockingLayer);
        boxCollider.enabled = true;

        if (hit.transform == null)
        {
            //StartCoroutine(SmoothMoment(end));
            //rigidbody.MovePosition(end);
        }
    }

    void Flip(Directions d)
    {
        Debug.Log("Flip");
        WalkDirection = d;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    //protected IEnumerator SmoothMoment(Vector3 end)
    //{
    //    float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

    //    while (sqrRemainingDistance < float.Epsilon)
    //    {
    //        Vector3 newPos = Vector3.MoveTowards(rigidbody.position, end, Speed * Time.deltaTime);
    //        rigidbody.MovePosition(newPos);
    //        sqrRemainingDistance = (transform.position - end).sqrMagnitude;
    //        yield return null;
    //    }
    //}

}
