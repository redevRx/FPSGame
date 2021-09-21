using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kleeMove : MonoBehaviour
{

    [SerializeField] private float speed;
     [SerializeField] private float walkSpeed;
     [SerializeField] private float runSpeed;

    [SerializeField] private bool isGraound;
    [SerializeField] private bool groundCheckDistance;
    [SerializeField] private LayerMask groundMask;

    private Vector3 moveDirection;
    private Vector3 veloCity;

    //setting
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        //call move 
        Move();
    }

    private void Move() {
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(0, 0, moveZ);

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
        //moveDirection *= walkSpeed;
        moveDirection *= speed;

        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void Idel()
    { }

    private void Walk() 
    {
        speed = walkSpeed;
    }

    private void Run()
    {
        speed = runSpeed;
    }
}
