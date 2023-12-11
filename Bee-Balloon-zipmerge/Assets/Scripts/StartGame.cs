using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void ChangeScene(int LevelNum)
    {
        SceneManager.LoadScene($"Level_{LevelNum}");
        Data.CurrentLevel = LevelNum;
    }
}
