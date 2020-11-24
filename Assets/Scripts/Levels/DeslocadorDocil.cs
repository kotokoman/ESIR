using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeslocadorDocil : MonoBehaviour
{
    public float speed, bounceOnEnemy;
    float distance = 5f;
    private bool movingRight = true;

    public Transform groundDetection;
    public Rigidbody2D playerRig;
    

    public void Awake()
    {
        playerRig = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        Debug.DrawRay(groundDetection.transform.position, Vector2.down, Color.green, 5f);
        if(!groundInfo.collider)
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    private void OnCollisionEnter2D (Collision2D c)
    {
        if(c.gameObject.tag == "Player")
        {

            if(c.collider.GetType() == typeof(BoxCollider2D))
            {
                Destroy(gameObject);
                playerRig.AddForce(new Vector2(playerRig.velocity.x, bounceOnEnemy));
               
            }

            if(c.collider.GetType() == typeof(EdgeCollider2D))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<TouchPlayerMov>().AnimationCheck(true);
                
            }
            
        }
        else
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
