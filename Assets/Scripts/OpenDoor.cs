using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class OpenDoor : MonoBehaviour
{
    public TMP_Text text;
    public string levelName;
    private bool inDoor = false;
    private float doorTime = 3;
    private float startTime = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(true);
            inDoor = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        // Verifica si el objeto que sale es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Desactiva el texto cuando el jugador sale
            if (text != null)
            {
                text.gameObject.SetActive(false);
            }
            inDoor = false;
            doorTime = startTime;  // Reinicia el temporizador para la puerta
        }

    }
    private void Update()
    {
        //
        if (inDoor)
        {
            doorTime -= Time.deltaTime;
        }




        if (doorTime <= 0)
        {
            SceneManager.LoadScene(levelName);
        }



        if (inDoor && Input.GetKey("e"))
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
