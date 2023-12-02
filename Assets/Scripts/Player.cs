using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 startPos3D = new Vector3(0, 0, 0);
    Vector3 mousePosition;
    private bool collided = false;
    public bool inKillZonePath = false;

    Vector3 offset;
    private Rigidbody2D selectedObject;

    // Start is called before the first frame update
    void Start()
    {
    }

// Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);

            if (targetObject)
            {
                selectedObject = targetObject.transform.gameObject.GetComponent<Rigidbody2D>();
                offset = selectedObject.transform.position - mousePosition;
            }
        }
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            selectedObject = null;
        }
    }

    void FixedUpdate()
    {
        if (selectedObject)
        {
            selectedObject.MovePosition(mousePosition + offset);
        }
    }


    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Walls")
        {
            Debug.Log("Collided with wall");
        }
        //else if (coll.gameObject.tag == "KillZonePath") inKillZonePath = true;
        else if (coll.gameObject.tag == "KillZone") {
            Debug.Log("Killed!");
            Reset();
        } 

    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "KillZonePath") inKillZonePath = false;
    }

    // I added this function since the bombs also have to reset the player back to the start
    public void Reset()
    {
        transform.position = startPos3D;
        collided = true;
    }

    public void WarpMouse()
    {

    }

}
