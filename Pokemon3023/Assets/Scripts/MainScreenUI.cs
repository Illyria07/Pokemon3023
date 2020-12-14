using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenUI : MonoBehaviour
{
    public void OnSaveClicked()
    {
        GameStats.Instance().SaveStats();
    }

    public void OnLoadClicked()
    {
        GameStats.Instance().LoadStats();
    }

    public void OnAbilitiesClicked()
    {

    }
}
