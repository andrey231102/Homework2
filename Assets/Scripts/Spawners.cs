using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPattern;
    [SerializeField] private float _spawnTime;
    
    private void Start()
    {
        Transform[] spawnersLocation = GetComponentsInChildren<Transform>();
        StartCoroutine(SpawnSubject(_enemyPattern, spawnersLocation, _spawnTime));
    }

    private IEnumerator SpawnSubject(GameObject subjectPattern, Transform[] subjects, float time)
    {
        var spawnTime = new WaitForSeconds(time);
        while (true)
        {  
            yield return spawnTime;
            Instantiate(subjectPattern, subjects[Random.Range(0, subjects.Length)].transform);
        }
    }
}
