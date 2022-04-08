using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//need this to access Text Class

public class ScoreWindow : MonoBehaviour
{
    private Text highscoreText;
    private Text scoreText;
    private void Awake()
    {
        scoreText = transform.Find("scoreText").GetComponent<Text>();
        highscoreText = transform.Find("highscoreText").GetComponent<Text>();
    }
    private void Start()
    {
        highscoreText.text = "Highscore: " + Score.GetHighscore().ToString();
    }

    private void Update()
    {
        scoreText.text = "Score: " + PipeSpawner.GetInstance().GetScore().ToString();
    }

}//class
