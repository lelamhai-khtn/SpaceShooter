using UnityEngine;
using System.Collections;

public class PointSingleton
{
    private static PointSingleton instance;
    private PointSingleton() { }

    public static PointSingleton Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new PointSingleton();
            }
            return instance;
        }
    }

    private int point;
    public int Point
    {
        get
        {
            return point;
        }

        set
        {
            point = value;
        }
    }

    private int cloud;
    public int Cloud
    {
        get
        {
            return cloud;
        }

        set
        {
            cloud = value;
        }
    }

}
