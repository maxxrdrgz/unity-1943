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

    void Shoot(){
        if(canshoot){
            if(Input.GetKeyDown(KeyCode.Space)){
                StartCoroutine(ResetShooter());
            }
        }
    }

    IEnumerator ResetShooter(){
        Vector2 bulletPos = transform.position;
        bulletPos.y += 0.5f;
        Instantiate(bullet, bulletPos, Quaternion.identity);
        canshoot = false;
        yield return new WaitForSeconds(0.3f);
        canshoot = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Enemy Bullet"){
            Destroy(gameObject);
            Destroy(other.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
