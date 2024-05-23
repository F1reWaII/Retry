using UnityEngine;
using TMPro;

public class ExitDoorController : MonoBehaviour
{
    private bool playerInside = false;
    public GameObject visibleObject; // Объект, который будет показываться и скрываться
    public GameObject Cats; // Объект, связанный с текстом
    public GameObject exitCats; // Объект, контролируемый логикой ExitDoorController
    public TextMeshProUGUI displayText;
    private string[] texts = { "Не открываеться...", "Чтож... надо проверить в тех камерах,, вдруг там окажиться ключ." };
    private int currentTextIndex = 0;

    private void Update()
    {
        if (playerInside)
        {
            // Показываем текст при нажатии 'E'
            if (Input.GetKeyDown(KeyCode.E))
            {
                displayText.text = texts[currentTextIndex];
                Cats.SetActive(true); // Показываем Cats при отображении текста
            }

            // Меняем текст при нажатии 'R'
            if (Input.GetKeyDown(KeyCode.R))
            {
                currentTextIndex++;
                if (currentTextIndex >= texts.Length) // Если достигнут конец массива, начинаем сначала
                {
                    Cats.SetActive(false);
                    currentTextIndex = 0; // Сбрасываем индекс для повторного начала
                }
                displayText.text = texts[currentTextIndex % texts.Length]; // Обновляем текст с использованием оператора модуля для циклического перехода

                // Управление активацией/деактивацией exitCats на основе нового отображаемого текста
                if (displayText.text == texts[1]) // Предполагая, что второе сообщение активирует объект
                {
                    exitCats.SetActive(true);
                }
                else
                {
                    exitCats.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInside = true;
            visibleObject.SetActive(true); // Показываем объект, когда игрок входит в триггер
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInside = false;
            Cats.SetActive(false); // Скрываем Cats, когда игрок покидает область
            exitCats.SetActive(false); // Также деактивируем exitCats, когда игрок покидает область
            visibleObject.SetActive(false); // Скрываем объект, когда игрок покидает триггер
        }
    }
}
