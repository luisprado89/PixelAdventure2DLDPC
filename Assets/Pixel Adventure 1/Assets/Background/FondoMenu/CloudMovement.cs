using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float speed = 2f; // Velocidad de movimiento de las nubes
    private float spriteWidth; // Ancho del sprite de las nubes
    private Vector3 startPosition; // Posición inicial de las nubes

    private void Start()
    {
        // Guardar la posición inicial
        startPosition = transform.position;

        // Calcular el ancho del sprite basado en el tamaño del SpriteRenderer
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteWidth = spriteRenderer.bounds.size.x;
        }
    }

    private void Update()
    {
        // Mover las nubes de derecha a izquierda
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Reiniciar la posición cuando las nubes salen completamente de la cámara
        if (transform.position.x <= startPosition.x - spriteWidth)
        {
            transform.position += new Vector3(spriteWidth * 2, 0, 0);
        }
    }
}