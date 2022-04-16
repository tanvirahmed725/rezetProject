using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // we want to create speed for our player
    public float moveSpeed;

    // WE want to access rigidbody attached to player
    //public Rigidbody theRB;

    // To jump
    public float jumpForce;

    public CharacterController controller;

    // We need vector3 obj to store how character moves
    private Vector3 moveDirection;

    public float gravityScale;

    //animator variable
    public Animator anim;

    //used to measure rotation speed for camera
    public Transform pivot;
    public float rotateSpeed;

    //references player skin model rather than pill cosby
    public GameObject playerModel;

    //knockback feature
    public float knockBackForce;
    public float knockBackTime;
    private float knockBackCounter;

    // Start is called before the first frame update (init)
    void Start()
    {
        /* 
         * Get any component that has type rigidbody
           attached to Player and set = to theRB
        */

        //theRB = GetComponent<Rigidbody>();

        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Every time movement button is hit 
        // Vector3(x, y, z)
        //theRB.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed,
        //theRB.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        /*if(Input.GetButtonDown("Jump"))
		{
            theRB.velocity = new Vector3(theRB.velocity.x, 
                jumpForce, theRB.velocity.z);
		}*/

        //knockback counter checker -- basically if knockback counter is greater than 0 then player is immobile for a period of time
        if (knockBackCounter <= 0)
        {



            //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
            float yStore = moveDirection.y;
            // To move based on camera
            moveDirection = (transform.forward * Input.GetAxis("Vertical"))
                + (transform.right * Input.GetAxis("Horizontal"));

            // Use movespeed 
            moveDirection = moveDirection.normalized * moveSpeed;

            moveDirection.y = yStore;

            // Can only jump if you're on the ground
            if (controller.isGrounded)
            {
                // Let us float down from platforms instead of snap down
                moveDirection.y = 0f;

                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpForce;
                }
            }
        }
        else 
        {
            knockBackCounter -= Time.deltaTime;
        }

        // Add gravity
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);

        // Move charController based on moveDirection
        // Slow movement to time from last frame
        // Smooth out so all platforms get same exp
        controller.Move(moveDirection * Time.deltaTime);

        //Move player in diff directions based on camera direction
        if(Input.GetAxis("Horizontal") !=0 || Input.GetAxis("Vertical") !=0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }

        anim.SetBool("isGrounded", controller.isGrounded);
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
    }

    //sets knockback variables
    public void Knockback(Vector3 direction)
    {
        knockBackCounter = knockBackTime;

        direction = new Vector3(1f, 1f, 1f);

        moveDirection = direction * knockBackForce;
    }
}
