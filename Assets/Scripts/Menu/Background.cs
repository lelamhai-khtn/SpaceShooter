using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    private double worldScreenHeight;
    private double worldScreenWidth;

    // Use this for initialization
    void Start () {
        var sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;
        double width = sr.sprite.bounds.size.x;
        double height = sr.sprite.bounds.size.y;
        worldScreenHeight = Camera.main.orthographicSize * 2.0;
        worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
        transform.localScale = new Vector3((float) (worldScreenWidth / width),(float) (worldScreenHeight / height), 1);
        
    }


	
	// Update is called once per frame
	void Update () {
		
	}
}
