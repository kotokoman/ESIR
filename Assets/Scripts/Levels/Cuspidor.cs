using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cuspidor : MonoBehaviour
{
    public Transform bulletExit;
    public GameObject bulletPrefab;
    public Rigidbody2D playerRig;
    public float shootTime = 0.5f, bounceOnEnemy;
    
    void Start()
    {
        InvokeRepeating("Shoot", shootTime, shootTime);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletExit.position, bulletExit.rotation);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {

            if (c.collider.GetType() == typeof(BoxCollider2D) && gameObject.GetComponent<Collider2D>().GetType() == typeof(CircleCollider2D))
            {
                Destroy(gameObject);
                playerRig.AddForce(new Vector2(playerRig.velocity.x, bounceOnEnemy));
                
            }

            if (c.collider.GetType() == typeof(BoxCollider2D) && GetComponent<Collider2D>().GetType() == typeof(BoxCollider2D))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
               
            }

        }
    }
}
