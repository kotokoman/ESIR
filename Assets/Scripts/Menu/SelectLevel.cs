using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectLevel : MonoBehaviour
{
    private string levelNumber;
    public GameObject confirmText;
    private TextMeshProUGUI mesh_Text;

    private void Awake()
    {
        mesh_Text = confirmText.GetComponent<TextMeshProUGUI>();
    }

    public void GetLevelNumber(GameObject level)
    {
        levelNumber = level.name;
        SetConfirmText(levelNumber);        
    }

    public void SetConfirmText(string text)
    {
        mesh_Text.SetText($"Do you really want to play Level {text}?");
    }
}
