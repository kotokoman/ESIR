using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Behaviors : MonoBehaviour
{
    public float rotationSpeed, stunTime = 0.7f;
    private float playerMass;
    private Rigidbody2D playerRig;

    private void Start()
    {
        playerRig = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    IEnumerator Countdown(float maxTime)
    {
        float timeCount = 0;
        playerMass = playerRig.mass;

        playerRig.mass = 50f;

        while (timeCount < maxTime)
        {
            timeCount += Time.deltaTime;
            yield return null;
        }

        playerRig.mass = playerMass;
    }

    private void FixedUpdate()
    {
        if(gameObject.name == "rotateClock")
        {
            rotateClock();
        }
        else if (gameObject.name == "rotateAntiClock")
        {
            rotateAntiClock();
        }
        
    }
    
    public void rotateClock()
    {
        transform.Rotate(Vector3.forward, -rotationSpeed);         
    }

    public void rotateAntiClock()
    {
        transform.Rotate(Vector3.forward, rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if(gameObject.tag == "Corrupt" && c.gameObject.tag == "Player")
        {
            StartCoroutine("Countdown", stunTime);
        }
    }
   
}
