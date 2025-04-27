using UnityEngine;

// Clase que controla el comportamiento de una plataforma que permite al jugador atravesarla hacia abajo
public class Platform : MonoBehaviour
{
    private PlatformEffector2D effector; // Referencia al componente PlatformEffector2D para controlar la rotación de la plataforma
    public float startWaitTime; // Tiempo inicial de espera antes de permitir que el jugador atraviese la plataforma
    private float waitedTime; // Tiempo restante antes de permitir que el jugador atraviese la plataforma

    void Start()
    {
        // Obtener el componente PlatformEffector2D del objeto
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
        // Reiniciar el tiempo de espera si el jugador deja de presionar la tecla hacia abajo
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp("s"))
        {
            waitedTime = startWaitTime;
        }

        // Verificar si el jugador está presionando la tecla hacia abajo
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
        {
            // Si el tiempo de espera ha terminado, permitir que el jugador atraviese la plataforma
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

        // Verificar si el jugador presiona la tecla de salto (espacio)
        if (Input.GetKey("space"))
        {
            effector.rotationalOffset = 0; // Restablecer la rotación de la plataforma para que sea sólida nuevamente
        }
    }
}