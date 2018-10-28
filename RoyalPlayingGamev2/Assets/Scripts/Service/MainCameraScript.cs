using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour {

    public Transform Target;
    public Transform LeftEdge;
    public Transform RightEdge;
    public Transform DownEdge;
    public Transform UpEdge;
    public float Width;
    public float Height;

    public float DistanceX;
    public float DistanceY;

    private Camera Camera;
    private float RectWidth;
    private float RectHeight;

    // Use this for initialization
    void Start ()
    {
        Camera = GetComponent<Camera>();
        BoxCollider2D bc2d = Camera.GetComponent<BoxCollider2D>();
        RectWidth = bc2d.bounds.size.x / 2;
        RectHeight = bc2d.bounds.size.y / 2;

    }

    // Update is called once per frame
    void Update ()
    {
        if (transform.position.x + RectWidth  - Target.position.x <= DistanceX)
            transform.position = new Vector3(Target.position.x - RectWidth  + DistanceX, transform.position.y, transform.position.z);
        if (Target.position.x - transform.position.x + RectWidth  <= DistanceX)
            transform.position = new Vector3(Target.position.x + RectWidth  - DistanceX, transform.position.y, transform.position.z);

        if (transform.position.y + RectHeight - Target.position.y <= DistanceY)
            transform.position = new Vector3(Target.position.x, transform.position.y - RectHeight + DistanceY, transform.position.z);
        if (Target.position.y - transform.position.y + RectHeight <= DistanceY)
            transform.position = new Vector3(Target.position.x, transform.position.y + RectHeight - DistanceY, transform.position.z);



        if (transform.position.x - RectWidth  <= LeftEdge.position.x)
            transform.position = new Vector3(LeftEdge.position.x + RectWidth , transform.position.y, transform.position.z);
        if (transform.position.x + RectWidth  >= RightEdge.position.x + Width)
            transform.position = new Vector3(RightEdge.position.x + Width - RectWidth , transform.position.y, transform.position.z);

        if (transform.position.y - RectHeight <= DownEdge.position.y)
            transform.position = new Vector3(transform.position.x, DownEdge.position.y + RectHeight, transform.position.z);
        if (transform.position.y + RectHeight >= UpEdge.position.y + Height)
            transform.position = new Vector3(transform.position.x, UpEdge.position.y + Height - RectHeight, transform.position.z);

    }
}
