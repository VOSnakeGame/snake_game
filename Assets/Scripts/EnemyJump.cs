using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour {

	public float speed;
	Transform myTransform;
	public Transform playerTransform;
	private Vector3 direction;
	private Rigidbody rb;
	private float timer;
	private Vector3 jumpForce;

	// Use this for initialization
	void Start () {
		myTransform = GetComponent<Transform>();
		rb = GetComponent<Rigidbody>();
		playerTransform = GameObject.FindGameObjectsWithTag("Player")[0].transform;
		direction = new Vector3(1, 0, 0);
		timer = 0;
		jumpForce = new Vector3(0f, 15f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		//myTransform.Translate(direction * speed * Time.deltaTime);
		rb.AddForce(direction * speed * Time.deltaTime);

		timer += Time.deltaTime;
		Debug.Log (timer);
		if (timer >= 1.5f) {
			timer = 0;
			jump();
		}
	}

	void OnTriggerEnter(Collider triggerCollider) 
	{
		if (triggerCollider.tag == "Boundary")
		{
			Debug.Log ("Collision!");
			direction.x = -direction.x;
		}

	}

	void jump() {
		rb.AddForce(jumpForce);
	}
}
