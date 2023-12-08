using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimations : MonoBehaviour
{
    Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundCheck);

        playerAnim = GetComponent<Animator>();

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            playerAnim.SetBool("IsRunning", true);
        }

        else
        {
            playerAnim.SetBool("IsRunning", false);
        }

        //Jumping Animation
        /*
        if (!isGrounded)
        {
            playerAnim.SetBool("IsGrounded", false);
        }

        else
        {
            playerAnim.SetBool("IsGrounded", true);
        }*/
    }
}
