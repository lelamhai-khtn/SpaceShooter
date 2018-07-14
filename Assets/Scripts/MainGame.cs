using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour {
    public SpawnEmeny spawnEnemy;
    public SpawnRooks spawnRooks;
    public SpawnClouds spawnCloud;

    void Update()
    {
        if (PointSingleton.Instance.Point >= 10)
        {
            spawnRooks.flagRooks = true;
        }

        if(PointSingleton.Instance.Point >= 15)
        {
            spawnEnemy.flagBulletControl = true;
        }

        if(PointSingleton.Instance.Point >= 5 )
        {
            spawnCloud.GetComponent<SpawnClouds>().flagSpawn = true;
            switch(PointSingleton.Instance.Point)
            {
                case 8:
                    spawnCloud.GetComponent<SpawnClouds>().UpdateTotal(2);
                    break;
                case 12:
                    spawnCloud.GetComponent<SpawnClouds>().UpdateTotal(3);
                    break;
                case 15:
                    spawnCloud.GetComponent<SpawnClouds>().UpdateTotal(4);
                    break;
            }
        }
    }


}
