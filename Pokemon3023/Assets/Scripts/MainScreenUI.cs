using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenUI : MonoBehaviour
{
    public GameObject abilityPanel;
    public ActionScriptable[] abils;

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
        if (abilityPanel.activeSelf)
            abilityPanel.SetActive(false);
        else
            abilityPanel.SetActive(true);
    }

    public void OnToggleAbility(int i)
    {

    }
}
