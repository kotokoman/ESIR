using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Behaviors : MonoBehaviour
{
    public float rotationSpeed = 1.0f, stunTime = 0.7f;
    private float oldPlayerMass;
    private Rigidbody2D playerRig;
    private Animator animator;

    private void Start()
    {
        playerRig = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    IEnumerator Countdown(float maxTime)
    {
        float timeCount = 0;
        oldPlayerMass = playerRig.mass;

        playerRig.mass = 50f;
        animator.speed = 0f;

        while (timeCount < maxTime)
        {
            timeCount += Time.deltaTime;
            yield return null;
        }

        animator.speed = 1f;
        playerRig.mass = oldPlayerMass;
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
        if(gameObject.tag == "StunPlat" && c.gameObject.tag == "Player")
        {
            StartCoroutine("Countdown", stunTime);
        }
    }
}
