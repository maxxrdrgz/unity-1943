using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private float force = -2f;
    private bool canshoot = true;
    [SerializeField]
    private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, force);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Shoot();
    }

    /** 
        Detects collision with the player. If true, both the player and this
        gameobject gets destroyed.

        @params {Collision2D} The Collision2D data associated with this collision.
    */
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }    
    }

    /** 
        Checks the canshoot boolean, and if true, starts the resetshooter()
        coroutine.
    */
    void Shoot(){
        if(canshoot){
            StartCoroutine(ResetShooter());
        }
    }

    /** 
        Instantiates a bullet gameobject and resets the canshoot boolean

        @returns {IEnumerator} returns a time delay of a random range between
        1 and 3 seconds.
    */
    IEnumerator ResetShooter(){
        Vector2 bulletPos = transform.position;
        bulletPos.y -= 0.7f;
        Instantiate(bullet, bulletPos, Quaternion.identity);
        canshoot = false;
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        canshoot = true;
    }

    /** 
        Detects collision with the players bullet. If true, destorys this
        gameobject and the bullet gameobject

        @params {Collider2D} The other Collider2D involved in this collision.
    */
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player Bullet"){
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

}
