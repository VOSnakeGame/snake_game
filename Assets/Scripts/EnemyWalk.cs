using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour {

    public float speed;
    Transform myTransform;
    private Vector3 direction;

    // Use this for initialization
    void Start() {
        myTransform = GetComponent<Transform>();
        direction = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
		myTransform.Translate(direction * speed * Time.deltaTime);
        myTransform.localScale = new Vector3(direction.x, 1, 1);
    }

	void OnTriggerEnter(Collider triggerCollider) 
	{
		if (triggerCollider.tag == "Boundary")
		{		
			direction.x = -direction.x;
		}

	}
   
}
