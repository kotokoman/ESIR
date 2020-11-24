using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void LoadLVL0()
    {
        SceneManager.LoadScene("0");
    }
    public void LoadLVL1()
    {
        SceneManager.LoadScene("1");
    }
    public void LoadLVL2()
    {
        SceneManager.LoadScene("2");
    }
    public void LoadLVL3()
    {
        SceneManager.LoadScene("3");
    }
    public void LoadLVL4()
    {
        SceneManager.LoadScene("4");
    }
    public void LoadLVL5()
    {
        SceneManager.LoadScene("5");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
