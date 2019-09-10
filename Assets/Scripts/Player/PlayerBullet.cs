using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private float force = 6f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /** 
        Detects a collision with the enemy bullet and destroys both this and the
        other gameobject

        @params {Collider2D} The other Collider2D involved in this collision.
    */
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy Bullet"){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
