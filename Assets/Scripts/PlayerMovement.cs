using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpHeight;

   
    private Vector3 velocity;

    [SerializeField] private float gravity;
    [SerializeField] private bool isGraounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        //enable for youtube style
        characterController = GetComponent<CharacterController>();
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

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        characterController.Move(move * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    //code from youtube player movement
    private Vector3 moveDirection;

    private void Move()
    {
        isGraounded = characterController.isGrounded;

        if (isGraounded && velocity.y < 0)
        {
            gravity = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(move * Time.deltaTime * moveSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            //walk
            Walk();
        }
        else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            //run
            Run();
        }
        else if (moveDirection == Vector3.zero)
        {
            //idel
            Idel();
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        //velocity.y += gravity * Time.deltaTime;
        //characterController.Move(velocity * Time.deltaTime);
    }

    private void Idel()
    {
        moveSpeed = 4.5f;
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
    }

    private void Run()
    {
        moveSpeed = runSpeed;
    }

    private void Jump()
    {
        velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
    }
}
