using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class ProgressionSlider : MonoBehaviour
{
    public GameObject[] limits;
    public GameObject player;
    public Slider progression;
    
    void Awake()
    {
        limits = GameObject.FindGameObjectsWithTag("Limits");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        progression.minValue = limits[0].transform.position.y *-1;
        progression.maxValue = limits[1].transform.position.y *-1;
    }

   void Update()
   {
        progression.value = player.transform.position.y *-1;
   }
}
