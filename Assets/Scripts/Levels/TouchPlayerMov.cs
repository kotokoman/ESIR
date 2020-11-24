using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TouchPlayerMov : MonoBehaviour
{
    //variables
    public float moveSpeed = 30, newPlayerMass, oldPlayerMass;
    private float ScreenWidth;
    private bool isAlive = true;
    private bool isInvulnerable = false;

    public GameObject character;
    public Button buttonR;
    public Button buttonL;
    private Rigidbody2D playerRB;
    public Animator animator;
    
    void Awake()
    {
        ScreenWidth = Screen.width;
        character = GameObject.FindGameObjectWithTag("Player");
        playerRB = character.GetComponent<Rigidbody2D>();
        animator = character.GetComponent<Animator>();
        buttonR = GameObject.Find("ButtonR").GetComponent<Button>();
        buttonL = GameObject.Find("ButtonL").GetComponent<Button>();
        oldPlayerMass = playerRB.mass;

    }

    void FixedUpdate()
    {
        if (isAlive)
        {
            int i = 0;

            while (i < Input.touchCount)
            {
                if (Input.GetTouch(i).position.x > ScreenWidth / 2)
                {
                    //move and turn right
                    RunCharacter(1.0f);
                    character.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

                }
                else if (Input.GetTouch(i).position.x < ScreenWidth / 2)
                {
                    //move and turn left
                    RunCharacter(-1.0f);
                    character.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));

                }

                ++i;
            }

            #if UNITY_EDITOR
            RunCharacter(Input.GetAxis("Horizontal"));
            #endif
        } 
        
        if (isInvulnerable)
        {
            character.GetComponent<BoxCollider2D>().enabled = false;
            character.GetComponent<EdgeCollider2D>().enabled = false;
            playerRB.gravityScale = 0f;
            
        }
       

        AnimationCheck(false);
    }

    private void RunCharacter(float horizontalInput)
    {
        //move player
        playerRB.AddForce((new Vector2(horizontalInput * moveSpeed * Time.deltaTime, 0)), ForceMode2D.Force);
    }

    public void AnimationCheck(bool dead)
    {
        if (playerRB.velocity.y < 0f)
        {
            animator.SetBool("isGrounded", false);
        }
        else if (playerRB.velocity.y == 0f)
        {
            animator.SetBool("isGrounded", true);
        }

        if (playerRB.velocity.x == 0f)
        {
            animator.SetBool("isRunning", false);
        }
        else if (playerRB.velocity.x > 0f || playerRB.velocity.x < 0f)
        {
            animator.SetBool("isRunning", true);
        }

        if (dead == true)
        {
            isAlive = false;
            isInvulnerable = true;
            animator.SetTrigger("isDead");
            Invoke("ResetLevel", 1.3f);
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (gameObject.tag == "Player" && c.gameObject.tag == "Spikes")
        {
            AnimationCheck(true);
        }

        if (gameObject.tag == "Player" && c.gameObject.tag == "StickyPlat")
        {
            animator.speed /= 2;
            playerRB.mass = newPlayerMass;
        }

    }

    void OnCollisionExit2D(Collision2D c)
    {
        if (gameObject.tag == "Player" && c.gameObject.tag == "StickyPlat")
        {
            animator.speed *= 2;
            playerRB.mass = oldPlayerMass;
        }
    }

    void ResetLevel()
    {
        playerRB.gravityScale = 1f;
        isInvulnerable = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    

}