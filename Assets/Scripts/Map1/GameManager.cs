using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int enemyesAlive = 0;
    public int round = 0;

    public GameObject endScreen;
    public GameObject[] spawnPoints;
    public GameObject enemyPrefab;

    public Text roundNumber;
    public Text roundServived;


    public void EndGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        endScreen.SetActive(true);

        roundServived.text = round + "";
    }

    public void RestatGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    // Start is called before the first frame update
    void Start()
    {
    }


    public void OnExit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyesAlive == 0)
        {
            round++;
            NextWave(round);

            roundNumber.text = "Round :"+round;
        }

    }

    public void NextWave(int round)
    {

        for (int i = 0; i < round; i++)
        {

            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemySpawned =  Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            enemySpawned.GetComponent<EnemyManager>().gameManager = GetComponent<GameManager>();

            enemyesAlive++;
        }
    }
}
