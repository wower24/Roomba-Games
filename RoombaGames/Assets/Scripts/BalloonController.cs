using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BalloonController : MonoBehaviour
{
    public float upSpeed;
    int score = 0;
    AudioSource audioSource;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    private void Awake() {
        //get access to the audio component of balloon
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        UpdateHighScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        //if balloon goes out of the screen - RESET SCENE
        if(transform.position.y > 6f) {
            //reset scene == reload scene, just use the name of the scene in Unity
            Invoke("GoBackToMenu", 3);
        }
        
    }

    private void FixedUpdate() {
        //move up - along y-axis
        transform.Translate(0, upSpeed, 0);
    }

    //onMouseDown also works with taps on touchscreen
    private void OnMouseDown() {
        score++;
        CheckHighScore();
        //update counter
        scoreText.text = score.ToString();
        //play audio
        audioSource.Play();
        upSpeed += 0.002f;
        ResetPosition();
    }

    void ResetPosition() {
        float randomX = Random.Range(-6, 6);

        transform.position = new Vector2(randomX, -6f);
    }

    void CheckHighScore() {
        if (score > PlayerPrefs.GetInt("HighScoreBalloon", 0)) {
            PlayerPrefs.SetInt("HighScoreBalloon", score);
            UpdateHighScoreText();
        }
    }

    void UpdateHighScoreText() {
        highScoreText.text = $"BEST SCORE: {PlayerPrefs.GetInt("HighScoreBalloon", 0)}";
    }

    void GoBackToMenu() {
        SceneManager.LoadScene("Menu");
    }
}
