using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject GameOverScreen;
    [SerializeField] GameObject StartScreen;
    [SerializeField] TextMeshProUGUI healthDisplay;
    [SerializeField] TextMeshProUGUI scoreDisplay;

    private float speed = 5.0f;

    public Vector3 mousePosition;

    public int health;
    public int score;
    public int maxHealth;

    public bool isGameActive = false;
    void Start()
    {
        maxHealth = 5;
        health = maxHealth;
        healthDisplay.text = "Health: " + health + "/" + maxHealth;
        scoreDisplay.text = "Score: " + score;
    }

    public void StartGame()
    {
        isGameActive = true;
        StartScreen.SetActive(false);
        GameObject.Find("SpawnManager").GetComponent<SpawnManager>().StartSpawn();
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
            health = 0;
            GameOver();
        }
    }

    public void GainScore(int amount)
    {
        score += amount;
        scoreDisplay.text = "Score: " + score;
    }

    void GameOver()
    {
        isGameActive = false;
        GameOverScreen.SetActive(true);
    }
}
