using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariable
{
    private static GameVariable instance = null;
    private static readonly object lockIntance = new object();
    private GameVariable() { }
    public static GameVariable Instance
    {
        get
        {
            if (instance == null)
            {
                lock (lockIntance)
                {
                    if (instance == null)
                    {
                        instance = new GameVariable();
                    }
                }
            }
            return instance;
        }
    }
}
