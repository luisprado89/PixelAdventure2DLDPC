using UnityEngine;

// Clase que gestiona todos los sonidos y la música del juego utilizando el patrón Singleton
public class GameAudioManager : MonoBehaviour
{
    public static GameAudioManager Instance; // Singleton para acceder al GameAudioManager desde cualquier parte del juego

    public AudioSource audioSource; // Componente AudioSource compartido para reproducir sonidos y música
    public AudioClip music; // Clip de audio para la música de fondo
    public AudioClip fruitCollectedSound; // Clip de audio para el sonido de recolectar fruta
    public AudioClip buttonClickSound; // Clip de audio para el sonido de clic de botón

    private void Awake()
    {
        // Configurar el Singleton para que solo exista una instancia de GameAudioManager
        if (Instance == null)
        {
            Instance = this; // Asignar esta instancia como la única
            DontDestroyOnLoad(gameObject); // Evitar que este objeto se destruya al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Destruir duplicados si ya existe una instancia
        }
    }

    private void Start()
    {
        // Reproducir la música de fondo al inicio del juego
        PlayMusic();
    }

    // Método para reproducir la música de fondo
    public void PlayMusic()
    {
        // Verificar que el AudioSource y el clip de música estén asignados
        if (audioSource != null && music != null)
        {
            audioSource.clip = music; // Asignar el clip de música al AudioSource
            audioSource.loop = true; // Configurar la música para que se reproduzca en bucle
            audioSource.Play(); // Iniciar la reproducción de la música
        }
    }

    // Método para reproducir el sonido de recolectar fruta
    public void PlayFruitCollectedSound()
    {
        // Verificar que el AudioSource y el clip de sonido estén asignados
        if (audioSource != null && fruitCollectedSound != null)
        {
            audioSource.PlayOneShot(fruitCollectedSound); // Reproducir el sonido de recolectar fruta
        }
    }

    // Método para reproducir el sonido de clic de botón
    public void PlayButtonClickSound()
    {
        // Verificar que el AudioSource y el clip de sonido estén asignados
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound); // Reproducir el sonido de clic de botón
        }
    }
}