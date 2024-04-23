using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    public int scoreMultiplier = 2;
    public float speed;
    Player player;
    public GameObject effect;
    public GameObject audioSourcePrefab; // Reference to the AudioSource prefab
    private AudioSource audioSource; // Declare AudioSource field

    void Start()
    {
        player = FindObjectOfType<Player>();
        GameObject audioSourceObject = Instantiate(audioSourcePrefab);
        audioSource = audioSourceObject.GetComponent<AudioSource>(); // Assign AudioSource
    }

    void Update()
    {
        if (player != null) // Check if player is not null
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hole")
        {
            player.AddScore(scoreMultiplier);
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
            audioSource.Play();
        }

        if (other.tag == "Player" || other.tag == "Enemy")
        {
            player.TakeDamageBomb();
            speed = 0;
            transform.parent = player.transform;
            
           
        }
    }
}
