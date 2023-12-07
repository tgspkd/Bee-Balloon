using static System.DateTime;
using UnityEngine;

public class BalloonRegion : MonoBehaviour
{
    public GameObject balloonPrefab;
    public float minSize = 1f;
    public float maxSize = 3f;
    public int seed = 0;

    void Awake()
    {
        if (seed == 0) seed = (int)System.DateTime.Now.Ticks;
        Random.InitState(seed);
        Spawn();
    }

    void Spawn() {
        // Get width and height of container
        Bounds bounds = GetComponent<BoxCollider2D>().bounds;
        float width = bounds.extents.x ;
        float height = bounds.extents.y; 

        // Prevents balloons from having center point on edge
        float xMod = bounds.min.x;
        float yMod = bounds.min.y;

        // Calculate the number of rows and columns
        int rows = Mathf.Max(Mathf.FloorToInt(height / (maxSize * .5f)), 1);
        int columns = Mathf.Max(Mathf.FloorToInt(width / (maxSize * .5f)), 1);

        // Spawn balloons in a grid
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // Generate random size for balloon
                float size = Random.Range(minSize, maxSize);

                // global x position of balloon
                float x = col * maxSize + (size / 2);
                float y = row * maxSize + (size / 2);

                GameObject balloon = Instantiate(balloonPrefab, new Vector3(xMod + x, yMod + y, 0), Quaternion.identity);
                balloon.transform.localScale = new Vector2(size, size);

                // sets the parent to be this container
                // makes setting scale and position much easier doing it this way
                balloon.transform.parent = transform;
            }
        }
    }
}