using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits_reset : MonoBehaviour
{
    public void ResetCredits()
    {
        GameObject.Find("CreditsList_Content").GetComponent<RectTransform>().transform.localPosition = new Vector3(0, -0.252f, 0);
    }
}
