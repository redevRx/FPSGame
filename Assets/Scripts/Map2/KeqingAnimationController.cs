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
      
    }

    // Update is called once per frame
    void Update()
    {
      
        if (transform.hasChanged)
        {
            //user moving
            animator.SetBool("isMovement", true);
        }
        else
        {
            animator.SetBool("isMovement", false);
        }
    }
}
