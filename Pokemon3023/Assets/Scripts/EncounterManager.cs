using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

enum EncounterPhase
{
    Player,
    Opponent,
    Count
}

public class EncounterManager : MonoBehaviour
{
    public EncounterMessageManager msgManager;

    EncounterPhase phase;
    public PartyDetails[] parties;

    public GameObject optionPanel;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < (parties[0] as PlayerPartyDetails).actionOptions.Length; i++)
        {
            optionPanel.transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = (parties[0] as PlayerPartyDetails).actionOptions[i].abilityName;
        }
    }

    public void AdvanceTurn()
    {
        phase++;
        phase = phase >= EncounterPhase.Count ? 0 : phase;

        PartyDetails forWhomTheTurnTolls = parties[(int)phase];
        if((int)phase == 1)
            forWhomTheTurnTolls.TakeTurn(parties[0].health);
        else
            forWhomTheTurnTolls.TakeTurn();
    }

    public void OnButtonAction(int i)
    {
        (parties[0] as PlayerPartyDetails).actionOptions[i].UseAbility(parties[0], parties[1]);
        StartCoroutine(EndTurn("Player used " + (parties[0] as PlayerPartyDetails).actionOptions[i].abilityName));
    }

    IEnumerator EndTurn(string message)
    {
        yield return msgManager.AnimateText(message);
        yield return new WaitForSeconds(1);
        AdvanceTurn();
    }
}