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
        direction = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float playerX = playerTransform.position.x;
        if (Mathf.Abs(playerX - myTransform.position.x) > ((playerTransform.localScale.x / 2.0f) + (myTransform.localScale.x / 2.0f)))
        {
            if (playerX > myTransform.position.x)
            {
                direction.x = 1.0f;
                myTransform.Translate(direction * speed * Time.deltaTime);
            }
            else
            {
                direction.x = -1.0f;
                myTransform.Translate(direction * speed * Time.deltaTime);
            }
        } else if ((playerTransform.position.y - playerTransform.localScale.y / 2.0f) <= (myTransform.position.y + myTransform.localScale.y / 2.0f))
        {
            // Cant destroy player cuz then i will destroy the main camer too, should probably put
            // camera separate and script for following the object
            Debug.Log("Player destroyed!");
        }
    }
   
}
