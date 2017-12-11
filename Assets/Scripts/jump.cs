using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour {

    public Vector3 direction;
    public float speed;
    public bool letJump;
    public Transform target;
    public Rigidbody rigidbody;


    // Use this for initialization
    void Start()
    {
        speed = 500.0f;
        letJump = false;
        direction = new Vector3(0, 1, 0);
        target = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

    }

    void Jump()
    {
        if (letJump)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rigidbody.AddForce(direction * speed);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "No jump")
        {
            letJump = false;
        }

        if (collision.gameObject.tag != "No jump")
        {
            letJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        letJump = false;
    }
}
