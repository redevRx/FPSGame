using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public float health = 100f;
    public Text txtHealth;

    public GameManager GameManager;

    public AudioSource audio;

    public void Hit(float damang)
    {
        health -= damang;
        txtHealth.text = "Health :" + health + "%";
       // Debug.Log("Player Health :" + health);

        if (health <= 0)
        {
            // SceneManager.LoadScene(0);
            GameManager.EndGame();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
