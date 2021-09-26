using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class KeqingController : MonoBehaviour
{

    [SerializeField] public float moveSpeed = 4.5f;
    [SerializeField] public float jumpHeight = 1.5f;

    private Vector3 velocity;
    private Vector3 movement;

    [SerializeField] public float gravity;
    [SerializeField] public bool isGraounded;
    [SerializeField] public float groundCheckDistance;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundMask;


    [SerializeField] public CharacterController characterController;

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


        movement = new Vector3(Input.GetAxis("Horizontal"), 0,
            Input.GetAxis("Vertical"));

        movement = transform.TransformDirection(movement);
        movement *= moveSpeed * Time.deltaTime;

        characterController.Move(movement);

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && isGraounded)
        {
            Jump();
        }

        if (Input.GetButtonDown("ButtonA") && isGraounded)
        {
            Jump();
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void Jump()
    {
        velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
    }
}
