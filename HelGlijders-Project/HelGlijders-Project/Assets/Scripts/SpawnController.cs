using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject FloorPrefab;
    public GameObject[] ObstaclePrefabs;
    [SerializeField] private Transform Geometry;
    [SerializeField] private Transform SpawnPosition;

    int randomInt;

    private List<GameObject> obstacles;

    void Start()
    {
        Quaternion spawnRotation = new Quaternion(0.5f - Random.value*0.15f, 0.05f - Random.value*0.1f, 0f, 1f);
        transform.localRotation = spawnRotation;

        obstacles = new List<GameObject>();

        for(int i=0; i<6; i++)
        {
            obstacles.Add(SpawnRandom());
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
        Vector3 randomPoint = Geometry.TransformPoint(new Vector3(Random.Range(-0.5f, 0.5f), 0.5f, Random.Range(-0.5f, 0.5f)));
        return randomPoint;
    }

    GameObject SpawnRandom()
    {
        randomInt = Random.Range(0, ObstaclePrefabs.Length);
        GameObject randomObstacle = Instantiate(ObstaclePrefabs[randomInt], getRandomPosition(), Geometry.rotation * new Quaternion(0f, Random.value * 1f, 0f, 1f));
        randomObstacle.transform.localScale = new Vector3(1.25f -Random.value*.5f, 1.25f-Random.value*.5f, 1.25f-Random.value*.5f);
        return randomObstacle;
    }
}