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
        foreach(PartyDetails p in parties)
        {
            p.OnTurnTaken.AddListener(OnTurnTakenHandler);
        }

        for (int i = 0; i < 3; i++)
        {
            optionPanel.transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = parties[0].actionOptions[i].abilityName;
        }
    }

    public void AdvanceTurn()
    {
        phase++;
        phase = phase >= EncounterPhase.Count ? 0 : phase;

        PartyDetails forWhomTheTurnTolls = parties[(int)phase];
        if((int)phase == 1)
            forWhomTheTurnTolls.TakeTurn(parties[0]);
        else
            forWhomTheTurnTolls.TakeTurn();
    }

    public void OnButtonAction(int i)
    {
        parties[0].actionOptions[i].UseAbility(parties[0], parties[1]);
        parties[0].OnTurnTaken.Invoke(parties[0].partyName, parties[0].actionOptions[i].abilityName);
    }

    public void OnTurnTakenHandler(string name, string ability)
    {
        StartCoroutine(EndTurn(name +" used " + ability));
    }

    IEnumerator EndTurn(string message)
    {
        yield return msgManager.AnimateText(message);
        yield return new WaitForSeconds(1);
        AdvanceTurn();
    }
}