using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private bool playerInRange = false;
    private GameObject player;
    public GameObject starPrefab;
    public float spawnRadius = 1.5f;
    private bool starsSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!starsSpawned && other.gameObject.CompareTag("Player"))
        {

            animator.SetTrigger("open");
            SpawnStars();
            starsSpawned = true;
        }
    }

    void SpawnStars()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            Vector2 randomPosition = (Vector2)transform.position + randomDirection * Random.Range(0f, spawnRadius);
            Instantiate(starPrefab, randomPosition, Quaternion.identity);
        }
    }
}
