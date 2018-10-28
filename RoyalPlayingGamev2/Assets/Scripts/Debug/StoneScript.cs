using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScript : MonoBehaviour {


    public GameObject Prefab;

    private Camera Camera;
	// Use this for initialization
	void Start () {
        Camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1))
        {
            GameObject obj = Instantiate(Prefab);
            Vector3 p = Camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
            obj.transform.position = new Vector3(p.x, p.x, 0.5f);
        }
	}
}
