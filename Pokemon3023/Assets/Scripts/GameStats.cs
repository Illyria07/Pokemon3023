using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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


    public UnityEvent OnLoadGame;

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

    public ActionScriptable[] abilities = new ActionScriptable[2];
    int lastAbility = 0; // Can only be 0 or 1

    public void AddAbility(ActionScriptable actScript)
    {
        abilities[lastAbility] = actScript;
        lastAbility = lastAbility + 1 == 2 ? 0 : lastAbility + 1;
    }

    public void SaveStats()
    {
        PlayerPrefs.SetFloat("xPos", lastPosition.x);
        PlayerPrefs.SetFloat("yPos", lastPosition.y);
        PlayerPrefs.SetFloat("zPos", lastPosition.z);

        PlayerPrefs.SetInt("health", currentHealth);

        //PlayerPrefs.SetString("Ability1", )

        PlayerPrefs.Save();
    }

    public void LoadStats()
    {
        if(PlayerPrefs.HasKey("xPos"))
            lastPosition.x = PlayerPrefs.GetFloat("xPos");
        if(PlayerPrefs.HasKey("yPos"))
            lastPosition.y = PlayerPrefs.GetFloat("yPos");
        if(PlayerPrefs.HasKey("zPos"))
            lastPosition.z = PlayerPrefs.GetFloat("zPos");

        if (PlayerPrefs.HasKey("health"))
            currentHealth = PlayerPrefs.GetInt("health");

        GameManager.Instance().ChangeScene(1);

        OnLoadGame.Invoke();
    }
}
