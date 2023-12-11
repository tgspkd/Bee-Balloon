using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PreLevelScreen : MonoBehaviour
{
    public TextMeshProUGUI levelText;

    public void Setup(int level, int delay)
    {
        gameObject.SetActive(true);
        levelText.text = "Level " + level.ToString();
        StartCoroutine(RemoveAfter(delay));
    }

    IEnumerator RemoveAfter(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}
