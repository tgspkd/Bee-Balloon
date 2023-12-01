using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //void Start()
    //{
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Bee") {
            print("Boom!");
            Main.Score--;
            other.gameObject.GetComponent<Player>().Reset();
            Destroy(gameObject);
        }
    }
}
