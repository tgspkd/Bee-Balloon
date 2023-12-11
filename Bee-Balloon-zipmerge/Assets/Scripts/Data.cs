using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data: MonoBehaviour
{
    public static int FinalLevel;
    public static int CurrentLevel = 1;

    public static float Time = 240;
    public static int Lives = 3;
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

    public static void SaveToJson(SaveData saveData)
    {
        saveData._score = Score;
        string data = JsonUtility.ToJson(saveData);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/SaveData.json", data);
        print("Saved!");
    }
}

[System.Serializable]
public class SaveData
{
    public string name;
    public int _score;
    public string date;
    public string elapsedTime;
    public string feedback;
}
