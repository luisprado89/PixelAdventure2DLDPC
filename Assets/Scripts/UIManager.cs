using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    public AudioSource clip;
    public GameObject optionsPanel;
    public void OptionsPanel()
    {
        Time.timeScale = 0;//Para parar el tiempo
        optionsPanel.SetActive(true);

    }
    public void Return()
    {
        Time.timeScale = 1;//Para activar el tiempo
        optionsPanel.SetActive(false);
    }
    public void AnotherOptions()
    {
        //Sound
        //Graphics


    }
    public void GoMainMenu()
    {
        Time.timeScale = 1;//Para activar el tiempo
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {//Esto solo va a funcionar cuando este el ejecutable no dentro de unity
        Application.Quit();
    }

    public void PlaySoundButoon()
    {
        clip.Play();
    }

}
