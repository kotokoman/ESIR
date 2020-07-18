using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reset_Transform : MonoBehaviour
{
    private void Update()
    {
        T_Reset();
    }

    public void T_Reset()
    {
        this.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        this.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
    }
}