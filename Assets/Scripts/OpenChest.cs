using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private bool isPlayer = false;
    
    

    private void Start()
    {
       anim = GetComponent<Animator>();
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            isPlayer = true;
        }
    }

    private void Update()
    {
        if (isPlayer && Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("isOpen", true);
            
            StartCoroutine(ChestDestroy());
        }
    }

    IEnumerator ChestDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    
}
