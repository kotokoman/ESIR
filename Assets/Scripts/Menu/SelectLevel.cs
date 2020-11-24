using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.PlayerLoop;

public class SelectLevel : MonoBehaviour
{
    public string levelNumber;
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
        mesh_Text.SetText($"Deseja realmente jogar o Level {text}?");
    }

    public void LoadLVL()
    {
        string index = levelNumber;
        SceneManager.LoadScene(index);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
