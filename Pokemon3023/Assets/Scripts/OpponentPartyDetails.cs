using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpponentPartyDetails : PartyDetails
{
    [Header("Opponent Details")]
    public Image oppSprite;
    public OpponentListScriptable oppList;
    public OpponentScriptable currentOpponent;

    // Start is called before the first frame update
    void Start()
    {
        currentOpponent = oppList.RandomOpponent();
        oppSprite.sprite = currentOpponent.oppSprite;
        partyName = currentOpponent.oppName;
        health = Random.Range(currentOpponent.minHealth, 40);
        nameText.text = partyName;
        healthText.text = "Grade: " + HealthToGrade(health);
    }

    public override void TakeTurn()
    {

    }

    public override void TakeTurn(int oppHealth)
    {
        Debug.Log("Opponent's Turn");
    }
}
