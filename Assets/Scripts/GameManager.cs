using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int enemyesAlive = 0;
    public int round = 0;

    public GameObject[] spawnPoints;
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyesAlive == 0)
        {
            round++;
            NextWave(round);
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
