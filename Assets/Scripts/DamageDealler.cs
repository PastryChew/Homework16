using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealler : MonoBehaviour
{
    [SerializeField] private float Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damagable"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(Damage);
            
        }
        if (!collision.CompareTag("Player") && !collision.CompareTag("Weapon") && !collision.CompareTag("EnemyStopper"))
        {
            Destroy(gameObject);
        }
    }
}
