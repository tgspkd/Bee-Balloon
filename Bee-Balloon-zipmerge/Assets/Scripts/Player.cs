    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 startPos3D = new Vector3(0, 0, 0);
    Vector3 mousePos2D;
    Vector3 mousePosition;
    public bool inKillZonePath = false;

    Vector3 offset;
    private Rigidbody2D selectedObject;
    public float sensitivity = 20;
    private bool move = false;


    // Start is called before the first frame update
    void Awake()
    {
        // Always move Rigidbody, but lock transform.position when collision
        selectedObject = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current mouse position in 2D screen coordinates
        mousePos2D = Input.mousePosition;
        // The Camera's z position sets how far to push the mouse into 3D, "connects" the object to the world
        mousePos2D.z = -Camera.main.transform.position.z;
        // Convert the point from 2D screen space into 3D game world space
        mousePosition = Camera.main.ScreenToWorldPoint(mousePos2D);
        // Transform pos mouse (regular code)
    }

    void FixedUpdate()
    {
        if (selectedObject && move)
        {
            selectedObject.velocity = (mousePosition - transform.position) * sensitivity;
        }
    }

    private void OnMouseOver()
    {
        move = true;
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
        move = false;
    }
}
