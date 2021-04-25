using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject FloorPrefab;
    public GameObject ObstaclePrefab;
    [SerializeField] private Transform Geometry;
    [SerializeField] private Transform SpawnPosition;

    private List<GameObject> obstacles;

    void Start()
    {
        Quaternion spawnRotation = new Quaternion(0.5f - Random.value*0.15f, 0.05f - Random.value*0.1f, 0f, 1f);
        transform.localRotation = spawnRotation;

        obstacles = new List<GameObject>();

        for(int i=0; i<3; i++)
        {
            GameObject newObstacle = Instantiate(ObstaclePrefab, getRandomPosition(), Geometry.rotation);
            obstacles.Add(newObstacle);
        }

    }   

    public void SpawnNextFloor()
    {
        Instantiate(FloorPrefab, SpawnPosition.position, new Quaternion(0f,0f,0f,0f));
    }

    public void Destroy()
    {
        foreach(GameObject obstacle in obstacles)
        {
            Destroy(obstacle);
        }
        Destroy(gameObject);
    }
    Vector3 getRandomPosition()
    {
        Vector3 randomPoint = Geometry.TransformPoint(new Vector3(Random.Range(-0.5f, 0.5f), 1f, Random.Range(-0.5f, 0.5f)));
        return randomPoint;
    }
}