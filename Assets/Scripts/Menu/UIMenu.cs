using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    public void StartGame()
    {
        Time.timeScale = 1;
        Application.LoadLevel("SampleScene");
    }

    public void ShopGame()
    {
        Application.LoadLevel("Shop");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
