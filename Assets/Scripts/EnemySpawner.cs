using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] enemyList;
    public Transform[] spawnPoints;
    public DebugInput input;
    private int generated = 0;
    public EnemyDoor associatedDoor;
    public int killCount = 0;

    private void Update()
    {
        if (input && input.OnDebugEnemySpawn())
        {
            SpawnEnemy();
        }
        if (associatedDoor && killCount == enemyList.Length)
        {
            associatedDoor.Die(gameObject);
        }
    }

    private void Start()
    {
        for (int i = 0; i < enemyList.Length; i++)
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        if (enemyList.Length > 0 && generated < enemyList.Length)
        {
            GameObject enemy = Instantiate(enemyList[generated], spawnPoints[generated].position, spawnPoints[generated].rotation);
            enemy.GetComponent<EnemyAvatar>().spawner = this;
            generated++;
        }
        else
        {
            int prefab = Random.Range(0, enemyPrefabs.Length);
            int position = Random.Range(0, spawnPoints.Length);
            Element element = new Element((Type)prefab + 1);
            GameObject enemy = Instantiate(enemyPrefabs[prefab], spawnPoints[position].position, Quaternion.identity);
            enemy.GetComponent<EnemyAvatar>().ownElement = element;
        }
    }
}
