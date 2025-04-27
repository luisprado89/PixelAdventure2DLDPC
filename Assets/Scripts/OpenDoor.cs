using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// Clase que controla la interacción del jugador con una puerta para cambiar de nivel
public class OpenDoor : MonoBehaviour
{
    public TMP_Text doorInstructionText;  // Texto que se muestra al entrar en la puerta (Ej: "Pulsa E para entrar")
    public TMP_Text doorTimerText;       // Texto que muestra el conteo regresivo para cambiar de nivel
    public string levelName;             // Nombre de la escena a cargar al interactuar con la puerta
    private bool inDoor = false;         // Indica si el jugador está dentro del área de la puerta
    private float doorTime = 3f;         // Tiempo total para cambiar de escena automáticamente
    private float startTime = 3f;        // Tiempo inicial para reiniciar el temporizador

    private void Start()
    {
        // Asegurarse de que el texto del temporizador esté oculto al inicio
        if (doorTimerText != null)
            doorTimerText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si el objeto que entra en el área tiene la etiqueta "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Mostrar el texto de instrucciones si está asignado
            if (doorInstructionText != null)
                doorInstructionText.gameObject.SetActive(true);

            // Mostrar el texto del temporizador si está asignado
            if (doorTimerText != null)
                doorTimerText.gameObject.SetActive(true);

            inDoor = true; // Marcar que el jugador está dentro del área de la puerta
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Verificar si el objeto que sale del área tiene la etiqueta "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Ocultar el texto de instrucciones si está asignado
            if (doorInstructionText != null)
                doorInstructionText.gameObject.SetActive(false);

            // Ocultar el texto del temporizador si está asignado
            if (doorTimerText != null)
                doorTimerText.gameObject.SetActive(false);

            inDoor = false; // Marcar que el jugador ya no está en el área de la puerta
            doorTime = startTime; // Reiniciar el temporizador
        }
    }

    private void Update()
    {
        // Verificar si el jugador está dentro del área de la puerta
        if (inDoor)
        {
            // Reducir el tiempo del temporizador
            doorTime -= Time.deltaTime;

            // Actualizar el texto del temporizador si está asignado
            if (doorTimerText != null)
            {
                // Mostrar el tiempo restante como un número entero (3, 2, 1)
                doorTimerText.text = Mathf.Ceil(doorTime).ToString();
            }

            // Cambiar de escena automáticamente si el temporizador llega a 0
            if (doorTime <= 0)
            {
                SceneManager.LoadScene(levelName);
            }

            // Cambiar de escena manualmente si el jugador presiona la tecla "E"
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(levelName);
            }
        }
    }
}