using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPlane;
    private float min_X, max_X;
    private BoxCollider2D box;

    // Start is called before the first frame update
    /** 
        Calculates the bounds of the collider that will be spawner of the 
        enemy gameobjects. Starts the spawning coroutine.
    */
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        min_X = transform.position.x - box.bounds.size.x / 2f;
        max_X = transform.position.x + box.bounds.size.x / 2f;
        StartCoroutine(StartSpawning()); 
    }

    /** 
        Instantiates an ememy plane gameobject and recalls the StartSpwaning
        coroutine.

        @returns {IEnumerator} returns a time delay of a random range between
        0.5 and 3 seconds.
    */
    IEnumerator StartSpawning()
    {   
        yield return new WaitForSeconds(Random.Range(0.5f, 3f));
        GameObject p = Instantiate(enemyPlane);
        float x = Random.Range(min_X, max_X);
        p.transform.position = new Vector2(x, transform.position.y);
        StartCoroutine(StartSpawning());
    }

    /** 
        Detects collision with the players bullet. If true, destroys the bullet,
        this keeps player bullets from polluting the global space when passing
        the enemy spawner.

        @params {Collider2D} The other Collider2D involved in this collision.
    */
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player Bullet"){
            Destroy(other.gameObject);
        }
    }
}
