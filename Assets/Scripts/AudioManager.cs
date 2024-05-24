using UnityEngine;
using UnityEngine.Audio;
// SoundController
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; // Статическая ссылка на экземпляр менеджера
    public AudioClip soundToPlay; // Звуковой клип для воспроизведения
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Предотвращаем уничтожение объекта при загрузке новой сцены
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject); // Уничтожаем дубликаты менеджера
        }
    }

    public void PlaySound()
    {
        if (soundToPlay!= null)
        {
            audioSource.PlayOneShot(soundToPlay);
        }
    }
}
