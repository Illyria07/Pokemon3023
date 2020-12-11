using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameStats
{
    private static GameStats instance;
    private GameStats()
    { }

    public static GameStats Instance()
    {
        if (instance == null)
            instance = new GameStats();

        return instance;
    }

    public int sceneIndex;
    
    private Vector3 lastPosition;
    public Vector3 LastPosition
    {
        get
        {
            return lastPosition;
        }
        set
        {
            lastPosition = value;
        }
    }

    public int currentHealth = 40;
    public int maxHealth = 40;
}
