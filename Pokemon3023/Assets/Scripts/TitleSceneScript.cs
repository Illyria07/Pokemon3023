using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneScript : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance().ChangeScene(1);
    }
}
