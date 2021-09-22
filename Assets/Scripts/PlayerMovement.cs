using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4.5f;
    [SerializeField] private float jumpHeight = 1.5f;
    

    private Vector3 velocity;
    private Vector3 movement;

    [SerializeField] private float gravity;
    [SerializeField] private bool isGraounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

       PlayerMove();
    }



    //code from video style
    //result not working
    private void PlayerMove()
    {

        isGraounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);

        if (isGraounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


         movement = new Vector3(Mathf.RoundToInt(Input.GetAxis("Horizontal")), 0, Mathf.RoundToInt(Input.GetAxis("Vertical"))).normalized;
         characterController.Move(movement * Time.deltaTime * moveSpeed);

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && isGraounded)
        {
            Jump();
        }

      
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity);
    }




    private void Idel()
    {
        moveSpeed = 4.5f;
    }

    private void Walk()
    {
        moveSpeed = 5f;
    }

    private void Run()
    {
        moveSpeed = 10f;
    }

    private void Jump()
    {
        velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
    }
}
