using UnityEngine;

// Clase que controla el comportamiento de las balas disparadas por la abeja enemiga
public class BeeEnemyBullet : MonoBehaviour
{
    public float speed = 2; // Velocidad a la que la bala se mueve hacia abajo
    public float lifeTime = 2; // Tiempo de vida de la bala antes de ser destruida

    private void Start()
    {
        // Destruir la bala automáticamente después de que pase el tiempo definido en lifeTime
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        // Mover la bala hacia abajo en el eje Y con la velocidad especificada
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}