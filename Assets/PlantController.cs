using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    private Animator animator;
    private bool playerInRange = false;

    public float attackRange = 2f;
    private GameObject player;
    
   private PlayerHealth playerHealth;
    public int damageAmount = 10;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= attackRange)
        {
            playerInRange = true;
            animator.SetTrigger("Attack");
        }
        else
        {
            playerInRange = false;
            animator.SetTrigger("DontAttack");
        }
        

    }
    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //if (transform.position.y > other.gameObject.transform.position.y)
            //{
            playerHealth.TakeDamage();
            //}


        }
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage();
        }

    }
    /*void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
        }
    }*/
}
