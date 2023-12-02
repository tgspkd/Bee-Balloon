using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    private void Start() {
        // OverlapCircle(Vector2 transform.position, , ContactFilter2D contactFilter, );
        // ;

        // print(GetComponent<CircleCollider2D>().radius);

        List<Collider2D> results = new List<Collider2D>();

        int rLen = Physics2D.OverlapCircle(
            new Vector2(transform.position.x, transform.position.y),
            GetComponent<CircleCollider2D>().radius, 
            new ContactFilter2D().NoFilter(),
            results
        );

        // print(results[0].gameObject);
        print(rLen);
        for (int i = 0; i < rLen; i++) {
            print(results[i].gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        print(other);
        if (other.gameObject.tag == "Bee") {
            print("Boom!");
            Main.Score--;
            
            other.gameObject.GetComponent<Player>().Reset();
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Balloon") {
            Main.RemoveBalloon();
            Destroy(other.gameObject);
        }
    }
}