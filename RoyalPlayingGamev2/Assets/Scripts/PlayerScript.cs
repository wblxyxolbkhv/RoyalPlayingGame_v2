using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float Speed = 1000f;
    public LayerMask blockingLayer;


    private BoxCollider2D boxCollider;
    private Rigidbody2D rigidbody;

    private Animator animator;

    private Directions WalkDirection;

	// Use this for initialization
	void Start () {

        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        rigidbody = GetComponent<Rigidbody2D>();

        WalkDirection = Directions.None;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("is_walking", true);
            WalkDirection = Directions.Right;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("is_walking", false);
            WalkDirection = Directions.None;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("is_walking", true);
            WalkDirection = Directions.Left;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("is_walking", false);
            WalkDirection = Directions.None;
        }

        if (WalkDirection!= Directions.None)
            Move(WalkDirection);
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
            rigidbody.MovePosition(end);
        }
    }

    protected IEnumerator SmoothMoment(Vector3 end)
    {
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

        while (sqrRemainingDistance < float.Epsilon)
        {
            Vector3 newPos = Vector3.MoveTowards(rigidbody.position, end, Speed * Time.deltaTime);
            rigidbody.MovePosition(newPos);
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            yield return null;
        }
    }

}
