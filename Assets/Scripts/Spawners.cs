using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject[] spawners = new GameObject[5];
    void Start()
    {
        StartCoroutine(SpawnObject(spawners));
    }

    IEnumerator SpawnObject(GameObject[] objects)
    {
        int spawnersNumber; 
        var spawnTime = new WaitForSeconds(2f);
        while (true)
        {  
            spawnersNumber = Random.Range(0, spawners.Length);
            yield return spawnTime;
            Instantiate(_enemy, spawners[spawnersNumber].transform);
        }
    }
}
