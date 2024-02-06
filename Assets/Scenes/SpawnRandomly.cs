using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomly : MonoBehaviour
{
    public GameObject[] prefabs; // Array to hold the prefabs to instantiate

    public int numberOfPrefabs = 5; // Number of prefabs to instantiate
    public float spawnDelay = 0.5f; // Delay between spawning each prefab
    public float moveSpeed = 2f; // Speed of movement between points
    public Transform[] movePoints; // Array of points to move between
    private int currentMovePointIndex = 0; // Index to track the current move point

    void Start()
    {
        // Start spawning prefabs and moving between points
        StartCoroutine(SpawnAndMove());
    }

    IEnumerator SpawnAndMove()
    {
        while (true)
        {
            // Spawn prefabs at the current position with delay
            yield return StartCoroutine(SpawnPrefabs());

            // Move between points
            yield return MoveBetweenPoints(movePoints[currentMovePointIndex], movePoints[(currentMovePointIndex + 1) % movePoints.Length]);
        }
    }

    IEnumerator MoveBetweenPoints(Transform startPoint, Transform endPoint)
    {
        float journeyLength = Vector3.Distance(startPoint.position, endPoint.position);
        float journeyTime = journeyLength / moveSpeed;
        float elapsedTime = 0f;

        while (elapsedTime < journeyTime)
        {
            transform.position = Vector3.Lerp(startPoint.position, endPoint.position, (elapsedTime / journeyTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPoint.position; // Ensure it reaches the exact destination
        currentMovePointIndex = (currentMovePointIndex + 1) % movePoints.Length; // Update current move point index
    }

    IEnumerator SpawnPrefabs()
    {
        // Get the bounds of the parent GameObject
        Bounds bounds = GetComponent<SpriteRenderer>().bounds;

        // Loop to instantiate prefabs
        for (int i = 0; i < numberOfPrefabs; i++)
        {
            // Generate random position within the bounds of the parent GameObject
            Vector2 randomPosition = new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));

            // Choose a random prefab from the array
            GameObject randomPrefab = prefabs[Random.Range(0, prefabs.Length)];

            // Instantiate the chosen prefab at the random position
            GameObject pf = Instantiate(randomPrefab, randomPosition, Quaternion.identity, transform);

            // Wait for the specified delay before spawning the next prefab
            yield return new WaitForSeconds(spawnDelay);

            

        }
    }
}



