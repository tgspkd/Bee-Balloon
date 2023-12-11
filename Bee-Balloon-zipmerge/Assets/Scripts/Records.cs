using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Records : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI lastLevelAchieved;

    private void Awake()
    {
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
        lastLevelAchieved.text = "Last Level Achieved: " + PlayerPrefs.GetInt("FinalLevel").ToString();
    }
}
