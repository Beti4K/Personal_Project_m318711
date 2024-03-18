using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -24)
        {
            transform.Translate(Vector3.left);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < 24)
        {
            transform.Translate(Vector3.right);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.z > -24)
        {
            transform.Translate(Vector3.back);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.z < 24)
        {
            transform.Translate(Vector3.forward);
        }
    }
}
