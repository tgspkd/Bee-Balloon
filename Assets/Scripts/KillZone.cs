using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{

    [SerializeField] private bool invertMask = false;


    [Header("Path Based")]
    [SerializeField] private bool followsPath = false;
    [SerializeField] private Transform[] Points;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int pointsIndex = 0;


    private void Start() {
        if (followsPath) {
            transform.position = Points[pointsIndex].transform.position;
        }
        
        GetComponent<SpriteRenderer>().maskInteraction = invertMask ? SpriteMaskInteraction.VisibleOutsideMask : SpriteMaskInteraction.VisibleInsideMask;
    }

    private void Update() {
        if (followsPath) {
            if (pointsIndex <= Points.Length - 1) {
                transform.position = Vector3.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);

                if (transform.position == Points[pointsIndex].transform.position) {
                    pointsIndex++;
                }
            }
            else {
                pointsIndex = 0;
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
