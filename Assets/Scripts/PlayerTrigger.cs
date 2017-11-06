using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour {
    
    void OnTriggerEnter(Collider triggerCollider) 
    {
        if (triggerCollider.tag == "kupus" || triggerCollider.tag == "mljeveno meso"
            || triggerCollider.tag == "spek" || triggerCollider.tag == "luk")
        {
            Destroy (triggerCollider.gameObject);
        }

        if (triggerCollider.tag == "enemy")
        {
            Destroy(this);
        }

    }

}
