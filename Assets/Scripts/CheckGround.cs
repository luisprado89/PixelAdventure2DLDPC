using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public static bool isGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("World"))
        {
            // Cambia la variable isGrounded a true, indicando que el personaje está en el suelo.
            isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("World"))
        {
            // Cambia la variable isGrounded a false, indicando que el personaje ya no está en el suelo.
            isGrounded = false;
        }
    }
}
