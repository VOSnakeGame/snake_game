using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionChange : MonoBehaviour {

	public Vector3 direction;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponentInParent<Rigidbody>();
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
}
