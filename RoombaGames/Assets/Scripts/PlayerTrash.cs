using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerTrash : MonoBehaviour {
    public FixedJoystick joystick;
    public float moveSpeed;
    public Stopwatch stopwatch;

    float horizontalInput, verticalInput;

    int score = 0;
    public int winScore;
    public GameObject winText;

    public TextMeshProUGUI highScoreText;
    // Start is called before the first frame update
    void Start() {
        UpdateHighScore();
        stopwatch.start();
    }

    // Update is called once per frame
    void Update() {

    }

    private void FixedUpdate() {
        horizontalInput = joystick.Horizontal * moveSpeed;
        verticalInput = joystick.Vertical * moveSpeed;
        //move player accordingly to the movement of joystick
        transform.Translate(horizontalInput, verticalInput, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Carrot") {
            score++;

            Destroy(collision.gameObject);

            if (score >= winScore) {
                winText.SetActive(true);
                stopwatch.stop();
                stopwatch.display.gameObject.SetActive(true);
                CheckHighScore();
                highScoreText.gameObject.SetActive(true);
                Invoke("GoBackToMenu", 3);
            }
        }
    }

    void CheckHighScore() {
        if (stopwatch.GetTimeValue() < PlayerPrefs.GetFloat("HighScoreTrash", 600)) {
            PlayerPrefs.SetFloat("HighScoreTrash", stopwatch.GetTimeValue());
            UpdateHighScore();
        }
    }

    void UpdateHighScore() {
        highScoreText.text = $"BEST SCORE: {PlayerPrefs.GetFloat("HighScoreTrash", 600):0.00}s";
    }

    void GoBackToMenu() {
        SceneManager.LoadScene("Menu");
    }
}