using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] powerUpPrefabs; // The array of power-up prefabs
    [SerializeField] private float spawnProbability = 0.01f; // 1% spawn probability per frame
    [SerializeField] private Vector3 spawnAreaMin; // Minimum bounds for spawning area (including z)
    [SerializeField] private Vector3 spawnAreaMax; // Maximum bounds for spawning area (including z)
    [SerializeField] private float spawnCooldown = 60f; // Cooldown time in seconds

    private bool canSpawn = true;

    void Update()
    {
        TrySpawnPowerUp();
    }

    private void TrySpawnPowerUp()
    {
        if (canSpawn && Random.Range(0f, 1f) < spawnProbability)
        {
            SpawnPowerUp();
            StartCoroutine(SpawnCooldown());
        }
    }

    private void SpawnPowerUp()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y),
            Random.Range(spawnAreaMin.z, spawnAreaMax.z)
        );

        int randomIndex = Random.Range(0, powerUpPrefabs.Length);
        Instantiate(powerUpPrefabs[randomIndex], spawnPosition, Quaternion.identity);
    }

    private IEnumerator SpawnCooldown()
    {
        canSpawn = false;
        yield return new WaitForSeconds(spawnCooldown);
        canSpawn = true;
    }

    // Debugging: Draw the spawn area in the scene view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(spawnAreaMin.x, spawnAreaMin.y, spawnAreaMin.z), new Vector3(spawnAreaMin.x, spawnAreaMax.y, spawnAreaMin.z));
        Gizmos.DrawLine(new Vector3(spawnAreaMin.x, spawnAreaMax.y, spawnAreaMin.z), new Vector3(spawnAreaMax.x, spawnAreaMax.y, spawnAreaMin.z));
        Gizmos.DrawLine(new Vector3(spawnAreaMax.x, spawnAreaMax.y, spawnAreaMin.z), new Vector3(spawnAreaMax.x, spawnAreaMin.y, spawnAreaMin.z));
        Gizmos.DrawLine(new Vector3(spawnAreaMax.x, spawnAreaMin.y, spawnAreaMin.z), new Vector3(spawnAreaMin.x, spawnAreaMin.y, spawnAreaMin.z));

        Gizmos.DrawLine(new Vector3(spawnAreaMin.x, spawnAreaMin.y, spawnAreaMax.z), new Vector3(spawnAreaMin.x, spawnAreaMax.y, spawnAreaMax.z));
        Gizmos.DrawLine(new Vector3(spawnAreaMin.x, spawnAreaMax.y, spawnAreaMax.z), new Vector3(spawnAreaMax.x, spawnAreaMax.y, spawnAreaMax.z));
        Gizmos.DrawLine(new Vector3(spawnAreaMax.x, spawnAreaMax.y, spawnAreaMax.z), new Vector3(spawnAreaMax.x, spawnAreaMin.y, spawnAreaMax.z));
        Gizmos.DrawLine(new Vector3(spawnAreaMax.x, spawnAreaMin.y, spawnAreaMax.z), new Vector3(spawnAreaMin.x, spawnAreaMin.y, spawnAreaMax.z));

        Gizmos.DrawLine(new Vector3(spawnAreaMin.x, spawnAreaMin.y, spawnAreaMin.z), new Vector3(spawnAreaMin.x, spawnAreaMin.y, spawnAreaMax.z));
        Gizmos.DrawLine(new Vector3(spawnAreaMin.x, spawnAreaMax.y, spawnAreaMin.z), new Vector3(spawnAreaMin.x, spawnAreaMax.y, spawnAreaMax.z));
        Gizmos.DrawLine(new Vector3(spawnAreaMax.x, spawnAreaMax.y, spawnAreaMin.z), new Vector3(spawnAreaMax.x, spawnAreaMax.y, spawnAreaMax.z));
        Gizmos.DrawLine(new Vector3(spawnAreaMax.x, spawnAreaMin.y, spawnAreaMin.z), new Vector3(spawnAreaMax.x, spawnAreaMin.y, spawnAreaMax.z));
    }
}
