using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour {

    public Transform Target;
    public Transform Edge;
    public float Width;
    public float Height;

    public float Distance;

    private Camera Camera;

	// Use this for initialization
	void Start ()
    {
        Camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Width = Camera.pixelWidth;
        if (transform.position.x + Camera.rect.width / 2 - Target.position.x <= Distance)
            transform.position = new Vector3(Target.position.x - Camera.rect.width/2 + Distance, transform.position.y);
    }
}
