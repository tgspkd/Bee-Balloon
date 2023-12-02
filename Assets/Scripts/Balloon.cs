using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    void Start()
    {
        Main.AddBalloon();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Bee") {
            print("Popped!");
            Main.PopBalloon();
            Destroy(gameObject);
        }
    }
}
