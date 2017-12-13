using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public int sarmaCounter;
    public bool goal;

    public Animator animator;
    private float orientation = 1f;

    void Start () {
        rb = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
        sarmaCounter = 0;
        goal = false;
    }
	
	void Update () {
        if (Input.GetButtonDown("Jump") && Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f)) {
            jump = true;
        }
    }

    void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");

        if (h != 0) {
            orientation = Mathf.Sign(h);
        }

        transform.localScale = new Vector3(orientation, 1, 1);

        animator.SetBool("Walk", rb.velocity.x != 0);

        if (h * rb.velocity.x < maxSpeed)
            rb.AddForce(Vector3.right * h * moveForce);

        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
            rb.velocity = new Vector3(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y, 0);

        if (rb.velocity.y < 0) {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        } else {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
        }

        animator.SetBool("Walk", rb.velocity.x != 0);

        if (jump) {
            rb.velocity += Vector3.up * jumpForce;
            jump = false;
        }
    }

    void OnCollisionEnter(Collision collision) {
     
        if (collision.collider.tag == "Kills") {           
            rb.constraints = RigidbodyConstraints.FreezeAll;
            OpenGameOver();
        }

        if (collision.collider.tag == "Goal") {  
            if (goal) {
                SceneManager.LoadScene("Lvls", LoadSceneMode.Single);
            }
        }
    }

    void OnTriggerEnter(Collider triggerCollider) 
    {
        Debug.Log(triggerCollider.tag);
        if (triggerCollider.tag == "kupus" || triggerCollider.tag == "mljeveno meso"
            || triggerCollider.tag == "spek" || triggerCollider.tag == "luk")
        {
            // write that i collected it
            Destroy (triggerCollider.gameObject);
            sarmaCounter++;        
            if (sarmaCounter == 4) {
               goal = true;
            }
        }

    }

    public void OpenGameOver() {
        FindObjectOfType<ManageGame>().OnGameOver();
    }

}
