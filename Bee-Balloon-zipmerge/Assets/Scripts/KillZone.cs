using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{

    public bool invertMask = false;


    [Header("Path Based")]
    public bool followsPath = false;
    public bool reverseOnEnd = false;
    public bool reversing = false;
    public Transform[] Points;
    public float moveSpeed;
    public int pointsIndex = 0;


    private void Awake() {
        if (followsPath) {
            transform.position = Points[pointsIndex].transform.position;
        }
        
        GetComponent<SpriteRenderer>().maskInteraction = invertMask ? SpriteMaskInteraction.VisibleOutsideMask : SpriteMaskInteraction.VisibleInsideMask;
    }

    private void Update() {
        if (followsPath) {
            if (pointsIndex <= Points.Length - 1 && pointsIndex > -1) {
                // print(pointsIndex);
                // print(reversing);
                // print((reversing && pointsIndex >= 0));
                transform.position = Vector3.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);

                if (transform.position == Points[pointsIndex].transform.position) {
                    pointsIndex += reversing ? -1 : 1;
                }
            }
            else {
                if (reverseOnEnd) {
                    pointsIndex += reversing ? 1 : -1;
                    reversing = !reversing;
                    print(reversing);
                }
                else pointsIndex = 0;
                transform.position = Points[pointsIndex].transform.position;
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Bee") {
            Player p = other.gameObject.GetComponent<Player>();
            if (!followsPath || p.inKillZonePath) {
                print("Killed!");
                p.Reset();
            }
        }
    }
}
