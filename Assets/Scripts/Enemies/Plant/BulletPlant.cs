using UnityEngine;

// Clase que controla el comportamiento de las balas disparadas por la planta enemiga
public class BulletPlant : MonoBehaviour
{
    public float speed = 2; // Velocidad a la que la bala se mueve
    public float lifeTime = 2; // Tiempo de vida de la bala antes de ser destruida
    public bool left; // Indica si la bala se mueve hacia la izquierda (true) o hacia la derecha (false)

    private void Start()
    {
        // Destruir la bala automáticamente después de que pase el tiempo definido en lifeTime
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        // Verificar la dirección de la bala
        if (left)
        {
            // Si la bala debe moverse hacia la izquierda
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            // Si la bala debe moverse hacia la derecha
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}