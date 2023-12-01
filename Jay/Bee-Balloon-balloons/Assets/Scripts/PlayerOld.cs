using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class PlayerOld : MonoBehaviour
{
    Vector3 startPos3D = new Vector3(0, 0, 0);
    Vector3 mousePos2D;
    private bool collided;
    public bool inKillZonePath = false;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Walls")
        {
            Debug.Log("Collided with wall");
            transform.position = startPos3D;
            
            // Freeze
            collided = true;
        }
        else if (coll.gameObject.tag == "KillZonePath") inKillZonePath = true;
        
    }

    private void OnCollisionExit2D(Collision2D coll) {
        if (coll.gameObject.tag == "KillZonePath") inKillZonePath = false;
    }

    void OnMouseDrag()
    {
        if (collided == true) {
            return;
        } 
        // Get the current mouse position in 2D screen coordinates
        mousePos2D = Input.mousePosition;
        // The Camera's z position sets how far to push the mouse into 3D, "connects" the object to the world
        mousePos2D.z = -Camera.main.transform.position.z;
        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        this.transform.position = mousePos3D;
    }

    private

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
*/