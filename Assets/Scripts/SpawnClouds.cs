using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClouds : MonoBehaviour
{
    public Cloud[] listCloud;
    public ArrayList listPosCloud = new ArrayList();
    float cameraHeight;
    float cameraWidth;
    private float widthCloud;
    private float heightCloud;
    public int total = 1;
    public int totalUpdate = 1;

    public bool flagSpawn = false;
    // Use this for initialization
    void Start()
    {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;
        widthCloud = listCloud[listCloud.Length - 1].GetComponent<SpriteRenderer>().bounds.size.x;
        heightCloud = listCloud[listCloud.Length - 1].GetComponent<SpriteRenderer>().bounds.size.y;
        // set position start
        transform.position = new Vector3(transform.position.x, cameraHeight + heightCloud, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        if (flagSpawn)
        {
            if (PointSingleton.Instance.Cloud == total)
            {
                StartCoroutine(PermissionRun());
                PointSingleton.Instance.Cloud = 0;
            }
        } else
        {
            PointSingleton.Instance.Cloud = total;
        }
    }

    IEnumerator PermissionRun()
    {
        for (int i = 0; i < total; i++)
        {
            yield return new WaitForSeconds(2f);
            float x = Random.Range(-cameraWidth + widthCloud, cameraWidth - widthCloud);
            listCloud[i].GetComponent<Cloud>().moveCloud = x;
            listCloud[i].GetComponent<Cloud>().flagCloud = true;
        }
    }

    public void UpdateTotal(int newTotal)
    {
        PointSingleton.Instance.Cloud = PointSingleton.Instance.Cloud + (newTotal - total);
        total = newTotal;
    }
}
