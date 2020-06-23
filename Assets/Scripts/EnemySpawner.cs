using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public DebugInput input;

    private void Update()
    {
        if (input.OnDebugEnemySpawn())
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        Element element = new Element((Type)Random.Range(1, 4));
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemy.GetComponent<EnemyAvatar>().ownElement = element;
    }
}
