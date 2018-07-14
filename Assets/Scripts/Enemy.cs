using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public GameObject bullet;

    public float speed = 4f;
    float cameraHeight;
    float cameraWidth;

    public float MinSpawnTime = 0.2f;
    public float MaxSpawnTime = 1;
    float lastSpawnTime = 0;
    float spawnTime = 0;

    public bool flagBullet = false;
    // Use this for initialization
    void Start ()
    {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;
        updateSpawnTime();
    }

    private void updateSpawnTime()
    {
        lastSpawnTime = Time.time;
        spawnTime = Random.Range(MinSpawnTime, MaxSpawnTime);
    }

    // Update is called once per frame
    void Update ()
    {
        MoveEnemy();
        DestroyEnemy();

        if(Time.time > spawnTime + lastSpawnTime)
        {
            ShooterEnemy();
        }
    }

    private void DestroyEnemy()
    {
        if (transform.position.y <= -cameraHeight)
        {
            Destroy(this.gameObject);
        }
    }

    private void MoveEnemy()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void ShooterEnemy()
    {
        if(flagBullet)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            updateSpawnTime();
        }
    }
}
