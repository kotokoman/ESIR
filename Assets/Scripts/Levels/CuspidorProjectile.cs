using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CuspidorProjectile : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody2D rb;
    public GameObject cuspidor;
    
    void Start()
    {
        if(cuspidor.transform.localScale.x > 0)
        {
            rb.velocity = transform.right * speed * Time.fixedDeltaTime;
        }
        else
        {
            rb.velocity = -transform.right * speed * Time.fixedDeltaTime;
        }
    }

   private void OnTriggerEnter2D (Collider2D c)
   {
        if (c.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<TouchPlayerMov>().AnimationCheck(true);
        }
   }
}
