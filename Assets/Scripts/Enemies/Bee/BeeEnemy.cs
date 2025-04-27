using UnityEngine;

// Clase que controla el movimiento de una abeja enemiga entre puntos específicos
public class BeeEnemy : MonoBehaviour
{
    public Animator animator; // Referencia al componente Animator para controlar las animaciones de la abeja
    public SpriteRenderer spriteRenderer; // Referencia al SpriteRenderer para mostrar u ocultar el sprite de la abeja
    public float speed = 0.5F; // Velocidad de movimiento de la abeja
    private float waitTime; // Tiempo de espera antes de moverse al siguiente punto
    public float startWaitTime = 2; // Tiempo inicial de espera en cada punto
    private int i = 0; // Índice del punto actual en el array de puntos de movimiento
    private Vector2 actualPos; // Posición actual de la abeja (no se utiliza en este script)
    public Transform[] moveSpots; // Array de puntos hacia los que la abeja se moverá

    void Start()
    {
        // Inicializar el tiempo de espera con el valor inicial
        waitTime = startWaitTime;
    }

    // Update se llama una vez por frame
    void Update()
    {
        // Mover la abeja hacia el punto actual (moveSpots[i]) con la velocidad especificada
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);

        // Verificar si la abeja ha llegado al punto actual
        if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
        {
            // Si el tiempo de espera ha terminado, pasar al siguiente punto
            if (waitTime <= 0)
            {
                // Si no es el último punto, avanzar al siguiente
                if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
                {
                    i++; // Avanzar al siguiente punto
                }
                else
                {
                    i = 0; // Si es el último punto, volver al primero (movimiento cíclico)
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
}