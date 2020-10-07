using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;

    [SerializeField]
    float speed = 5;

    [SerializeField]
    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementVector *= speed;
        rigidBody.velocity = movementVector;
    }

    //if (Input.GetKey(KeyCode.UpArrow))
    //    {
    //        transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
    //        anim.SetBool("isWalking", true);
    //        anim.SetInteger("playerDir", 0);
    //    }

}
