using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data: MonoBehaviour
{
    public static int FinalLevel;
    private static int _score;
    private static SaveData tempLoad;
    private static string tempData;

    private void Awake()
    {
        tempLoad = LoadFromJson();
        tempData = JsonUtility.ToJson(tempLoad);
    }

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

    public static int Level
    {
        get { return FinalLevel; }
        set
        {
            FinalLevel = value;

            if (!PlayerPrefs.HasKey("FinalLevel") || PlayerPrefs.GetInt("FinalLevel") < FinalLevel)
            {
                PlayerPrefs.SetInt("FinalLevel", FinalLevel);
            }
        }
    }

    public static SaveData LoadFromJson()
    {
        // Load JSON File
        string jsonString = System.IO.File.ReadAllText(Application.persistentDataPath + "/SaveData.json");
        return JsonUtility.FromJson<SaveData>(jsonString);
    }

    public static void SaveToJson(SaveData saveData)
    {
        // Save to JSON File
        string jsonToSave = JsonUtility.ToJson(saveData);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/SaveData.json", tempData + "\n" + jsonToSave);
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
