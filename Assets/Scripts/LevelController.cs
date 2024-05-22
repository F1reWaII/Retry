using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private bool playerInside = false;
    public int sceneIndex;

    private void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
             
        if (other.gameObject.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInside = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
