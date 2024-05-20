using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private int border = 21;
    private int radius;
    [SerializeField] GameObject obstacle;
    [SerializeField] GameObject enemy;
    void Start()
    {
        StartCoroutine(SpawnObstacle());
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnObstacle()
    {
        Instantiate(obstacle, new Vector3(Random.Range(-border, border), 0.5f, Random.Range(-border, border)), Quaternion.identity);
        yield return new WaitForSeconds(5);
        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnEnemy()
    {
        //Setting spawn direction
        Vector3 spawnDirection = Random.onUnitSphere;
        spawnDirection.y = 0;
        spawnDirection.Normalize();

        //Setting spawn position based on direction + player position
        radius = Random.Range(3, 6);
        Vector3 spawnPosition = GameObject.Find("Player").transform.position + spawnDirection * radius;

        Instantiate(enemy, spawnPosition, Quaternion.identity);
        yield return new WaitForSeconds(2);
        StartCoroutine(SpawnEnemy());
    }
}
