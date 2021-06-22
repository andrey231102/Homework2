using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawners : MonoBehaviour
{
    [SerializeField] private GameObject _enemyTemplate;
    [SerializeField] private float _periodOfSpawn;

    private void Start()
    {
        Transform[] spawnersLocation = new Transform[transform.childCount];

        for (int i = 0; i < spawnersLocation.Length; i++)
        {
            spawnersLocation[i] = transform.GetChild(i);
        }

        StartCoroutine(SpawnEnemy(_enemyTemplate, spawnersLocation, _periodOfSpawn));
    }

    private IEnumerator SpawnEnemy(GameObject enemyTemplate, Transform[] spawnersLocation, float time)
    {
        var periodOfSpawn = new WaitForSeconds(time);
        while (true)
        {
            yield return periodOfSpawn;
            Instantiate(enemyTemplate, spawnersLocation[Random.Range(0, spawnersLocation.Length)].transform);
        }
    }
}