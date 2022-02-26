using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] int damage = 1;

    public int GetDamage()
    {
        return damage;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Health otherHealth = other.GetComponent<Health>();
        if (other.tag == "Enemy" || other.tag == "Player")
        {
            
            otherHealth.ApplyDamage(damage);
            Debug.Log("Enemy Damaged");
        }

    }

}
