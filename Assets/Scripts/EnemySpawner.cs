using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
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
        int index = Random.Range(0, enemyPrefabs.Length);
        Element element = new Element((Type) index + 1);
        GameObject enemy = Instantiate(enemyPrefabs[index], spawnPoint.position, spawnPoint.rotation);
        enemy.GetComponent<EnemyAvatar>().ownElement = element;
    }
}
