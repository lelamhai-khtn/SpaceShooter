using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRooks : MonoBehaviour {
    public GameObject rook;

    float cameraHeight;
    float cameraWidth;
    float widthRook;
    float heightRook;

    public float MinSpawnTime = 0.4f;
    public float MaxSpawnTime = 4;
    float lastSpawnTime = 0;
    float spawnTime = 0;

    public bool flagRooks = false;
    // Use this for initialization
    void Start()
    {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;
        BoundSizeRook();
        updateSpawnTime();
    }

    private void BoundSizeRook()
    {
        widthRook = (rook.GetComponent<SpriteRenderer>().bounds.size.x) / 2;
        heightRook = (rook.GetComponent<SpriteRenderer>().bounds.size.y) / 2;
    }

    void updateSpawnTime()
    {
        lastSpawnTime = Time.time;
        spawnTime = Random.Range(MinSpawnTime, MaxSpawnTime);
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 vector3 = setPosSpawn();
        if (Time.time >= lastSpawnTime + spawnTime)
        {
            instantiateEnemy(vector3);
        }
    }

    private Vector3 setPosSpawn()
    {
        float randomX = Random.Range(-cameraWidth + widthRook, cameraWidth - widthRook);
        Vector3 vector3 = new Vector3(randomX, cameraHeight + heightRook, transform.position.z);
        return vector3;
    }

    private void instantiateEnemy(Vector3 vector3)
    {
        if (flagRooks)
        {
            GameObject emeny = Instantiate(rook, vector3, transform.rotation);
            updateSpawnTime();
            emeny.transform.parent = transform;
        }
    }
}
