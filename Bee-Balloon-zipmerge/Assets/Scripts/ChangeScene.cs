using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void Setup(int LevelNum)
    {
        SceneManager.LoadScene($"Level_{LevelNum}");
        Data.CurrentLevel = LevelNum;
    }

    public void ReturnToMainMenu()
    {
        Data.Time = 240;
        Data.Score = 0;
        StartCoroutine(ChangeSceneAfter(sceneName: "StartGame", seconds: 2));
    }

    // After GameOver submission
    IEnumerator ChangeSceneAfter(string sceneName, int seconds)
    {
        print("Returning to main menu...");
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneName);
    }

}
