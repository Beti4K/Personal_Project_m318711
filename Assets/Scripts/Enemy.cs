using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private float speed = 2.0f;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if(player.GetComponent<PlayerController>().isGameActive)
        {
            transform.LookAt(player.GetComponent<Transform>());
            transform.position = Vector3.MoveTowards(transform.position, player.GetComponent<Transform>().position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerController>().TakeDamage(1);
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
            player.GetComponent<PlayerController>().GainScore(10);
        }
    }
}
