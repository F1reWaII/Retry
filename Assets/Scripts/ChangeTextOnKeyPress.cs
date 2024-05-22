using UnityEngine;
using TMPro;
//MonstersController
public class ChangeTextOnKeyPress : MonoBehaviour
{
    private bool playerInside = false;
    public GameObject Cats;
    public TextMeshProUGUI displayText;
    private string[] texts = { "Не открываеться...", "Чтож... я вроде видел несколько ключей в тех камерах, надо проверить, вдруг какойнибудь из них подойдёт." };
    private int currentTextIndex = 0;

    private void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.T)) // Проверяем нажатие клавиши T, если игрок находится внутри триггера
        {
            currentTextIndex++; // Переходим к следующему индексу массива
            if (currentTextIndex >= texts.Length) // Если достигнут конец массива, начинаем сначала
            {
                Cats.SetActive(false);
            }
            displayText.text = texts[currentTextIndex % texts.Length]; // Обновляем текст и используем оператор % для циклического перехода по массиву
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInside = true;
            Cats.SetActive(true); // Активируем Cats сразу при входе игрока в триггер
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInside = false;
            Cats.SetActive(false); // Деактивируем Cats при выходе игрока из триггера
        }
    }
}
//ExitDoorController