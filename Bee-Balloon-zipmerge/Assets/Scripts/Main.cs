using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{

    static private Main S;

    public int balloonsLeft = 0;

    private int _score = 0;
    private Text scoreUI;

    // Start is called before the first frame update
    void Start()
    {
        S = this;
        scoreUI = GameObject.Find("ScoreUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {   
    }

    public static int Score {
        get { return S._score; }
        set { S._score = value; S.scoreUI.text = value.ToString();}
    }    

    public static void AddBalloon() { S.balloonsLeft++; }
    public static void PopBalloon() { 
        S.balloonsLeft--; 
        Score++;
    }
    public static void RemoveBalloon() {
        S.balloonsLeft--;
        print("balloon removed");
    }

}
