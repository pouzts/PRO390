using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemyPrefabs = new();
    [SerializeField] private Transform enemySpawn;
    
    private bool hasSpawned = false;

    private void OnTriggerEnter(Collider other)
    {
        if ((enemySpawn == null && enemyPrefabs.Count <= 0) || hasSpawned)
            return;

        if (other.gameObject.CompareTag("Player"))
        {
            foreach (Enemy enemy in enemyPrefabs)
            {
                Instantiate(enemy, enemySpawn);
            }

            hasSpawned = true;
        }
    }
}
