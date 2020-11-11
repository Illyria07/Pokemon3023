using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    PlayerStats playerStats;

    [SerializeField]
    float speed = 5;

    [SerializeField]
    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        anim = GetComponent<Animator>();
        playerStats = GetComponent<PlayerStats>();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementVector *= speed;
        rigidBody.velocity = movementVector;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "EncounterScene")
        {
            transform.position = new Vector3(0, 0, -20);
            // Main Camera is the object at index 0
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            transform.position = playerStats.lastPosition;
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
