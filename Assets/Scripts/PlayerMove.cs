using UnityEngine;

// Clase que controla el movimiento, salto y animaciones del jugador
public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 2; // Velocidad de movimiento horizontal del jugador
    public float jumpSpeed = 3; // Velocidad del salto inicial
    public float doubleJumpSpeed = 2.5f; // Velocidad del doble salto, menor que el primer salto
    private bool canDoubleJump; // Indica si el jugador puede realizar un doble salto
    Rigidbody2D rb2D; // Referencia al componente Rigidbody2D del jugador
    public bool betterJump = false; // Indica si se aplican mejoras al salto
    public float fallMultiplier = 0.5f; // Multiplicador para acelerar la caída
    public float lowJumpMultiplier = 1f; // Multiplicador para reducir la altura del salto si se suelta la tecla
    public SpriteRenderer spriteRenderer; // Referencia al SpriteRenderer para voltear el sprite
    public Animator animator; // Referencia al Animator para controlar las animaciones

    void Start()
    {
        // Obtener el componente Rigidbody2D del jugador
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Manejar el salto y el doble salto
        if (Input.GetKey("space"))
        {
            if (CheckGround.isGrounded)
            {
                canDoubleJump = true; // Permitir el doble salto si el jugador está en el suelo
                rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpSpeed); // Realizar el salto inicial
            }
            else
            {
                if (Input.GetKeyDown("space"))
                {
                    if (canDoubleJump)
                    {
                        animator.SetBool("DoubleJump", true); // Activar la animación de doble salto
                        rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, doubleJumpSpeed); // Realizar el doble salto
                        canDoubleJump = false; // Desactivar la posibilidad de realizar otro doble salto
                    }
                }
            }
        }

        // Manejar las animaciones de salto y caída
        if (!CheckGround.isGrounded)
        {
            animator.SetBool("Jump", true); // Activar la animación de salto
            animator.SetBool("Run", false); // Desactivar la animación de correr
        }
        if (CheckGround.isGrounded)
        {
            animator.SetBool("Jump", false); // Desactivar la animación de salto
            animator.SetBool("DoubleJump", false); // Desactivar la animación de doble salto
            animator.SetBool("Falling", false); // Desactivar la animación de caída
        }
        if (rb2D.linearVelocity.y < 0)
        {
            animator.SetBool("Falling", true); // Activar la animación de caída
        }
        else if (rb2D.linearVelocity.y > 0)
        {
            animator.SetBool("Falling", false); // Desactivar la animación de caída
        }
    }

    // Manejar el movimiento horizontal y las animaciones correspondientes
    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.linearVelocity = new Vector2(runSpeed, rb2D.linearVelocity.y); // Mover hacia la derecha
            spriteRenderer.flipX = false; // Asegurar que el sprite no esté volteado
            animator.SetBool("Run", true); // Activar la animación de correr
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.linearVelocity = new Vector2(-runSpeed, rb2D.linearVelocity.y); // Mover hacia la izquierda
            spriteRenderer.flipX = true; // Voltear el sprite hacia la izquierda
            animator.SetBool("Run", true); // Activar la animación de correr
        }
        else
        {
            rb2D.linearVelocity = new Vector2(0, rb2D.linearVelocity.y); // Detener el movimiento horizontal
            animator.SetBool("Run", false); // Desactivar la animación de correr
        }

        // Aplicar mejoras al salto si están habilitadas
        if (betterJump)
        {
            if (rb2D.linearVelocity.y < 0)
            {
                rb2D.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime; // Acelerar la caída
            }
            if (rb2D.linearVelocity.y > 0 && !Input.GetKey("space"))
            {
                rb2D.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime; // Reducir la altura del salto
            }
        }
    }

    // Detectar cuando el jugador entra en el área de una puerta
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("OpenDoor"))
        {
            Debug.Log("Entró en el trigger de la puerta"); // Mensaje de depuración
        }
    }

    // Detectar cuando el jugador sale del área de una puerta
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("OpenDoor"))
        {
            Debug.Log("Salió del trigger de la puerta"); // Mensaje de depuración
        }
    }
}