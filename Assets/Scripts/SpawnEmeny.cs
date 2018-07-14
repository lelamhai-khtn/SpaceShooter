using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEmeny : MonoBehaviour {
    public GameObject enemy;

    float cameraHeight;
    float cameraWidth;
    float widthEnemy;
    float heightEnemy;

    public float MinSpawnTime = 0.2f;
    public float MaxSpawnTime = 1;
    float lastSpawnTime = 0;
    float spawnTime = 0;

    public bool flagBulletControl = false;
    // Use this for initialization
    void Start ()
    {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;
        BoundSizeEnemy();
        updateSpawnTime();
    }

    void updateSpawnTime()
    {
        lastSpawnTime = Time.time;
        spawnTime = Random.Range(MinSpawnTime, MaxSpawnTime);
    }

    private void BoundSizeEnemy()
    {
        widthEnemy = (enemy.GetComponent<SpriteRenderer>().bounds.size.x) / 2;
        heightEnemy = (enemy.GetComponent<SpriteRenderer>().bounds.size.y) / 2;
    }

    // Update is called once per frame
    void Update ()
    {
        enemy.GetComponent<Enemy>().flagBullet = flagBulletControl;

        Vector3 vector3 = setPosSpawn();
        if(Time.time >= lastSpawnTime + spawnTime)
        {
            instantiateEnemy(vector3);
        }
    }
   
    private Vector3 setPosSpawn()
    {
        float randomX = Random.Range(-cameraWidth + widthEnemy, cameraWidth - widthEnemy);
        Vector3 vector3 = new Vector3(randomX, cameraHeight + heightEnemy, transform.position.z);
        return vector3;
    }

    private void instantiateEnemy(Vector3 vector3)
    {
        GameObject emeny = Instantiate(enemy, vector3, transform.rotation);
        updateSpawnTime();
        emeny.transform.parent = transform;
    }
}
