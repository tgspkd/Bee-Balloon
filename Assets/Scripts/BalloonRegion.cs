using UnityEngine;

public class BalloonRegion : MonoBehaviour
{
    public GameObject balloonPrefab;
    public int numBalloons = 10;
    public float minSize = 1f;
    public float maxSize = 3f;

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        for (int i = 0; i < numBalloons; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-.5f, .5f),
                Random.Range(-.5f, .5f),
                0f
            );

            float randomSize = Random.Range(minSize, maxSize);

            GameObject balloon = Instantiate(balloonPrefab, transform);


            balloon.transform.localPosition = randomPosition;
            balloon.transform.localScale = new Vector3(randomSize / transform.lossyScale.x, randomSize / transform.lossyScale.y, 1f);

            if (Overlap(balloon))
            {
                Destroy(balloon);
                i--;
            }
        }
    }

    // This does NOT work
    bool Overlap(GameObject newBaloon)
    {
        Collider2D newCollider = newBaloon.GetComponent<Collider2D>();

        if (newCollider == null)
        {
            Debug.LogError("Balloon has no collider?");
            return false;
        }

        Collider2D[] colliders = Physics2D.OverlapCircleAll(newBaloon.transform.position, newCollider.bounds.extents.x);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.tag == "Balloon" && collider != newCollider)
            {
                if (newCollider.bounds.Intersects(collider.bounds))
                {
                    return true;
                }
            }
        }

        return false;
    }
}