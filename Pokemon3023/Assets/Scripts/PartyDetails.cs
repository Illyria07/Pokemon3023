using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PartyDetails : MonoBehaviour
{
    public EncounterManager encounterManager;

    [Header("Basic Details")]
    public string partyName;
    public int health;
    public bool isPlayer;

    [Header("Opponent Specific Details")]
    public OpponentListScriptable oppList;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = partyName;

        if (isPlayer)
            health = GameStats.Instance().currentHealth;
        else
        {
            // Opponent setup
        }
        healthText.text = "Grade: " + HealthToGrade(health);
    }

    public void ModifyHealth(int damage)
    {
        health -= damage;
        healthText.text = "Grade: " + HealthToGrade(health);
    }

    private string HealthToGrade(int health)
    {
        string grade = "";

        if (health >= 37)
            grade = "A+";
        else if (health >= 33)
            grade = "A";
        else if (health >= 30)
            grade = "A-";
        else if (health >= 27)
            grade = "B+";
        else if (health >= 23)
            grade = "B";
        else if (health >= 20)
            grade = "B-";
        else if (health >= 17)
            grade = "C+";
        else if (health >= 13)
            grade = "C";
        else if (health >= 10)
            grade = "C-";
        else if (health >= 7)
            grade = "D+";
        else if (health >= 3)
            grade = "D";
        else if (health > 0)
            grade = "D-";
        else
            grade = "F";

        return grade;
    }
}
