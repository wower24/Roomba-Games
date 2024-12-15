using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerCarDodge : MonoBehaviour
{
    public GameObject block;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;

    bool gameStarted = false;

    public GameObject tapText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText; 

    int score = 0;

    private void Start() {
        UpdateHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !gameStarted) {
            tapText.SetActive(false);
            gameStarted = true;
            StartSpawning();
        }
        
    }

    private void StartSpawning() {
        //InvokeRepeating pars: name of method, time to first launch, rate of every other launch
        InvokeRepeating("SpawnBlock", 0.5f, spawnRate);
    }

    private void SpawnBlock() {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(block, spawnPos, Quaternion.identity);
        block.SetActive(true);
        score++;
        scoreText.text = score.ToString();
        CheckHighScore();
    }

    void CheckHighScore() {
        if(score > PlayerPrefs.GetInt("HighScoreCars", 0)) {
            PlayerPrefs.SetInt("HighScoreCars", score);
            UpdateHighScore();
        }
    }

    void UpdateHighScore() {
        highScoreText.text = $"BEST SCORE: {PlayerPrefs.GetInt("HighScoreCars", 0)}";
    }
}
