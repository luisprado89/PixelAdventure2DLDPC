using UnityEngine;
using UnityEngine.SceneManagement;

// Clase que gestiona la interfaz de usuario del juego, incluyendo opciones, créditos y sonido
public class UIManager : MonoBehaviour
{
    public GameObject optionsPanel; // Panel de opciones del juego
    public GameObject creditsPanel; // Panel de créditos
    private bool isMuted = false; // Estado de mute (silencio)
    public GameObject muteButton; // Botón que indica si el audio está en mute

    private void Start()
    {
        // Recuperar el estado de mute desde PlayerPrefs y configurarlo al iniciar
        isMuted = PlayerPrefs.GetInt("IsMuted", 0) == 1; // 1 significa mute, 0 significa sonido activo
        muteButton.SetActive(isMuted); // Actualizar el botón de mute según el estado
        AudioListener.volume = isMuted ? 0 : 1; // Configurar el volumen inicial según el estado de mute
    }

    public void OptionsPanel()
    {
        Time.timeScale = 0; // Pausar el tiempo del juego
        optionsPanel.SetActive(true); // Mostrar el panel de opciones
        muteButton.SetActive(isMuted); // Actualizar el estado del botón de mute
    }

    public void Return()
    {
        Time.timeScale = 1; // Reanudar el tiempo del juego
        optionsPanel.SetActive(false); // Ocultar el panel de opciones
        muteButton.SetActive(isMuted); // Actualizar el estado del botón de mute
    }

    public void ShowCredits()
    {
        optionsPanel.SetActive(false); // Ocultar el panel de opciones
        creditsPanel.SetActive(true); // Mostrar el panel de créditos
    }

    public void HideCredits()
    {
        creditsPanel.SetActive(false); // Ocultar el panel de créditos
        optionsPanel.SetActive(true); // Mostrar el panel de opciones
        muteButton.SetActive(isMuted); // Actualizar el estado del botón de mute
    }

    public void AnotherOptions()
    {
        // Espacio reservado para futuras opciones (sonido, gráficos, etc.)
    }

    public void GoMainMenu()
    {
        Time.timeScale = 1; // Reanudar el tiempo del juego
        SceneManager.LoadScene("MainMenu"); // Cargar la escena del menú principal
    }

    public void QuitGame()
    {
        Application.Quit(); // Salir del juego (solo funciona en el ejecutable, no en Unity)
    }

    public void PlaySoundButton()
    {
        // Reproducir el sonido del botón utilizando el GameAudioManager
        GameAudioManager.Instance.PlayButtonClickSound();
    }

    public void ToggleMute()
    {
        isMuted = !isMuted; // Alternar el estado de mute
        AudioListener.volume = isMuted ? 0 : 1; // Silenciar o activar el sonido
        muteButton.SetActive(isMuted); // Actualizar el botón de mute según el estado

        // Guardar el estado de mute en PlayerPrefs para persistencia
        PlayerPrefs.SetInt("IsMuted", isMuted ? 1 : 0);
        PlayerPrefs.Save(); // Guardar los cambios en PlayerPrefs
    }
}