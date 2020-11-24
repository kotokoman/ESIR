using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levels;
    static bool[] levelcheck;


    void Awake()
    {
        DontDestroyOnLoad(gameObject);


    }

    void Start()
    {
        levels = GameObject.FindGameObjectsWithTag("LevelOptions");
        levelcheck = new bool[levels.Length];
    }

    void Update()
    {
        for (int i = 0; i <= levels.Length; i++)
        {
            if (levelcheck[i] == true)
            {
                levels[i].gameObject.GetComponent<Button>().interactable = true;
            }
        }
    }

    public void UnlockNextLevel(int complete)
    {
        levelcheck[complete] = true;        
    }
}
