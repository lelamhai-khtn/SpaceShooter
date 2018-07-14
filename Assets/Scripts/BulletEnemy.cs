using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour {
    public float speed = 5f;

    float cameraHeight;
    float cameraWidth;

    // Use this for initialization
    void Start () {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;
    }
	
	// Update is called once per frame
	void Update ()
    {
        MoveBullet();
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        if (transform.position.y <= -cameraHeight)
        {
            Destroy(this.gameObject);
        }
    }

    private void MoveBullet()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
