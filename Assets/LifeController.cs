using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{

    public Animator lifeAnimator;
   private GameObject player;
    private PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
        //player = GameObject.FindWithTag("Player");
       //playerHealth = player.GetComponent<PlayerHealth>();

        lifeAnimator.SetInteger("Life", 3);

    }
    public void SetLifeAmount(int amount)
    {
        lifeAnimator.SetInteger("Life", amount);
    }
    //// Update is called once per frame
    //public void Update()
    //{
    //    int currentLife = playerHealth.currentLife;
    //    lifeAnimator.SetInteger("Life", currentLife);
    //}
}
