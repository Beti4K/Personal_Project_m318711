using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private int radius;
    [SerializeField] GameObject obstacle;
    [SerializeField] GameObject enemy;
    void Start()
    {
        StartCoroutine(SpawnObject(obstacle, 5, 7, 5));
        StartCoroutine(SpawnObject(enemy, 3, 6, 2));
    }

    IEnumerator SpawnObject(GameObject prefab, int min, int max, int time)
    {
        //Setting spawn directions
        Vector3 spawnDirection = Random.onUnitSphere;
        spawnDirection.y = 0;
        spawnDirection.Normalize();

        //Setting spawn position based on direction + player position
        radius = Random.Range(min, max);
        Vector3 spawnPosition = GameObject.Find("Player").transform.position + spawnDirection * radius;

        Instantiate(prefab, spawnPosition, Quaternion.identity);
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnObject(prefab, min, max, time));
    }
}
