using UnityEngine;
using UnityEngine.SceneManagement;

// Clase que controla el sistema de vidas, puntos de control y respawn del jugador
public class PlayerRespawn : MonoBehaviour
{
    public GameObject[] hearts; // Array de objetos que representan las vidas del jugador
    private int life; // Número de vidas actuales del jugador
    private float CheckPointPositionX, CheckPointPositionY; // Coordenadas del último punto de control alcanzado
    public Animator animator; // Referencia al componente Animator para reproducir animaciones del jugador

    void Start()
    {
        // Inicializar el número de vidas según el tamaño del array de corazones
        if (hearts != null)
        {
            life = hearts.Length; // Asignar el número de vidas al tamaño del array
        }
        else
        {
            Debug.LogWarning("Hearts array is not assigned in the Inspector."); // Advertencia si el array no está asignado
            life = 0; // Establecer las vidas en 0 si no hay corazones asignados
        }

        // Verificar si hay un punto de control guardado en PlayerPrefs
        if (PlayerPrefs.GetFloat("CheckPointPositionX") != 0)
        {
            // Mover al jugador a la posición del último punto de control guardado
            transform.position = new Vector2(PlayerPrefs.GetFloat("CheckPointPositionX"), PlayerPrefs.GetFloat("CheckPointPositionY"));
        }
    }

    // Método que verifica las vidas restantes y maneja las acciones correspondientes
    private void CheckLife()
    {
        if (life < 1)
        {
            // Si no quedan vidas, destruir el último corazón, reproducir animación y reiniciar la escena
            Destroy(hearts[0].gameObject);
            animator.Play("Hit");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reiniciar la escena actual
        }
        else if (life < 2)
        {
            // Si queda una vida, destruir el segundo corazón y reproducir animación
            Destroy(hearts[1].gameObject);
            animator.Play("Hit");
        }
        else if (life < 3)
        {
            // Si quedan dos vidas, destruir el tercer corazón y reproducir animación
            Destroy(hearts[2].gameObject);
            animator.Play("Hit");
        }
    }

    // Método que guarda las coordenadas del último punto de control alcanzado
    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("CheckPointPositionX", x); // Guardar la posición X en PlayerPrefs
        PlayerPrefs.SetFloat("CheckPointPositionY", y); // Guardar la posición Y en PlayerPrefs
    }

    // Método que se llama cuando el jugador recibe daño
    public void PlayerDamaged()
    {
        life--; // Reducir el número de vidas
        CheckLife(); // Verificar las vidas restantes y manejar las acciones correspondientes
    }
}