using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelAnimations : MonoBehaviour
{
    Animator playerAnim;
    public Transform modelRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate character model with mouse input
        transform.rotation = modelRotation.rotation;

        //Run animation
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            playerAnim.SetBool("IsRunning", true);
        }

        else
        {
            playerAnim.SetBool("IsRunning", false);
        }

        //Jump Animation
        if (!GetComponentInParent<PlayerMovement>().isGrounded)
        {
            playerAnim.SetBool("IsGrounded", false);
            //playerAnim('Jump').speed = 1;
        }

        else
        {
            playerAnim.SetBool("IsGrounded", true);
        }
    }
}
