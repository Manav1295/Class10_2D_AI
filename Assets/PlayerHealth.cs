using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int maxLife = 3;
    // public Animator lifeAnimator;
    [SerializeField] Animator anim;
    public int currentLife = 3;
    [SerializeField] LifeController lifeUI;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioSource audioSrc;
    [SerializeField] private Rigidbody2D rbody;
    void Start()
    {
        currentLife = maxLife;
        lifeUI.SetLifeAmount(currentLife);
    }
    private void FixedUpdate()
    {
        if (currentLife == 0){
            anim.SetTrigger("Die");
            //audioSrc.PlayOneShot(deathSound);
             rbody.velocity = Vector2.zero;
            rbody.angularVelocity = 0f;

        }
        
    }
    /*private void FixedUpdate()
    {
        
    }*/
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Flower"))
        {
           
            TakeDamage();

            
        }
        /*else if (other.gameObject.CompareTag("Plant_Enemy"))
        {

            TakeDamage();

        }*/
        else if (other.gameObject.CompareTag("Carrot"))
        {

            TakeLife();

        }
        
    }

    public void TakeDamage()
    {
        if (currentLife > 0)
        {
            currentLife--;
            anim.SetTrigger("isHurt");
            lifeUI.SetLifeAmount(currentLife);
            
            // lifeAnimator.SetInteger("Life", currentLife);
        }
        if(currentLife == 0)
        {
            audioSrc.PlayOneShot(deathSound);
        }
    }
    public void TakeLife()
    {
        if (currentLife < maxLife)
        {
            currentLife++;
            lifeUI.SetLifeAmount(currentLife);
            //lifeAnimator.SetInteger("Life", currentLife);
        }
    }
    
}
