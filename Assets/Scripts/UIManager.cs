// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.Audio;

// public class UIManager : MonoBehaviour
// {
//     public AudioSource clip;
//     public GameObject optionsPanel;
//     public GameObject creditsPanel; // Nuevo panel de créditos

//     private bool isMuted = false; // Estado de mute
//     public GameObject muteButton; // Botón que indica que el audio está en mute

//     private void Start()
//     {
//         // Asegurarse de que el botón de mute refleje el estado inicial de isMuted
//         muteButton.SetActive(isMuted);
//         AudioListener.volume = isMuted ? 0 : 1; // Configurar el volumen inicial según isMuted
//     }
//     public void OptionsPanel()
//     {
//         Time.timeScale = 0; // Para parar el tiempo
//         optionsPanel.SetActive(true); // Mostrar el panel de opciones
//         muteButton.SetActive(isMuted); // Actualizar el estado del botón de mute
//     }

//     public void Return()
//     {
//         Time.timeScale = 1; // Para activar el tiempo
//         optionsPanel.SetActive(false); // Ocultar el panel de opciones
//         muteButton.SetActive(isMuted); // Actualizar el estado del botón de mute
//     }

//     public void ShowCredits()
//     {
//         optionsPanel.SetActive(false); // Ocultar el panel de opciones
//         creditsPanel.SetActive(true);  // Mostrar el panel de créditos
//     }

//     public void HideCredits()
//     {
//         creditsPanel.SetActive(false); // Ocultar el panel de créditos
//         optionsPanel.SetActive(true);  // Mostrar el panel de opciones
//         muteButton.SetActive(isMuted); // Actualizar el estado del botón de mute
//     }

//     public void AnotherOptions()
//     {
//         // Sound
//         // Graphics
//     }

//     public void GoMainMenu()
//     {
//         Time.timeScale = 1; // Para activar el tiempo
//         SceneManager.LoadScene("MainMenu");
//     }

//     public void QuitGame()
//     { // Esto solo va a funcionar cuando este el ejecutable no dentro de unity
//         Application.Quit();
//     }

//     public void PlaySoundButoon()
//     {
//         clip.Play();
//     }

//     public void ToggleMute()
//     {
//         isMuted = !isMuted; // Alternar el estado de mute
//         AudioListener.volume = isMuted ? 0 : 1; // Silenciar o activar el sonido
//         muteButton.SetActive(isMuted); // Mostrar el botón si está en mute, ocultarlo si no

//         // Guardar el estado de mute en PlayerPrefs
//         PlayerPrefs.SetInt("IsMuted", isMuted ? 1 : 0);
//         PlayerPrefs.Save();
//     }
// }

using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject creditsPanel; // Nuevo panel de créditos

    private bool isMuted = false; // Estado de mute
    public GameObject muteButton; // Botón que indica que el audio está en mute

    private void Start()
    {
        // Asegurarse de que el botón de mute refleje el estado inicial de isMuted
        isMuted = PlayerPrefs.GetInt("IsMuted", 0) == 1; // Recuperar el estado de mute desde PlayerPrefs
        muteButton.SetActive(isMuted);
        AudioListener.volume = isMuted ? 0 : 1; // Configurar el volumen inicial según isMuted
    }

    public void OptionsPanel()
    {
        Time.timeScale = 0; // Para parar el tiempo
        optionsPanel.SetActive(true); // Mostrar el panel de opciones
        muteButton.SetActive(isMuted); // Actualizar el estado del botón de mute
    }

    public void Return()
    {
        Time.timeScale = 1; // Para activar el tiempo
        optionsPanel.SetActive(false); // Ocultar el panel de opciones
        muteButton.SetActive(isMuted); // Actualizar el estado del botón de mute
    }

    public void ShowCredits()
    {
        optionsPanel.SetActive(false); // Ocultar el panel de opciones
        creditsPanel.SetActive(true);  // Mostrar el panel de créditos
    }

    public void HideCredits()
    {
        creditsPanel.SetActive(false); // Ocultar el panel de créditos
        optionsPanel.SetActive(true);  // Mostrar el panel de opciones
        muteButton.SetActive(isMuted); // Actualizar el estado del botón de mute
    }

    public void AnotherOptions()
    {
        // Sound
        // Graphics
    }

    public void GoMainMenu()
    {
        Time.timeScale = 1; // Para activar el tiempo
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit(); // Esto solo funciona en el ejecutable, no dentro de Unity
    }

    public void PlaySoundButton()
    {
        // Reproducir el sonido del botón desde el GameAudioManager
        GameAudioManager.Instance.PlayButtonClickSound();
    }

    public void ToggleMute()
    {
        isMuted = !isMuted; // Alternar el estado de mute
        AudioListener.volume = isMuted ? 0 : 1; // Silenciar o activar el sonido
        muteButton.SetActive(isMuted); // Mostrar el botón si está en mute, ocultarlo si no

        // Guardar el estado de mute en PlayerPrefs
        PlayerPrefs.SetInt("IsMuted", isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }
}