using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 1;
    public bool playerDamage = true;

    public int GetDamage()
    {
        return damage;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Health otherHealth = other.GetComponent<Health>();

        if ((other.tag == "Enemy" && playerDamage) || (other.tag == "Player" && !playerDamage))
        {
            otherHealth.ApplyDamage(damage);
        }

    }
}
