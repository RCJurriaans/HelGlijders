using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject FloorPrefab;
    [SerializeField] private Transform SpawnPosition;

    void Start()
    {
        transform.localRotation = Quaternion.AngleAxis(45 + Random.value*-10f, Vector3.right);
    }

    public void SpawnNextFloor()
    {
        Instantiate(FloorPrefab, SpawnPosition.position, new Quaternion(0f,0f,0f,0f));
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
