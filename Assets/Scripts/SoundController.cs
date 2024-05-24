using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip soundClip; // Звуковой клип для воспроизведения

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Проверяем, что столкнулись с объектом тегом "Player"
        {
            AudioSource.PlayClipAtPoint(soundClip, transform.position); // Воспроизводим звук в точке триггера
            Destroy(gameObject); // Удаляем текущий объект (триггер)
        }
    }
}
