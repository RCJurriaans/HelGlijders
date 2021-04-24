using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject FloorPrefab;
    public GameObject ObstaclePrefab;
    [SerializeField] private Transform Geometry;
    [SerializeField] private Transform SpawnPosition;

    void Start()
    {
        transform.localRotation = Quaternion.AngleAxis(45 + Random.value*-10f, Vector3.right);

        for (int i = 0; i < 2; i++)
        {
            Vector3 randomPosition = RandomPointInBox(Geometry.GetComponent<BoxCollider>().bounds);
            Instantiate(ObstaclePrefab, randomPosition, transform.rotation);
        }
    }

    public void SpawnNextFloor()
    {
        Instantiate(FloorPrefab, SpawnPosition.position, new Quaternion(0f,0f,0f,0f));
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private Vector3 RandomPointInBox(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }


}