using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    // Start is called before the first frame update
    /** 
        Destroys all gameobjects that collide.

        @params {Collider2D} The other Collider2D involved in this collision.
    */
    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(other.gameObject);
    }
}
