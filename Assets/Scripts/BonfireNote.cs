using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BonfireNote : MonoBehaviour
{
    [SerializeField]  private bool isPlayer = false;
    [SerializeField]  public Image textNote;

    // Update is called once per frame
    void Update()
    {
        if (isPlayer && Input.GetKeyDown(KeyCode.E))
        {
            textNote.gameObject.SetActive(true);
        }
       
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayer = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayer = false;
            textNote.gameObject.SetActive(false);
        }
    }
}
