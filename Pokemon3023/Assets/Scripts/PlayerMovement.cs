﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;

    [SerializeField]
    float speed = 5;

    [SerializeField]
    Rigidbody2D rigidBody;

    public bool hasEncounter;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasEncounter)
        {
            Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            movementVector *= speed;
            rigidBody.velocity = movementVector;
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
        }
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "EncounterScene")
        {
            transform.position = GameStats.Instance().LastPosition;
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
