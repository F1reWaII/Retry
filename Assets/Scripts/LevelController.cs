﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio; // Импорт пространства имен для работы с аудио

public class LevelController : MonoBehaviour
{
    private bool playerInside = false;
    public int sceneIndex;
    public AudioClip soundToPlay; // Публичное поле для звукового файла

    private AudioSource audioSource; // Компонент для воспроизведения звука

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Получаем компонент AudioSource
        if (!audioSource) // Если компонента нет, создаем его
        {
            audioSource = gameObject.AddComponent<AudioSource>();
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

    // Update is called once per frame
    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(sceneIndex);
            PlaySound(); // Воспроизводим звук
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
