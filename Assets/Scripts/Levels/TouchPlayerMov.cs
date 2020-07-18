using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchPlayerMov : MonoBehaviour
{
    //variables
    public float moveSpeed = 300;
    private float ScreenWidth;

    public GameObject character;
    public Button buttonR;
    public Button buttonL;
    private Rigidbody2D characterBody;
    
    void Start()
    {
        ScreenWidth = Screen.width;
        characterBody = character.GetComponent<Rigidbody2D>();
        buttonR = GameObject.Find("ButtonR").GetComponent<Button>();
        buttonL = GameObject.Find("ButtonL").GetComponent<Button>();

    }

    void FixedUpdate()
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

    private void RunCharacter(float horizontalInput)
    {
        //move player
        characterBody.AddForce((new Vector2(horizontalInput * moveSpeed * Time.deltaTime, 0)), ForceMode2D.Force);
    }

    
}