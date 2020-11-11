using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EncounterManager : MonoBehaviour
{
    public GameObject optionPanel;
    public GameObject actionPanel;

    [Header("UI Text")]
    public TextMeshProUGUI playerHealth;
    public TextMeshProUGUI playerStamina;
    public TextMeshProUGUI opponentHealth;
    public TextMeshProUGUI opponentStamina;

    [Header("Enemy Stats")]
    public int health;
    public int stamina = 100;

    // Start is called before the first frame update
    void Start()
    {
        health = Random.Range(90, 121);

        playerHealth.text = "Health: " + PlayerStats.Instance().currentHealth + "/" + PlayerStats.Instance().maxHealth;
        playerStamina.text = "Stamina: " + PlayerStats.Instance().currentStamina + "/" + PlayerStats.Instance().maxStamina;
        opponentHealth.text = "Health: " + health + "/" + health;
        opponentStamina.text = "Stamina: " + stamina + "/" + stamina;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* ----- Buttons Functions ----- */
    public void onClickedAction()
    {
        optionPanel.SetActive(false);
        actionPanel.SetActive(true);
    }

    public void onClickedFlee()
    {
        SceneManager.LoadScene(PlayerStats.Instance().sceneIndex);
    }



    public void onClickedBack()
    {
        optionPanel.SetActive(true);
        actionPanel.SetActive(false);
    }
}