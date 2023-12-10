using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data
{

    public static int FinalLevel;
    private static int _score;

    public static int Score
    {
        get { return _score; }
        set
        {
            _score = value;

            if (!PlayerPrefs.HasKey("HighScore") || PlayerPrefs.GetInt("HighScore") < _score)
            {
                PlayerPrefs.SetInt("HighScore", _score);
            }
        }
    }



}