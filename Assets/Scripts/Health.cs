using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float hurtCoolDownTime = 0.1f;
    private bool invulnerable = false;
    [SerializeField] AudioClip hurtSound;
    [SerializeField] private int health = 50;

    [SerializeField] bool isPlayer = false;

    public int GetHealth()
    {
        return health;
    }

    public bool GetInvulnerable()
    {
        return invulnerable;
    }

    public void ApplyDamage(int dmg)
    {
        if (!invulnerable)
        {
            invulnerable = true;
            health -= dmg;
            AudioSource.PlayClipAtPoint(hurtSound,Camera.main.transform.position);
            StartCoroutine(JustHurt());

            if (isPlayer)
            {
                var session = FindObjectOfType<GameSession>();
                session.DamageLives(dmg);
            }
        }
    }

    IEnumerator JustHurt()
    {
        yield return new WaitForSeconds(hurtCoolDownTime);
        invulnerable = false;
    }
}
