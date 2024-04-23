using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public float turnSpeed;
    public int health;
    int score;
    int highScore;
    public TMP_Text healthDisplay;
    public TMP_Text scoreDisplay;
    public GameObject gameOverMenu; // Reference to the game over menu object
    public Spawner enemySpawner; // Reference to the enemy spawner
    public GameObject explosionEffectPrefab; // Reference to the explosion effect prefab
    public Button button;
    public AudioSource audio;


    private bool isGameOver = false; // Flag to track if the game is over

    // Start is called before the first frame update
    void Start()
    {
        // Make sure the game over menu is initially deactivated
        gameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the player
        if (!isGameOver) // Ensure player can't rotate if the game is over
        {
            transform.Rotate(Vector3.forward * turnSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime);
        }
    }

    public void TakeDamageEnemy()
    {
        health--;
        UpdateHealthDisplay();
        if (health <= 0)
        {
            GameOver();
        }
    }

    public void TakeDamageBomb()
    {
        health -= 5;
        UpdateHealthDisplay();
        if (health <= 0)
        {
            GameOver();
        }
    }

    public void AddScore(int multiplier = 1)
    {
        score += multiplier;
        scoreDisplay.text = "Score:" + score;

        if (score > highScore)
        {
            highScore = score;
           
        }
    }

    void GameOver()
    {
        isGameOver = true; // Set the game over flag

        healthDisplay.text = "Health:0";
        // Instantiate explosion effect
        audio.Play();
        Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);

        // Disable the player object
        gameObject.SetActive(false);

        // Stop enemy spawning
        enemySpawner.enabled = false;

        // Destroy all enemy objects in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        // Show the game over menu
        gameOverMenu.SetActive(true);
        button.onClick.AddListener(ReloadScene); // Add listener to the button for reloading scene
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    public void ReloadScene()
    {
        // Reload the scene
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    void UpdateHealthDisplay()
    {
        healthDisplay.text = "Health:" + health;
    }
    
}