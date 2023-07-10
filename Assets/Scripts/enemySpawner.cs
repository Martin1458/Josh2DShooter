using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemy;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            int wait_time = UnityEngine.Random.Range(2, 8);
            yield return new WaitForSeconds(wait_time);

            Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }
}