using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeslocadorDocil : MonoBehaviour
{
    public float speed, bounceOnEnemy;
    float distance = 1f;
    private bool movingRight = true;

    public Transform groundDetection;
    public Rigidbody2D playerRig;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
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
                Debug.Log("foot");
            }

            if(c.collider.GetType() == typeof(PolygonCollider2D))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Debug.Log("body");
            }
            
        }
    }
}
