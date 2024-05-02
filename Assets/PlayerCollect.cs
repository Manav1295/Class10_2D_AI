using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    public int starsCollected = 0;
    public int carrotCollected = 0;
    private GameObject player;
    [SerializeField] public TextMeshProUGUI starText;
    [SerializeField] private AudioClip starcollectSound;
    [SerializeField] private AudioClip carrotcollectSound;
    [SerializeField] private AudioSource audioSrc;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Star"))
        {
            
            starsCollected++;
            starText.text = starsCollected.ToString();
            audioSrc.PlayOneShot(starcollectSound);
            //Debug.Log(starsCollected);
            Destroy(other.gameObject);

        }
        if (other.gameObject.CompareTag("Carrot"))
        {

            carrotCollected++;
            // Debug.Log(carrotCollected);
            player.GetComponent<PlayerHealth>().TakeLife();
            audioSrc.PlayOneShot(carrotcollectSound);
            Destroy(other.gameObject);
        }
    }
}
