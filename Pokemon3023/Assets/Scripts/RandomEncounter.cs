using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class RandomEncounter : MonoBehaviour
{
    public GameObject player;
    private Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EncounterEvent()
    {
        int r = Random.Range(0, 100);
        if (r <= 33)
            Debug.Log("Random Encounter Occured!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            position = player.transform.position;
            EncounterEvent();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            if ((Mathf.Abs(player.transform.position.x) - Mathf.Abs(position.x) >= 1) ||
                (Mathf.Abs(player.transform.position.x) - Mathf.Abs(position.x) <= -1) ||
                    (Mathf.Abs(player.transform.position.y) - Mathf.Abs(position.y) >= 1) ||
                    (Mathf.Abs(player.transform.position.y) - Mathf.Abs(position.y) <= -1))
            {
                EncounterEvent();
                position = player.transform.position;
            }
        }
    }
}
