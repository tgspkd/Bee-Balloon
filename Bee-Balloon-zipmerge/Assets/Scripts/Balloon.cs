using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    void Start()
    {
        Main.AddBalloon();
        print(this);

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            //  Sets a random color as full saturation
            spriteRenderer.color = Color.HSVToRGB(Random.Range(0f, 1f), 1f, 1f);;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Bee") {
            print("Popped!");
            Main.PopBalloon();
            Destroy(gameObject);
        }
    }
}
