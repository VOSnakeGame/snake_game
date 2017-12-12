using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour {

    public float speed;
    Transform myTransform;
    public Transform playerTransform;
    private Vector3 direction;

    // Use this for initialization
    void Start() {
        myTransform = GetComponent<Transform>();
        playerTransform = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        direction = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
		myTransform.Translate(direction * speed * Time.deltaTime);
    }

	void OnTriggerEnter(Collider triggerCollider) 
	{
		if (triggerCollider.tag == "Boundary")
		{		
			direction.x = -direction.x;
		}

	}
   
}
