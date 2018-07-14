using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {
    public float speed = 1.5f;
    float cameraHeight;
    float cameraWidth;
    public float widthCloud = 0;
    public float heightCloud = 0;
    
    public bool flagCloud = false;
    public float moveCloud = 0f;

    // Use this for initialization
    void Start () {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;

        widthCloud = (GetComponent<SpriteRenderer>().bounds.size.x) / 2;
        heightCloud = (GetComponent<SpriteRenderer>().bounds.size.y) / 2;
    }
	
	// Update is called once per frame
	void Update ()
    {
        MoveCloud(moveCloud);
        Destroy();
    }

    public void MoveCloud(float x)
    {
        if(flagCloud)
        { 
            transform.position = new Vector3(x, transform.position.y - speed * Time.deltaTime);
        }
    }

    private void Destroy()
    {
        if (transform.position.y < -cameraHeight)
        {
            transform.position = new Vector3(transform.position.x, cameraHeight + heightCloud, transform.position.z);
            flagCloud = false;
            PointSingleton.Instance.Cloud += 1;
        }
    }
}
