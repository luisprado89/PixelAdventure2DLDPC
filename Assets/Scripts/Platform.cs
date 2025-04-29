using UnityEngine;

// Clase que controla el comportamiento de una plataforma que permite al jugador atravesarla hacia abajo
public class Platform : MonoBehaviour
{
    private PlatformEffector2D effector; // Referencia al componente PlatformEffector2D para controlar la rotación de la plataforma
    public float startWaitTime = 0.2f; // Tiempo inicial de espera antes de permitir que el jugador atraviese la plataforma
    private float waitedTime; // Tiempo restante antes de permitir que el jugador atraviese la plataforma
    private bool playerOnPlatform; // Indica si el jugador está en contacto con la plataforma
    public PlayerMoveJoystick playerMoveJoystick; // Referencia al script PlayerMoveJoystick para detectar el movimiento del joystick

    void Start()
    {
        // Obtener el componente PlatformEffector2D del objeto
        effector = GetComponent<PlatformEffector2D>();

    }

    void Update()
    {
        // Reiniciar el tiempo de espera si el jugador deja de presionar la tecla hacia abajo
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp("s") || (playerMoveJoystick != null && playerMoveJoystick.Vertical >= 0))
        {
            waitedTime = startWaitTime;// Reiniciar el tiempo de espera
        }

        // Verificar si el jugador está presionando la tecla hacia abajo
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s") || (playerMoveJoystick != null && playerMoveJoystick.Vertical < 0))
        {
            // Si el tiempo de espera ha terminado y el jugador está en la plataforma, permitir que la atraviese
            if (waitedTime <= 0)
            {
                effector.rotationalOffset = 180f; // Cambiar la rotación de la plataforma para permitir el paso
                waitedTime = startWaitTime; // Reiniciar el tiempo de espera
            }
            else
            {
                waitedTime -= Time.deltaTime; // Reducir el tiempo de espera en función del tiempo transcurrido
            }
        }

        else
        {
            // Si el jugador deja de presionar hacia abajo, restablecer la rotación de la plataforma
            if (effector.rotationalOffset != 0)
            {
                effector.rotationalOffset = 0f; // Restablecer la rotación de la plataforma
            }
        }


        // Verificar si el jugador presiona la tecla de salto (espacio)
        if (Input.GetKey("space"))
        {
            effector.rotationalOffset = 0; // Restablecer la rotación de la plataforma para que sea sólida nuevamente
        }
    }

    // Detectar cuando el jugador entra en contacto con la plataforma
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerOnPlatform = true; // El jugador está en contacto con la plataforma
            Debug.Log("Jugador entró en contacto con la plataforma.");
        }
    }

    // Detectar cuando el jugador permanece en contacto con la plataforma
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerOnPlatform = true; // Asegurarse de que el jugador sigue en contacto con la plataforma
        }
    }

    // Detectar cuando el jugador sale de la plataforma
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerOnPlatform = false; // El jugador ya no está en contacto con la plataforma
            Debug.Log("Jugador salió de la plataforma.");
        }
    }
}