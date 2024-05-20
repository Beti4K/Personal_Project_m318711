using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private float speed = 4.0f;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3.Lerp(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
