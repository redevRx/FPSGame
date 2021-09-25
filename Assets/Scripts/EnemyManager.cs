using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] public GameObject player;
    [SerializeField] public Animator enemyAnimator;
    [SerializeField] public float damang = 20f;

    public GameManager gameManager;

    [Tooltip("For Zombierial")]
    [SerializeField] public float health = 100f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //has error set destination
        GetComponent<NavMeshAgent>().destination = player.transform.position;
        if (GetComponent<NavMeshAgent>().velocity.magnitude > 1)
        {
            enemyAnimator.SetBool("isRunning", true);
        }
        else
        {
            enemyAnimator.SetBool("isRunning", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
           // Debug.Log("Player Hit!");
            player.GetComponent<PlayerManager>().Hit(damang);
        }
    }

    public void Hit(float damang)
    {
        health -= damang;

        Debug.Log("Enemy Health :" + health);

        if (health <= 0)
        {
            gameManager.enemyesAlive--;
            Destroy(gameObject);
        }
    }
}
