using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public Vector3 offset;   // Offset de la cámara respecto al jugador
    public float smoothSpeed = 0.125f; // Velocidad de suavizado

    // Límites de la cámara
    public float minX = -12.7f; // Límite izquierdo
    public float maxX = 1.7f;   // Límite derecho
    public float minY = 0f;     // Límite inferior
    public float maxY = 9.5f;   // Límite superior

    private void LateUpdate()
    {
        if (player != null)
        {
            // Calcula la posición deseada de la cámara
            Vector3 desiredPosition = player.position + offset;

            // Restringe la posición deseada dentro de los límites
            float clampedX = Mathf.Clamp(desiredPosition.x, minX, maxX);
            float clampedY = Mathf.Clamp(desiredPosition.y, minY, maxY);

            Vector3 clampedPosition = new Vector3(clampedX, clampedY, transform.position.z);

            // Suaviza el movimiento de la cámara
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);

            // Actualiza la posición de la cámara
            transform.position = smoothedPosition;
        }
    }
}