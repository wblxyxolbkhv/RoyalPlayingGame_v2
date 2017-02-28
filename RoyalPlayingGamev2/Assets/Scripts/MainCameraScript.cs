using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour {

    public Transform Target;
    public Transform LeftEdge;
    public Transform RightEdge;
    public float Width;
    public float Height;

    public float Distance;

    private Camera Camera;
    private float RectWidth;
    private float RectHeight;

    // Use this for initialization
    void Start ()
    {
        Camera = GetComponent<Camera>();
        BoxCollider2D bc2d = Camera.GetComponent<BoxCollider2D>();
        RectWidth = bc2d.bounds.size.x/2;//Camera.orthographicSize * Camera.rect.width;
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x + RectWidth  - Target.position.x <= Distance)
            transform.position = new Vector3(Target.position.x - RectWidth  + Distance, transform.position.y, transform.position.z);
        if (Target.position.x - transform.position.x + RectWidth  <= Distance)
            transform.position = new Vector3(Target.position.x + RectWidth  - Distance, transform.position.y, transform.position.z);

        //Debug.Log(string.Format("X1:{0}, X2:{1}, W:{2}", transform.position.x - RectWidth , Edge.position.x, RectWidth));
        if (transform.position.x - RectWidth  <= LeftEdge.position.x)
            transform.position = new Vector3(LeftEdge.position.x + RectWidth , transform.position.y, transform.position.z);
        if (transform.position.x + RectWidth  >= RightEdge.position.x + Width)
            transform.position = new Vector3(RightEdge.position.x + Width - RectWidth , transform.position.y, transform.position.z);
    }
}
