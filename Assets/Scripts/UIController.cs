using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
    public GameObject panelMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PauseGame()
    {
        Time.timeScale = 0;
        panelMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        panelMenu.SetActive(false);
    }

    public void QuitGame()
    {
        PointSingleton.Instance.Point = 0;
        PointSingleton.Instance.Cloud = 0;
        Application.LoadLevel("Menu");
    }

    public void StartGame()
    {
        PointSingleton.Instance.Cloud = 0;
        PointSingleton.Instance.Point = 0;
        Time.timeScale = 1f;
        Application.LoadLevel("SampleScene");
    }
}
