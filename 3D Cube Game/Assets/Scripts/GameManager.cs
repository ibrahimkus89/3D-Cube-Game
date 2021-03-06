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
    int highScore = 0;

    bool gameStarted = false;
    public GameObject menuPanel;

    public Text scoreText;
    public Text highScoreText;

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
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
            highScoreText.text = "High Score : " + highScore.ToString();
        }
    }

    
    void Update()
    {
        if (Input.anyKeyDown && !gameStarted)
        {
            menuPanel.SetActive(false);
            scoreText.gameObject.SetActive(true);


            StartCoroutine(SpawnEnemies());
            gameStarted = true;

        }
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
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore",highScore);
        }

        SceneManager.LoadScene(0);
    }

    public void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
