using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;
    [SerializeField]
    private GameObject bullet;
    private bool canshoot = true;

    // Update is called once per frame
    /** 
        Gets input from player and moves them left or right, also calls the
        Shoot function
    */
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");   
        if(h > 0){
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;
        }
        if(h<0){
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;
        }
        Shoot();
    }

    /** 
        Checks the canshoot boolean and detects input from the player, starts
        the resetshooter coroutine if canshoot and player pressed the spacebar
    */
    void Shoot(){
        if(canshoot){
            if(Input.GetKeyDown(KeyCode.Space)){
                StartCoroutine(ResetShooter());
            }
        }
    }

    /** 
        Instantiates a bullet gameobject and resets the canshoot boolean

        @returns {IEnumerator} returns a time delay of 0.3 seconds
    */
    IEnumerator ResetShooter(){
        Vector2 bulletPos = transform.position;
        bulletPos.y += 0.5f;
        Instantiate(bullet, bulletPos, Quaternion.identity);
        canshoot = false;
        yield return new WaitForSeconds(0.3f);
        canshoot = true;
    }

    /** 
        Detects a collision with the enemy bullet or the enemy and destroys this
        gameobject and reloads the current acive scene.

        @params {Collider2D} The other Collider2D involved in this collision.
    */
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Enemy Bullet"){
            Destroy(gameObject);
            Destroy(other.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
