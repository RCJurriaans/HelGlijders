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
        transform.localRotation = Quaternion.AngleAxis(45 + Random.value*-10f, Vector3.right);

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