using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    private Text levelUI;
    private Text scoreUI;
    private Text highScoreUI;

    void Start()
    {
        levelUI = GameObject.Find("Level").GetComponent<Text>();
        scoreUI = GameObject.Find("FinalScore").GetComponent<Text>();
        highScoreUI = GameObject.Find("HighScoreVal").GetComponent<Text>();

        levelUI.text = "You made it to Level " + Data.CurrentLevel.ToString();
        scoreUI.text = "Final Score: " + Data.Score.ToString();

        if (PlayerPrefs.HasKey("HighScore") && PlayerPrefs.GetInt("HighScore") > Data.Score)
        {
            highScoreUI.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
        }
        else
        {
            highScoreUI.text = "New High Score!";
        }
    }

}
