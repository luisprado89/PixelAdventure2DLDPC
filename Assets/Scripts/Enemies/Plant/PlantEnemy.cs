using UnityEngine;

// Clase que controla el comportamiento de la planta enemiga
public class PlantEnemy : MonoBehaviour
{
    private float waitedTime; // Tiempo que la planta ha esperado antes de atacar
    public float waitTimeToAttack = 3; // Tiempo que la planta debe esperar antes de realizar un ataque
    public Animator animator; // Referencia al componente Animator para controlar las animaciones de la planta
    public GameObject bulletPrefab; // Prefab de la bala que dispara la planta
    public Transform launchSpawnPoint; // Punto desde donde se lanzará la bala

    private void Start()
    {
        // Inicializar el tiempo de espera con el valor definido en waitTimeToAttack
        waitedTime = waitTimeToAttack;
    }

    private void Update()
    {
        // Verificar si el tiempo de espera ha terminado
        if (waitedTime <= 0)
        {
            // Reiniciar el tiempo de espera
            waitedTime = waitTimeToAttack;

            // Reproducir la animación de ataque si el Animator está asignado
            if (animator != null)
                animator.Play("Attack");

            // Invocar el método LaunchBullet después de 0.5 segundos
            Invoke("LaunchBullet", 0.5f);
        }
        else
        {
            // Reducir el tiempo de espera en función del tiempo transcurrido
            waitedTime -= Time.deltaTime;
        }
    }

    public void LaunchBullet()
    {
        // Verificar si el prefab de la bala y el punto de lanzamiento están asignados
        if (bulletPrefab != null && launchSpawnPoint != null)
        {
            // Crear una nueva bala en la posición y rotación del punto de lanzamiento
            GameObject newBullet = Instantiate(bulletPrefab, launchSpawnPoint.position, launchSpawnPoint.rotation);
        }
        else
        {
            // Mostrar una advertencia en la consola si faltan referencias
            Debug.LogWarning("bulletPrefab o launchSpawnPoint no están asignados o han sido destruidos.");
        }
    }
}