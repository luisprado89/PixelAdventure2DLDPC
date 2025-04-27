using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform cameraTransform; // Referencia a la cámara
    public Vector2 parallaxEffectMultiplier; // Velocidad del parallax en X e Y

    private Vector3 lastCameraPosition;

    private void Start()
    {
        // Guardar la posición inicial de la cámara
        lastCameraPosition = cameraTransform.position;
    }

    private void LateUpdate()
    {
        // Calcular el movimiento de la cámara
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

        // Mover el fondo en función del movimiento de la cámara y el multiplicador
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y, 0);

        // Actualizar la posición de la cámara
        lastCameraPosition = cameraTransform.position;
    }
}