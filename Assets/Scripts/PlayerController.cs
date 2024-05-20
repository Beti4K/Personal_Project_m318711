using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject GameOverScreen;
    [SerializeField] TextMeshProUGUI healthDisplay;

    private float speed = 5.0f;

    public int health;
    public int maxHealth;

    public bool isGameActive = true;
    void Start()
    {
        maxHealth = 5;
        health = maxHealth;
        healthDisplay.text = "Health: " + health + "/" + maxHealth;
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (isGameActive)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            transform.position += new Vector3(horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime);
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        healthDisplay.text = "Health: " + health + "/" + maxHealth;
        if (health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isGameActive = false;
        GameOverScreen.SetActive(true);
    }
}
