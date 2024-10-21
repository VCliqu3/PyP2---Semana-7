using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpawnerManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Transform enemyPrefab;

    [Header("Settings")]
    [SerializeField] private List<Transform> spawnPositions;
    [Space]
    [SerializeField] private float timeToStartSpawning;
    [SerializeField] private float spawnInterval;
    [SerializeField] private bool enableSpawn;
    [Space]
    [SerializeField] private float safeDistanceFromEntity;

    private void Start()
    {
        StartCoroutine(SpawnEnemiesCoroutine());
    }

    private IEnumerator SpawnEnemiesCoroutine()
    {
        yield return new WaitForSeconds(timeToStartSpawning);

        while (enableSpawn)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        Transform chosenSpawnPosition = ChooseSpawnPosition();
        if (chosenSpawnPosition == null) return;

        Instantiate(enemyPrefab,chosenSpawnPosition.position, chosenSpawnPosition.rotation);
    }

    private Transform ChooseSpawnPosition()
    {
        List<Transform> validSpawnPositions = new List<Transform>();

        foreach (Transform potentialSpawnPos in spawnPositions)
        {
            if(!CheckCanSpawnEnemy(potentialSpawnPos)) continue;
            validSpawnPositions.Add(potentialSpawnPos);
        }

        if(validSpawnPositions.Count <= 0) return null;

        int randomIndex = Random.Range(0, validSpawnPositions.Count);
        return validSpawnPositions[randomIndex];
    }

    private bool CheckCanSpawnEnemy(Transform potentialSpawnPos)
    {
        Collider[] colliders = Physics.OverlapSphere(potentialSpawnPos.position, safeDistanceFromEntity);

        foreach(Collider collider in colliders)
        {
            if (collider.GetComponent<EnemyHealth>() != null) return false;
            if (collider.GetComponent<PlayerHealth>() != null) return false; 
        }

        return true;
    }
}
