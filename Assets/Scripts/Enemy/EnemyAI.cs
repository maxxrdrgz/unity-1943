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
//        GetComponent<Rigidbody2D>().velocity = new Vector2(0, force);
        Shoot();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }    
    }

    void Shoot(){
        if(canshoot){
            StartCoroutine(ResetShooter());
        }
    }

    IEnumerator ResetShooter(){
        Vector2 bulletPos = transform.position;
        bulletPos.y -= 0.7f;
        Instantiate(bullet, bulletPos, Quaternion.identity);
        canshoot = false;
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        canshoot = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player Bullet"){
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

}
