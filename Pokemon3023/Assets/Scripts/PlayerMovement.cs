using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;

    [SerializeField]
    float speed = 5;

    [SerializeField]
    Rigidbody2D rigidBody;

    public bool hasEncounter;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        
        anim = GetComponent<Animator>();

        SceneManager.sceneLoaded += OnSceneLoaded;
        GameStats.Instance().OnLoadGame.AddListener(OnLoadHandler);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        anim.SetFloat("Vertical", Input.GetAxis("Vertical"));

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

    void OnLoadHandler()
    {
        gameObject.transform.position = GameStats.Instance().LastPosition;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "EncounterScene")
        {
            transform.position = GameStats.Instance().LastPosition;
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.position = new Vector3(100, 100, 100);
        }
    }
}
