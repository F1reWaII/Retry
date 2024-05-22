using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Импортируйте этот пространство имен, если вы используете TextMeshPro, замените на TMPro

public class KeyTriger : MonoBehaviour
{
    public GameObject keyTriggerText; // Ссылка на текстовый элемент
    private bool playerInside = false;
    private bool textVisible = false;
    private Coroutine showHideCoroutine;

    private void Start()
    {
        keyTriggerText.SetActive(false); // Скрываем текст по умолчанию
    }

    private void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            ToggleTextVisibility();
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

    private void ToggleTextVisibility()
    {
        if (!textVisible)
        {
            StartCoroutine(ShowText());
        }
        else
        {
            StartCoroutine(HideText());
        }
    }

    private IEnumerator ShowText()
    {
        textVisible = true;
        keyTriggerText.SetActive(true);
        yield return new WaitForSeconds(0.5f); // Задержка перед исчезновением текста
        HideText(); // После задержки автоматически скроем текст
    }

    private IEnumerator HideText()
    {
        textVisible = false;
        keyTriggerText.SetActive(false);
        yield return null;
    }
}
