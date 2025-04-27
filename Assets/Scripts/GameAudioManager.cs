using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    public static GameAudioManager Instance; // Singleton para acceder al GameAudioManager desde cualquier parte del juego

    public AudioSource audioSource; // AudioSource compartido para todos los sonidos
    public AudioClip music;         // Música de fondo
    public AudioClip fruitCollectedSound; // Sonido de recolectar fruta
    public AudioClip buttonClickSound;    // Sonido de clic de botón

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // No destruir este objeto al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Evitar duplicados
        }
    }

    private void Start()
    {
        // Reproducir la música de fondo al inicio
        PlayMusic();
    }

    // Método para reproducir la música de fondo
    public void PlayMusic()
    {
        if (audioSource != null && music != null)
        {
            audioSource.clip = music;
            audioSource.loop = true; // Asegurarse de que la música se reproduzca en bucle
            audioSource.Play();
        }
    }

    // Método para reproducir el sonido de recolectar fruta
    public void PlayFruitCollectedSound()
    {
        if (audioSource != null && fruitCollectedSound != null)
        {
            audioSource.PlayOneShot(fruitCollectedSound);
        }
    }

    // Método para reproducir el sonido de clic de botón
    public void PlayButtonClickSound()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }
}