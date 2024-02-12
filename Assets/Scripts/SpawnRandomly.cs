using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomly : MonoBehaviour
{
    public GameObject[] prefabs; // Array to hold the prefabs to instantiate

    public int numberOfPrefabs = 5; // Number of prefabs to instantiate
    public float minSpawnDelay = 5f; // Minimum spawn delay
    public float maxSpawnDelay = 10f; // Maximum spawn delay
    public float spawnDelay;
    public float moveSpeed = 2f; // Speed of movement between points
    public Transform[] movePoints; // Array of points to move between
    private int currentMovePointIndex = 0; // Index to track the current move point
    private bool isSpawningAndMoving = false; // Flag to track if spawning and moving are in progress


    void Start()
    {
        spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);

        // Start spawning prefabs and moving between points
        StartCoroutine(SpawnAndMove());
    }

    private void Update()
    {
        spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
    }

    IEnumerator SpawnAndMove()
    {
        while (true)
        {
            // Check if spawning and moving are not already in progress
            if (!isSpawningAndMoving)
            {
                isSpawningAndMoving = true; // Set the flag to indicate spawning and moving are in progress

                // Spawn prefabs at the current position without delay
                StartCoroutine(SpawnPrefabs());

                // Move between points
                yield return MoveBetweenPoints(movePoints[currentMovePointIndex], movePoints[(currentMovePointIndex + 1) % movePoints.Length]);

                isSpawningAndMoving = false; // Reset the flag once spawning and moving are done
            }
            else
            {
                yield return null; // Wait for the current spawning and moving process to finish
            }
        }
    }

    IEnumerator SpawnPrefabs()
    {
        for (int i = 0; i < numberOfPrefabs; i++)
        {
            // Instantiate the chosen prefab at the current position
            GameObject randomPrefab = prefabs[Random.Range(0, prefabs.Length)];
            GameObject pf = Instantiate(randomPrefab, transform.position, Quaternion.identity);

            // Wait for the specified delay before spawning the next prefab
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    IEnumerator MoveBetweenPoints(Transform startPoint, Transform endPoint)
    {
        float journeyLength = Vector3.Distance(startPoint.position, endPoint.position);
        float journeyTime = journeyLength / moveSpeed;
        float elapsedTime = 0f;

        while (elapsedTime < journeyTime)
        {
            gameObject.transform.position = Vector3.Lerp(startPoint.position, endPoint.position, (elapsedTime / journeyTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        gameObject.transform.position = endPoint.position; // Ensure it reaches the exact destination
        currentMovePointIndex = (currentMovePointIndex + 1) % movePoints.Length; // Update current move point index
    }

    
}

    




