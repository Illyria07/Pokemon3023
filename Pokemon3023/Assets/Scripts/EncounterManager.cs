using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EncounterManager : MonoBehaviour
{
    public UnityEvent<PartyDetails, PartyDetails> OnActionUsed;
    public UnityEvent OnFleeingBattle;

    public PartyDetails player;
    public PartyDetails opponent;
    public GameObject optionPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* ----- Buttons Functions ----- */
    public void onClickedAction()
    {
        
    }

    public void onClickedFlee()
    {
        SceneManager.LoadScene(PlayerStats.Instance().sceneIndex);
    }
}