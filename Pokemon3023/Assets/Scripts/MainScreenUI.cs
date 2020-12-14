using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScreenUI : MonoBehaviour
{
    public GameObject abilityPanel;
    public GameObject[] abilityToggles;
    public ActionScriptable[] abilitySelection;

    private Queue<int> abilityQueue = new Queue<int>();

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
        if (abilityToggles[i].GetComponent<Toggle>().isOn)
        {
            GameStats.Instance().AddAbility(abilitySelection[i]);
            abilityToggles[i].GetComponent<Toggle>().isOn = true;
            abilityToggles[i].GetComponent<Toggle>().interactable = false;

            abilityQueue.Enqueue(i);
            if (abilityQueue.Count > 2)
            {
                int toggle = abilityQueue.Dequeue();
                abilityToggles[toggle].GetComponent<Toggle>().isOn = false;
                abilityToggles[toggle].GetComponent<Toggle>().interactable = true;
            }
        }
    }
}
