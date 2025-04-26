// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;
// using TMPro;
// public class OpenDoor : MonoBehaviour
// {
//     public TMP_Text text;
//      public TMP_Text text;
//     public string levelName;
//     private bool inDoor = false;
//     private float doorTime = 3;
//     private float startTime = 3;

//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.gameObject.CompareTag("Player"))
//         {
//             text.gameObject.SetActive(true);
//             inDoor = true;

//         }
//     }

//     private void OnTriggerExit2D(Collider2D collision)
//     {

//         // Verifica si el objeto que sale es el jugador
//         if (collision.gameObject.CompareTag("Player"))
//         {
//             // Desactiva el texto cuando el jugador sale
//             if (text != null)
//             {
//                 text.gameObject.SetActive(false);
//             }
//             inDoor = false;
//             doorTime = startTime;  // Reinicia el temporizador para la puerta
//         }

//     }
//     private void Update()
//     {
//         //
//         if (inDoor)
//         {
//             doorTime -= Time.deltaTime;
//         }

//         doorTime.text = transform.childCount.ToString();


//         if (doorTime <= 0)
//         {
//             SceneManager.LoadScene(levelName);
//         }



//         if (inDoor && Input.GetKey("e"))
//         {
//             SceneManager.LoadScene(levelName);
//         }
//     }
// }





using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class OpenDoor : MonoBehaviour
{
    public TMP_Text doorInstructionText;  // Texto que se activa cuando entras (Ej: "Pulsa E para entrar")
    public TMP_Text doorTimerText;         // Texto donde se mostrará el conteo regresivo
    public string levelName;               // Nombre de la escena a cargar
    private bool inDoor = false;
    private float doorTime = 3f;            // Tiempo total para cambiar de escena
    private float startTime = 3f;           // Tiempo inicial para reiniciar el contador

    private void Start()
    {
        // Asegúrate de que el contador esté oculto al inicio
        if (doorTimerText != null)
            doorTimerText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (doorInstructionText != null)
                doorInstructionText.gameObject.SetActive(true);

            if (doorTimerText != null)
                doorTimerText.gameObject.SetActive(true);

            inDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (doorInstructionText != null)
                doorInstructionText.gameObject.SetActive(false);

            if (doorTimerText != null)
                doorTimerText.gameObject.SetActive(false);

            inDoor = false;
            doorTime = startTime;  // Reinicia el temporizador
        }
    }

    private void Update()
    {
        if (inDoor)
        {
            doorTime -= Time.deltaTime;

            // Actualizamos el texto del temporizador
            if (doorTimerText != null)
            {
                // Usamos Mathf.Ceil para mostrar números enteros (3, 2, 1)
                doorTimerText.text = Mathf.Ceil(doorTime).ToString();
            }

            // Si el temporizador llega a 0 o menos, cambiamos de escena automáticamente
            if (doorTime <= 0)
            {
                SceneManager.LoadScene(levelName);
            }

            // Si el jugador presiona la tecla "E", también cambia de escena manualmente
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(levelName);
            }
        }
    }
}
