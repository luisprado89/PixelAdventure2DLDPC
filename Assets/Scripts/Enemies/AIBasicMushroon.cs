using System.Collections;
using UnityEngine;

// Clase que controla el comportamiento básico de un enemigo tipo hongo
public class AIBasicMushroon : MonoBehaviour
{
    public Animator animator; // Referencia al componente Animator para controlar las animaciones del enemigo
    public SpriteRenderer spriteRenderer; // Referencia al SpriteRenderer para voltear el sprite del enemigo
    public float speed = 0.5F; // Velocidad de movimiento del enemigo
    private float waitTime; // Tiempo de espera antes de moverse al siguiente punto
    public float startWaitTime = 2; // Tiempo inicial de espera en cada punto
    private int i = 0; // Índice del punto actual en el array de puntos de movimiento
    private Vector2 actualPos; // Posición actual del enemigo para verificar si se está moviendo
    public Transform[] moveSpots; // Array de puntos hacia los que el enemigo se moverá

    void Start()
    {
        // Inicializar el tiempo de espera con el valor definido en startWaitTime
        waitTime = startWaitTime;
    }

    void Update()
    {
        // Iniciar la corrutina para verificar si el enemigo se está moviendo
        StartCoroutine(CheckEnemyMoving());

        // Mover el enemigo hacia el punto actual (moveSpots[i]) con la velocidad especificada
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);

        // Verificar si el enemigo ha llegado al punto actual
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
                // Reducir el tiempo de espera en función del tiempo transcurrido
                waitTime -= Time.deltaTime;
            }
        }
    }

    IEnumerator CheckEnemyMoving()
    {
        // Guardar la posición actual del enemigo
        actualPos = transform.position;

        // Esperar 0.5 segundos antes de verificar si el enemigo se ha movido
        yield return new WaitForSeconds(0.5f);

        // Verificar si el enemigo se está moviendo hacia la derecha
        if (transform.position.x > actualPos.x)
        {
            spriteRenderer.flipX = true; // Voltear el sprite hacia la derecha
            animator.SetBool("Idle", false); // Desactivar la animación de "Idle"
        }
        // Verificar si el enemigo se está moviendo hacia la izquierda
        else if (transform.position.x < actualPos.x)
        {
            spriteRenderer.flipX = false; // Voltear el sprite hacia la izquierda
            animator.SetBool("Idle", false); // Desactivar la animación de "Idle"
        }
        // Verificar si el enemigo no se está moviendo
        else if (transform.position.x == actualPos.x)
        {
            animator.SetBool("Idle", true); // Activar la animación de "Idle"
        }
    }
}