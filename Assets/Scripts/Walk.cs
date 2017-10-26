using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour {

    public float speed;
    Transform myTransform;

	// Use this for initialization
	void Start () {
        // Get reference to Transform Component of Game Object
        myTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        // Horizontal axis is left and right arrows
        // Get axis raw means the result can be one of three things: -1, 0 and 1
        // -1 is for left, 1 for right, and 0 if nothing is pressed
        int horizontal = (int) Input.GetAxisRaw("Horizontal");

		if (horizontal != 0) {
            // Move object to left or right
            // Vector3.rigth is [1, 0, 0]
            // We must multiply by Time.delta time to account for time between two frames
            myTransform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);
        }
	}
}
