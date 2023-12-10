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
        levelUI = GameObject.Find("LevelVal").GetComponent<Text>();
        scoreUI = GameObject.Find("ScoreVal").GetComponent<Text>();
        highScoreUI = GameObject.Find("HighScoreVal").GetComponent<Text>();

        // levelUI.text = GameData.FinalLevel.ToString();
        scoreUI.text = Data.Score.ToString();

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
