using UnityEngine;
using TMPro;

public class TriggerManager  : MonoBehaviour
{
    public TextMeshProUGUI textDisplay; // Ссылки на компонент TextMeshProUGUI
    public string[] dialogues; // Массив строк диалогов
    private int currentIndex = 0; // Текущий индекс строки диалога
    public GameObject Cats;

    void Start()
    {
        // Инициализация первого сообщения
        textDisplay.text = dialogues[0];
    }

    void Update()
    {
        // Проверка нажатия клавиши R
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Показ следующего сообщения
            ShowNextMessage();
        }
    }

    void ShowNextMessage()
    {
        // Проверка, не достигли ли конца массива
        if (currentIndex < dialogues.Length - 1)
        {
            currentIndex++;
            textDisplay.text = dialogues[currentIndex];
        }
        else
        {
            // Скрываем Canvas и удаляем триггер, если достигнут конец массива
            gameObject.SetActive(false);
            Destroy(this.gameObject);
            Cats.SetActive(false);
        }
    }
}
