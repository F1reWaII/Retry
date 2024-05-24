using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public AudioClip soundToPlay; // Публичное поле для звукового файла
    private AudioSource audioSource;
    private bool playerInside = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

         if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(6);
            PlaySound(); // Воспроизводим звук
        }
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

    void PlaySound() // Метод для воспроизведения звука
    {
        if (soundToPlay!= null) // Проверяем, задан ли звуковой файл
        {
            audioSource.PlayOneShot(soundToPlay); // Воспроизводим звук один раз
        }
    }
}
