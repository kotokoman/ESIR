using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DarknessMovement : MonoBehaviour
{

    public float speed = 0.2f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(0, transform.position.y - speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<TouchPlayerMov>().moveSpeed = 0f;
            GameObject.Find("Main Camera").GetComponent<CameraFollow>().enabled = false;
            speed = 15f;
            Invoke("SceneReset", 3f);
        }
        else
        {
            Destroy(c.gameObject);
        }
    }

    void SceneReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
