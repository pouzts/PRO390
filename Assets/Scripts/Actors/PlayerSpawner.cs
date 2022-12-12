using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private Transform spawnTransform;

    public Transform SpawnTransform { get; set; }

    public void Start()
    {
        SpawnTransform = spawnTransform;
    }

    public void SpawnPlayer()
    {
        Instantiate(playerObject, spawnTransform);
    }
}
