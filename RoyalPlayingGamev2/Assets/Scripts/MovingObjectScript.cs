using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectScript : MonoBehaviour {
    
    protected Rigidbody2D rigidbody2d;
    protected Animator animator;
    protected Collider2D collider2d;

    protected Directions WalkDirection;
    protected float move = 0;

    public float Speed = 1000f;
    

    // Use this for initialization
    protected virtual void Start () {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (move != 0)
        {

        }
        if (rigidbody2d.bodyType != RigidbodyType2D.Static)
            rigidbody2d.velocity = new Vector2(move * Speed, rigidbody2d.velocity.y);
        if (move > 0)
        {
            WalkDirection = Directions.Right;
            //transform.localScale = new Vector3(1, 1, 1);
        }
        else if (move < 0)
        {
            WalkDirection = Directions.Left;
            //transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (WalkDirection == Directions.Right)
        {
            WalkDirection = Directions.NoneRight;
            //transform.localScale = new Vector3(1, 1, 1);
        }
        else if (WalkDirection == Directions.Left)
        {
            WalkDirection = Directions.NoneLeft;
            //transform.localScale = new Vector3(-1, 1, 1);
        }
        
    }

}
