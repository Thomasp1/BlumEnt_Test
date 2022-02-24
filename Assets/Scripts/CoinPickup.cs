using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip pickupSound;
    [SerializeField] int pointsForCoinPickup = 100;

    bool wasCollected = false;
    void OnTriggerEnter2D(Collider2D other) 
    {
        
        if (other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            AudioSource.PlayClipAtPoint(pickupSound,Camera.main.transform.position);
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
            Destroy(gameObject);
        }
    }
}
