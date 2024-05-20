using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private PlayerController player;

    private float projectileSpeed = 7.0f;
    private Vector3 mousePosition;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        mousePosition = player.mousePosition;
        transform.position = Vector3.MoveTowards(transform.position, mousePosition, projectileSpeed * Time.deltaTime);
    }

}
