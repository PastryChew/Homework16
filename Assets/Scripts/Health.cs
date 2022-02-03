using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private TextMeshProUGUI textcurrentHealth;
    [SerializeField] private GameObject Player;
    private float currentHealth;
    private bool isAlive;

    private void Awake()
    {
        currentHealth = maxHealth;
        textcurrentHealth.text = currentHealth.ToString();
        isAlive = true;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        textcurrentHealth.text = currentHealth.ToString();
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
            textcurrentHealth.gameObject.SetActive(false);
            Death();
        }
    }

    public void Death()
    {
        if (!isAlive)
        {
            StartCoroutine(deadActive());

            if (Player)
            {
                GetComponent<PlayerMovement>().anim.SetBool("isDead", true);

            }
           
        }
    }

    IEnumerator deadActive()
    {
        yield return new WaitForSeconds(1);
        GameObject.Destroy(gameObject);
    }
}
