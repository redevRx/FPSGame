using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 4.5f;
    [SerializeField] public float jumpHeight = 1.5f;
    

    private Vector3 velocity;
    private Vector3 movement;
    [SerializeField] public Transform transformPlayer;

    [SerializeField] public float gravity;
    [SerializeField] public bool isGraounded;
    [SerializeField] public float groundCheckDistance;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundMask;

    public GameManager gameManager;
    public bool isPuaseGame = false;
    public GameObject puaseGame;


    public AudioSource openSound;

    [SerializeField] public CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        isPuaseGame = puaseGame.gameObject.activeSelf;

        Vector3 rot = transform.localRotation.eulerAngles;

        movement.x = rot.x;
        movement.z = rot.z;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isPuaseGame)
            {
                PuaseGameToPlayerMovement(false);
                openSound.Stop();
            }
            else
            {
                PuaseGameToPlayerMovement(true);
                openSound.Play();
            }
        }

        PlayerMove();
    }


    public void PuaseGameToPlayerMovement(bool isPuase)
    {
        Time.timeScale = isPuase ? 0 : 1;
        puaseGame.gameObject.SetActive(isPuase);
        isPuaseGame = isPuase;
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

        characterController.Move(movement * Time.deltaTime * moveSpeed);

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
