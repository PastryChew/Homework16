using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth;
    private bool isAlive;

    private void Awake()
    {
        currentHealth = maxHealth;
        isAlive = true;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        CheckisAlive();
        Debug.Log(currentHealth);
    }

    public void CheckisAlive()
    {
        if (currentHealth > 0)
        {
            isAlive = true;
        }
        else
        {
            isAlive = false;
            Death();
        }
    }

    public void Death()
    {
        if (!isAlive)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
