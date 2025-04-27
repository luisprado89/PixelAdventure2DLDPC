using UnityEngine;

// Clase que controla el comportamiento de ataque de una abeja enemiga
public class BeeAttack : MonoBehaviour
{
    public Animator animator; // Referencia al componente Animator para controlar las animaciones de la abeja
    public float distanceRaycast = 0.5f; // Distancia del raycast para detectar al jugador
    private float cooldownAttack = 1.5f; // Tiempo de espera entre ataques
    private float actualCooldownAttack; // Tiempo restante para que la abeja pueda atacar nuevamente

    public GameObject beeBullet; // Prefab de la bala que dispara la abeja

    private void Start()
    {
        // Inicializar el cooldown actual en 0 para que pueda atacar inmediatamente
        actualCooldownAttack = 0;
    }

    void Update()
    {
        // Reducir el cooldown actual en función del tiempo transcurrido
        actualCooldownAttack -= Time.deltaTime;

        // Este es para ver en el Scene como un debug de su rango de control cuando ve al jugador
        // Debug.DrawRay(transform.position, Vector2.down, Color.red, distanceRaycast);
    }

    private void FixedUpdate()
    {
        // Realizar un raycast hacia abajo desde la posición de la abeja
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.down, distanceRaycast);

        // Verificar si el raycast colisiona con algo
        if (hit2D.collider != null)
        {
            // Verificar si el objeto detectado tiene la etiqueta "Player"
            if (hit2D.collider.CompareTag("Player"))
            {
                // Verificar si el cooldown ha terminado para permitir un nuevo ataque
                if (actualCooldownAttack < 0)
                {
                    // Invocar el método LaunchBullet después de 0.5 segundos
                    Invoke("LaunchBullet", 0.5f);

                    // Reproducir la animación de ataque
                    animator.Play("Attack");

                    // Reiniciar el cooldown del ataque
                    actualCooldownAttack = cooldownAttack;
                }
            }
        }
    }

    private void LaunchBullet()
    {
        // Crear una nueva bala en la posición y rotación de la abeja
        GameObject newBullet;
        newBullet = Instantiate(beeBullet, transform.position, transform.rotation);
    }
}