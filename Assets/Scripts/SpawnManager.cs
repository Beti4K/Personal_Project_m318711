using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private int border = 21;
    [SerializeField] GameObject obstacle;
    [SerializeField] GameObject enemy;
    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnObstacle()
    {
        Instantiate(obstacle, new Vector3(Random.Range(-border, border), 0.5f, Random.Range(-border, border)), transform.rotation);
        yield return new WaitForSeconds(5);
        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnEnemy()
    {
        Instantiate(enemy, new Vector3(Random.Range(-border, border), 0.5f, Random.Range(-border, border)), transform.rotation);
        yield return new WaitForSeconds(5);
        StartCoroutine(SpawnEnemy());
    }
}
