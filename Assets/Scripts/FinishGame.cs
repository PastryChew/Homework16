using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishGame : MonoBehaviour
{
    public GameObject finishImage;
    int beginnerScene = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            finishImage.SetActive(true);
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene(beginnerScene);
    }
}
