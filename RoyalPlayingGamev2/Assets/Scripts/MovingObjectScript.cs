using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private void Update()
    {
        /*
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
        */
    }

}
