using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cuspidor : MonoBehaviour
{
    public Transform bulletExit;
    public GameObject bulletPrefabR;
    public GameObject bulletPrefabL;
    public Rigidbody2D playerRig;
    public float shootTime = 0.5f, bounceOnEnemy;
    
    void Awake()
    {
        playerRig = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        InvokeRepeating("Shoot", shootTime, shootTime);
    }

    void Shoot()
    {
        if (transform.localScale.x > 0)
        {
            Instantiate(bulletPrefabR, bulletExit.position, bulletExit.rotation);
        }
        else
        {
            
            Instantiate(bulletPrefabL, bulletExit.position, bulletExit.rotation);
        }
        
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

        }
    }
}
