using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    Player player;
    public GameObject effect;
    public GameObject audioSourcePrefab; // Reference to the AudioSource prefab
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        GameObject audioSourceObject = Instantiate(audioSourcePrefab);
        audioSource = audioSourceObject.GetComponent<AudioSource>(); // Assign AudioSource
    }

    // Update is called once per frame
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
            player.AddScore();
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
            audioSource.Play(); // Use audioSource declared in Start()
        }

        if (other.tag == "Player" || other.tag == "Enemy")
        {
            player.TakeDamageEnemy();
            speed = 0;
            transform.parent =player.transform;
        }
    }
}
