using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CuspidorProjectile : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody2D rb;
    
    void Start()
    {
        rb.velocity = transform.right * speed * Time.fixedDeltaTime;
    }

   void OnTriggerEnter2D(Collider2D c)
   {
        if (c.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (c.gameObject.tag == "Boundaries" || c.gameObject.tag == "Plataform" || c.gameObject.tag == "Corrupt" || c.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
   }
}
