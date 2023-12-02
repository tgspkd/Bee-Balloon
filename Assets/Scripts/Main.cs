using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    static private Main S;

    public int balloonsLeft = 0;

    private int _score = 0;

    // Start is called before the first frame update
    void Start()
    {
        S = this;
    }

    // Update is called once per frame
    void Update()
    {   
    }

    public static int Score {
        get { return S._score; }
        set { S._score = value; }
    }    

    public static void AddBalloon() { S.balloonsLeft++; }
    public static void PopBalloon() { 
        S.balloonsLeft--; 
        Score++;
    }
    public static void RemoveBalloon() {
        S.balloonsLeft--;
    }

}
