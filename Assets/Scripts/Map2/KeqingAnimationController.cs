using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeqingAnimationController : MonoBehaviour
{

    public CharacterController player;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("isReadyAgain", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.velocity.magnitude > 0.01f)
        {
            //user moving
            animator.SetBool("isReadyAgain", false);
            animator.SetBool("isMovement", true);
        }
        else
        {
            animator.SetBool("isReadyAgain", true);
            animator.SetBool("isMovement", false);
        }
    }
}
