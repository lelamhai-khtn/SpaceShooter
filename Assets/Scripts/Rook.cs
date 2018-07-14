using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : MonoBehaviour {
    public float speed = 5f;
    float cameraHeight;
    float cameraWidth;
    // Use this for initialization
    void Start () {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;
    }
	
	// Update is called once per frame
	void Update () {
        MoveRook();
        Destroy();
    }

    private void Destroy()
    {
        if (transform.position.y < -cameraHeight)
        {
            Destroy(this.gameObject);
        }
    }

    private void MoveRook()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
