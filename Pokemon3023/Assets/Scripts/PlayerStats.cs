using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerStats
{
    private static PlayerStats instance;
    private PlayerStats()
    { }

    public static PlayerStats Instance()
    {
        if (instance == null)
            instance = new PlayerStats();

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

    public int currentHealth = 100;
    public int maxHealth = 100;

    public int currentStamina = 100;
    public int maxStamina = 100;
}
