using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody rb;
    public Transform bottom;

    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;

    private bool jump = false;

    public float fallMultiplier = 2f;
    public float lowJumpMultiplier = 2.5f;

    private float distToGround;

    void Start () {
        rb = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }
	
	void Update () {
        if (Input.GetButtonDown("Jump") && Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f)) {
            jump = true;
        }
    }

    void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");

        if (h * rb.velocity.x < maxSpeed)
            rb.AddForce(Vector3.right * h * moveForce);

        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
            rb.velocity = new Vector3(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y, 0);

        if (rb.velocity.y < 0) {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        } else {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
        }
        
        if (jump) {
            rb.velocity += Vector3.up * jumpForce;
            jump = false;
        }
    }

}
