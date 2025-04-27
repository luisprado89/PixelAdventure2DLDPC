using UnityEngine;

// Clase que controla el comportamiento de un enemigo que recibe daño al ser golpeado por el jugador
public class JumpDamage : MonoBehaviour
{
    public Collider2D collider2D; // Referencia al componente Collider2D del enemigo
    public Animator animator; // Referencia al componente Animator para controlar las animaciones del enemigo
    public SpriteRenderer spriteRenderer; // Referencia al SpriteRenderer para mostrar u ocultar el sprite del enemigo
    public GameObject destroyParticle; // Prefab o GameObject que representa las partículas de destrucción
    public float jumpForce = 2.5f; // Fuerza con la que el jugador será impulsado hacia arriba al golpear al enemigo
    public int lifes = 2; // Número de vidas del enemigo antes de ser destruido

    // Método que se ejecuta cuando otro objeto colisiona con el enemigo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto que colisionó tiene la etiqueta "Player"
        if (collision.transform.CompareTag("Player"))
        {
            // Impulsa al jugador hacia arriba al golpear al enemigo
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = (Vector2.up * jumpForce);

            // Reduce la vida del enemigo y reproduce la animación de golpe
            LosseLifeAndHit();

            // Verifica si el enemigo ha perdido todas sus vidas
            CheckLife();
        }
    }

    // Método que reduce la vida del enemigo y reproduce la animación de golpe
    public void LosseLifeAndHit()
    {
        lifes--; // Reduce la vida del enemigo en 1
        animator.Play("Hit"); // Reproduce la animación de golpe
    }

    // Método que verifica si el enemigo ha perdido todas sus vidas
    public void CheckLife()
    {
        if (lifes == 0) // Si las vidas llegan a 0
        {
            destroyParticle.SetActive(true); // Activa las partículas de destrucción
            spriteRenderer.enabled = false; // Oculta el sprite del enemigo
            Invoke("EnemyDie", 0.2f); // Llama al método EnemyDie después de 0.2 segundos
        }
    }

    // Método que destruye el objeto del enemigo
    public void EnemyDie()
    {
        Destroy(gameObject); // Destruye el GameObject del enemigo
    }
}