using UnityEngine;

// Clase que controla el movimiento de una plataforma entre puntos específicos
public class PlatformMove : MonoBehaviour
{
    public float speed = 0.5F; // Velocidad de movimiento de la plataforma
    private float waitTime; // Tiempo de espera antes de moverse al siguiente punto
    public float startWaitTime = 2; // Tiempo inicial de espera en cada punto
    private int i = 0; // Índice del punto actual en el array de puntos de movimiento

    public Transform[] moveSpots; // Array de puntos hacia los que la plataforma se moverá

    void Start()
    {
        // Inicializar el tiempo de espera con el valor inicial
        waitTime = startWaitTime;
    }

    // Update se llama una vez por frame
    void Update()
    {
        // Mover la plataforma hacia el punto actual (moveSpots[i]) con la velocidad especificada
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);

        // Verificar si la plataforma ha llegado al punto actual
        if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
        {
            // Si el tiempo de espera ha terminado, pasar al siguiente punto
            if (waitTime <= 0)
            {
                // Si no es el último punto, avanzar al siguiente
                if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
                {
                    i++;
                }
                else
                {
                    // Si es el último punto, volver al primero (movimiento cíclico)
                    i = 0;
                }

                // Reiniciar el tiempo de espera
                waitTime = startWaitTime;
            }
            else
            {
                // Reducir el tiempo de espera
                waitTime -= Time.deltaTime;
            }
        }
    }

    // Método que se ejecuta cuando otro objeto colisiona con la plataforma
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Hacer que el objeto que colisiona (por ejemplo, el jugador) sea hijo de la plataforma
        // Esto asegura que el objeto se mueva junto con la plataforma
        collision.collider.transform.SetParent(transform);
    }

    // Método que se ejecuta cuando el objeto deja de colisionar con la plataforma
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Verificar si el objeto que dejó la colisión sigue activo en la jerarquía
        if (collision.collider != null && collision.collider.gameObject.activeInHierarchy)
        {
            // Si el objeto era hijo de la plataforma, eliminar la relación de jerarquía
            if (collision.collider.transform.parent == transform)
            {
                collision.collider.transform.SetParent(null);
            }
        }
    }
}