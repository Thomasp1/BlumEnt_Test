using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttacker : MonoBehaviour
{
    [SerializeField] GameObject meleePrefab;
    [SerializeField] float attackPerSecond = 3f;
    [SerializeField] float attackDistance = 1f;
    private float nextAttackTime = 0.2f;

    [HideInInspector] public bool isMeleeing;

    private GameObject meleeInstance;

    void Update()
    {
        Melee();
    }

    void Melee()
    {
        if (Time.time >= nextAttackTime && isMeleeing && meleeInstance == null)
        {
            var boxXPosition = transform.position.x + (attackDistance * Mathf.Sign(transform.localScale.x));
            var hitBoxPosition = new Vector3(boxXPosition,transform.position.y,transform.position.z);
            meleeInstance = Instantiate(meleePrefab, hitBoxPosition, Quaternion.identity);
            meleeInstance.GetComponent<DamageDealer>().playerDamage = true;
            

            nextAttackTime = Time.time + 1f / attackPerSecond;
        } else if (meleeInstance != null){
            Destroy(meleeInstance);
        }

    }
}
