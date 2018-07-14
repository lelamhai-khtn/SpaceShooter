using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public GameObject enemyEffect;
    public GameObject enemyBang;

    public float speed = 4f;
    float cameraHeight = 0;
    float cameraWidth = 0;
    // Use this for initialization
    void Start()
    {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        DestroyBullet();
    }

    private void Move()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void DestroyBullet()
    {
        if(cameraHeight < transform.position.y)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Enemy"))
        {
            SoundManagerScript.playSoundEnemy();
            PointSingleton.Instance.Point += 1;

            Instantiate(enemyEffect, transform.position, Quaternion.identity);
            // Destroy enemy
            Destroy(collision.gameObject);
            // Destroy bullet player
            Destroy(this.gameObject);
        } else if(collision.tag.Equals("Rook") || collision.tag.Equals("BulletEnemy"))
        {
            SoundManagerScript.playSoundRook();
            Instantiate(enemyBang, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            // Destroy bullet player
            Destroy(this.gameObject);
        }
    }
}
