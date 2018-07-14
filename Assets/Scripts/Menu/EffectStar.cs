using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectStar : MonoBehaviour {
    private float cameraHeight;
    private float cameraWidth;

    // Use this for initialization
    void Start () {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;

        transform.position = new Vector3(cameraWidth, transform.position.y, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
