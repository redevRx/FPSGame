using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponManager : MonoBehaviour
{

    [SerializeField] public GameObject mainCM;
    [SerializeField] public float range = 100f;
    [SerializeField] public float damang = 50f;


    [SerializeField] public Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAnimator.GetBool("isShooting"))
        {
            playerAnimator.SetBool("isShooting", false);
        }


        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("Shoot");
            Shoot();
        }
    }

    void Shoot()
    {

        playerAnimator.SetBool("isShooting", true);


        RaycastHit raycastHit;

        if (Physics.Raycast(mainCM.transform.position, transform.forward, out raycastHit, range))
        {
           // Debug.Log("Hit");

            EnemyManager enemy = raycastHit.transform.GetComponent<EnemyManager>();

            if (enemy != null)
            {
                enemy.Hit(damang);
            }
        }
    }
}
