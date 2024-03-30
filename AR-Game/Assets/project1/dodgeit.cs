using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float obstacleSpeed = 1f;
    public float spawnInterval = 2f;
    public float minSpawnDistance = 2f;
    public float maxSpawnDistance = 5f;

    private float timer;
    private ARSessionOrigin arSessionOrigin;

    void Start()
    {
        timer = 0f;
        arSessionOrigin = FindObjectOfType<ARSessionOrigin>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        // Calculate a random distance for the obstacle to spawn
        float spawnDistance = Random.Range(minSpawnDistance, maxSpawnDistance);

        // Calculate spawn position in world space based on the spawn distance
        Vector3 spawnPosition = arSessionOrigin.camera.transform.position + arSessionOrigin.camera.transform.forward * spawnDistance;

        // Instantiate the obstacle at the spawn position
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // Set obstacle's forward direction towards the camera
        obstacle.transform.LookAt(arSessionOrigin.camera.transform);

        // Apply constant movement towards the camera
        Rigidbody obstacleRigidbody = obstacle.GetComponent<Rigidbody>();
        if (obstacleRigidbody != null)
        {
            obstacleRigidbody.velocity = obstacle.transform.forward * obstacleSpeed;
        }
    }
}
