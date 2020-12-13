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

    public override void TakeTurn(PartyDetails opponent)
    {
        /*
         * 0 - Debug        regular attack
         * 1 - Break        healing move
         * 2 - Pop Quiz     bonus damage
         * 3 - Teach        bonus healing
         */
        string abilUsed = "";

        int det = health - opponent.health;
        float rand = Random.Range(0.0f, 100.0f);

        if (det < 0)
        {
            if (rand <= 40)
            {
                actionOptions[1].UseAbility(this, opponent);
                abilUsed = actionOptions[1].abilityName;
            }
            else
            {
                actionOptions[3].UseAbility(this, opponent);
                abilUsed = actionOptions[3].abilityName;
            }
        }
        else if(det >= 0 && det <= 4)
        {
            if (rand <= 25)
            {
                actionOptions[1].UseAbility(this, opponent);
                abilUsed = actionOptions[1].abilityName;
            }
            else
            {
                actionOptions[3].UseAbility(this, opponent);
                abilUsed = actionOptions[3].abilityName;
            }
        }
        else if(det >= 10)
        {
            actionOptions[2].UseAbility(this, opponent);
            abilUsed = actionOptions[2].abilityName;
        }
        else
        {
            if(rand <= 30)
            {
                actionOptions[0].UseAbility(this, opponent);
                abilUsed = actionOptions[0].abilityName;
            }
            else if(rand <= 60)
            {
                actionOptions[3].UseAbility(this, opponent);
                abilUsed = actionOptions[3].abilityName;
            }
            else if(rand <= 80)
            {
                actionOptions[1].UseAbility(this, opponent);
                abilUsed = actionOptions[1].abilityName;
            }
            else
            {
                actionOptions[2].UseAbility(this, opponent);
                abilUsed = actionOptions[2].abilityName;
            }
        }

        OnTurnTaken.Invoke(partyName, abilUsed);
    }
}
