using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 15, 0);
    [SerializeField] GameObject player;
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
