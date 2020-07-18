using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacles : MonoBehaviour
{
    private Rigidbody2D PlayerRb;

    void Awake()
    {
        PlayerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        
        if(gameObject.tag == "Player" && c.gameObject.tag == "Honey")
        {
            PlayerRb.mass = 6.0f;
        }
        
    }

    void OnCollisionEnter2D (Collision2D c)
    {
        if (gameObject.tag == "Player" && c.gameObject.tag == "Spikes")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
