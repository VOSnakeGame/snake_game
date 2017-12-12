using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour {

	public float moveForce = 365f;
	private Vector3 direction;
	public Rigidbody rb;
	private float timer;
	public float jumpForce = 20f;
	public float maxSpeed = 10f;
	public float fallMultiplier = 2f;
	public float lowJumpMultiplier = 2.5f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		direction = new Vector3(1, 0, 0);
		timer = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.AddForce(direction * moveForce);

		timer += Time.deltaTime;
		Debug.Log (timer);
		if (timer >= 1.0f) {
			timer = 0;
			jump();
		}

		if (Mathf.Abs(rb.velocity.x) > maxSpeed)
			rb.velocity = new Vector3(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y, 0);
		
		if (rb.velocity.y < 0) {
			rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
		} else {
			rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
		}
		Debug.Log(rb.velocity);
	}

	void OnTriggerEnter(Collider triggerCollider) 
	{
		if (triggerCollider.tag == "Boundary")
		{
			Debug.Log ("Collision!");
			direction.x = -direction.x;
			rb.velocity = new Vector3 (0, rb.velocity.y, 0);
		}

	}

	void jump() {
		Debug.Log("jump");
		rb.AddForce(Vector3.up * jumpForce);
		Debug.Log (rb.velocity);
	}
}
