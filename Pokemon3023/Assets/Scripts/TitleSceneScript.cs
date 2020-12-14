using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneScript : MonoBehaviour
{
    MusicManager musicM;

    void Start()
    {
        musicM = FindObjectOfType<MusicManager>();
    }

    public void StartGame()
    {
        GameManager.Instance().ChangeScene(1);
        musicM.onEncounterEndHandler();
    }
}
