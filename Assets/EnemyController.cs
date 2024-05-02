using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private GameObject player;
    private PlayerHealth playerHealth;
   // public int damageAmount = 10;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
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
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage();
           
        }

    }
    private void Update()
    {
        
    }
    public void Die()
    {
        animator.SetTrigger("Die");
    }

}
