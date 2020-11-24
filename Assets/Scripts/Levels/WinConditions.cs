using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WinConditions : MonoBehaviour
{
    public LevelManager manage;
    public int nextLevel;

    void Start()
    {
        nextLevel = SceneManager.GetActiveScene().buildIndex;
    }
    
    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "Player")
        {
            GameObject.Find("Main Camera").GetComponent<CameraFollow>().enabled = false;
            GameObject.FindGameObjectWithTag("Darkness").GetComponent<DarknessMovement>().speed = 15f;
            
            Invoke("Victory", 3f);
        }
    }

    void Victory()
    {
        SceneManager.LoadScene("Menu");
    }
}
