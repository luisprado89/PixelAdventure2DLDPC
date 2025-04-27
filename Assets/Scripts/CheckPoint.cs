using UnityEngine;
//Este de momento no se esta usando

// Clase que controla el comportamiento de los puntos de control (CheckPoints)
public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si el objeto que entra en el área tiene la etiqueta "Player"
        if (collision.CompareTag("Player"))
        {
            // Llamar al método ReachedCheckPoint del script PlayerRespawn para actualizar la posición del punto de control
            collision.GetComponent<PlayerRespawn>().ReachedCheckPoint(transform.position.x, transform.position.y);

            // Activar la animación del punto de control
            GetComponent<Animator>().enabled = true;
        }
    }
}