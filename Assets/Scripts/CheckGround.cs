using UnityEngine;

// Clase que verifica si el personaje está en contacto con el suelo
public class CheckGround : MonoBehaviour
{
    public static bool isGrounded; // Variable estática que indica si el personaje está en el suelo

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si el objeto que entra en el área tiene la etiqueta "World"
        if (collision.CompareTag("World"))
        {
            isGrounded = true; // Marcar que el personaje está en el suelo
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Verificar si el objeto que sale del área tiene la etiqueta "World"
        if (collision.CompareTag("World"))
        {
            isGrounded = false; // Marcar que el personaje ya no está en el suelo
        }
    }
}