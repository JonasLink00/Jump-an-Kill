using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawnerRight : MonoBehaviour
{
    
    private bool _isEnemySpawed;
    //Prefabs Verwendungs Möglichkeit
    [SerializeField]
    private GameObject EnemyRight;


    private float spawnInterval;
    [SerializeField]
    private float minispawntime;
    [SerializeField]
    private float maxispawntime;

    [SerializeField]
    int delay = 1200;
    private void Awake()
    {
        Thread.Sleep(delay);
        SetTimeUntilSpawn();
    }
    private void Update()
    {
        spawnInterval -= Time.deltaTime;

        if (spawnInterval <= 0)
        {
            GameObject newEnemy = Instantiate(EnemyRight, gameObject.transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }
    private void SetTimeUntilSpawn()
    {
        spawnInterval = Random.Range(minispawntime, maxispawntime);
    }
}
