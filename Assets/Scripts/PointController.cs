using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour {
    private Text pointUI;
	// Use this for initialization
	void Start () {
        pointUI = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        pointUI.text = "Point: " + PointSingleton.Instance.Point.ToString();
	}
}
