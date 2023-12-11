using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    // For save data
    private SaveData saveData = new SaveData();
    private string date;
    private string elapsedTime;

    static private Main S;

    public int balloonsLeft = 0;

    private int lives = 3;

    private Text scoreUI;
    private Slider timer;

    private Image life1;
    private Image life2;
    private Image life3;
    private Text pauseButton;

    // Saves and serializes the player data into JSON
    public static void GenerateReport(string name, string feedback)
    {
        S.elapsedTime = Time.timeSinceLevelLoad.ToString("F2") + " seconds";
        S.date = System.DateTime.Now.ToString();

        S.saveData.name = name;
        S.saveData.date = S.date;
        S.saveData.elapsedTime = S.elapsedTime;
        S.saveData.feedback = feedback;

        Data.SaveToJson(S.saveData);
    }

    // Start is called before the first frame update
    void Awake()
    {
        S = this;
        scoreUI = GameObject.Find("ScoreUI").GetComponent<Text>();
        scoreUI.text = Data.Score.ToString();
        timer = GameObject.Find("Slider").GetComponent<Slider>();

        life1 = GameObject.Find("Life1").GetComponent<Image>();
        life2 = GameObject.Find("Life2").GetComponent<Image>();
        life3 = GameObject.Find("Life3").GetComponent<Image>();

        pauseButton = GameObject.Find("PauseText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (!Main.Paused) timer.value -= Time.deltaTime;
    }

    public void EndGame() {
        SceneManager.LoadScene("EndGame");
    }

    public static int Score {
        get { return Data.Score; }
        set { Data.Score = value; S.scoreUI.text = value.ToString();}
    }    

    public static void AddBalloon() { S.balloonsLeft++; }
    public static void PopBalloon() { 
        S.balloonsLeft--; 
        Score += 10;
    }
    public static void RemoveBalloon() {
        S.balloonsLeft--;
        print("balloon removed");
    }

    // End after three deaths, though do show the empty lives array on the Canvas
    public static void LoseLife() {
        switch (S.lives) {
            case 3:
                if (S.life1 != null) S.life1.enabled = false;
                break;
            case 2:
                if (S.life2 != null) S.life2.enabled = false;
                break;
            case 1:
                if (S.life3 != null) S.life3.enabled = false;
                S.EndGame();
                break;
            case 0:
                S.EndGame();
                break;
        }
        S.lives--;
    }

    public static bool Paused {
        get;
        private set;
    }

    public static void Pause() {
        Paused = !Paused;

        if (Paused) {
            S.pauseButton.text = "▐▐";
            // S.pauseButton.fontSize = 8;
            RectTransform rect = S.pauseButton.GetComponent<RectTransform>();
            rect.localScale = new Vector3(.5f, .5f, 1);
            // rect.rect = new Rect(-3, 0, 0, 0);
            print(rect.transform.position);
        }
        else {
            S.pauseButton.text = "▶";
            S.pauseButton.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            // rect.rect = new Rect(5, 0, 0, 0);
            // S.pauseButton.
        }

    }



}
