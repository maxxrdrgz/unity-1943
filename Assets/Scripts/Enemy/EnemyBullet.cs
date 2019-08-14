using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float force = -6f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, force);
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}
