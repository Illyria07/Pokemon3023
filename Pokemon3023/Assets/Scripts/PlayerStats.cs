using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Vector3 lastPosition;

    public int currentHealth;
    public int maxHealth;

    public int currentStamina;
    public int maxStamina;

    public void SetLastPosition()
    {
        lastPosition = gameObject.transform.position;
    }
}
