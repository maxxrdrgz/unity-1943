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
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        min_X = transform.position.x - box.bounds.size.x / 2f;
        max_X = transform.position.x + box.bounds.size.x / 2f;
        StartCoroutine(StartSpawning()); 
    }

    IEnumerator StartSpawning()
    {   
        yield return new WaitForSeconds(Random.Range(0.5f, 3f));
        GameObject p = Instantiate(enemyPlane);
        float x = Random.Range(min_X, max_X);
        p.transform.position = new Vector2(x, transform.position.y);
        StartCoroutine(StartSpawning());
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player Bullet"){
            Destroy(other.gameObject);
        }
    }
}
