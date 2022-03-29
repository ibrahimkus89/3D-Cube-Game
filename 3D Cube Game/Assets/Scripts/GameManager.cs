using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject enemy;
    public Transform spawnPoint;
    public float maxSpawnPointX;

    int score = 0;

    public Text scoreText;

    public static GameManager instance;



    private void Awake()
    {
        if (instance ==null)
        {
            instance = this;
        }
    }

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    
    void Update()
    {
        
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.8f);
            Spawn();
        }
    }


    public void Spawn()
    {
        float randomSpawnX = Random.Range(-maxSpawnPointX,maxSpawnPointX);

        Vector3 enemySpawnPos = spawnPoint.position;
        enemySpawnPos.x = randomSpawnX;

        Instantiate(enemy, enemySpawnPos, Quaternion.identity);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
