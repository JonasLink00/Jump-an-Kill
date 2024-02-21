using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawnerLeft : MonoBehaviour
{
    private bool _isEnemySpawed;
    //Prefabs Verwendungs Möglichkeit
    [SerializeField]
    private GameObject EnemyLeft;

    [SerializeField]
    private float spawnInterval = 8f;

    
    private void Update()
    {
        Spawn();
    }
    private void Spawn()
    {
        //bool verhindert dauerSpawn der Enemies 
        if (!_isEnemySpawed)
        {
            StopCoroutine(nameof(SpawnEnemy));
            StartCoroutine(nameof(SpawnEnemy));
        }
    }

    private IEnumerator SpawnEnemy()
    {
        _isEnemySpawed = true;
        GameObject newEnemy = Instantiate(EnemyLeft, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(spawnInterval);
        _isEnemySpawed = false;
    }


}
