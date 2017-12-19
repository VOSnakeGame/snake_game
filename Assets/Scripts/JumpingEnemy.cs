using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : MonoBehaviour {

	// Use this for initialization
	Rigidbody rb;
    public float maxSpeed = 5f;
    public float jumpForce = 1f;
    private bool jump = false;
    public float fallMultiplier = 2f;
    private float distToGround;
    private float orientation = 1f;

    void Start () {
        rb = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }
	
	void Update () {
        if (Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f)) {
            jump = true;
        }
    }

    void FixedUpdate() {

        transform.localScale = new Vector3(orientation, 1, 1);

        if (rb.velocity.y < 0) {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        } 

        if (jump) {
            rb.velocity += Vector3.up * jumpForce;
            jump = false;
        }
    }

}
