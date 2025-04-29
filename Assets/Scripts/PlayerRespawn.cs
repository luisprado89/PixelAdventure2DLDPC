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
    // Valor predeterminado de vidas (3 vidas)
    int defaultLives = 3;

    // Restaurar las vidas desde PlayerPrefs o establecerlas en el valor predeterminado
    if (PlayerPrefs.HasKey("CurrentLives"))
    {
        life = PlayerPrefs.GetInt("CurrentLives");

        // Si las vidas son 0 (el jugador perdió todas), restablecerlas a 3
        if (life <= 0)
        {
            life = defaultLives;
        }
    }
    else
    {
        life = defaultLives; // Si no hay vidas guardadas, usar el valor predeterminado
    }

    // Activar solo los corazones correspondientes a las vidas actuales
    for (int i = 0; i < hearts.Length; i++)
    {
        hearts[i].SetActive(i < life); // Activar los corazones según el número de vidas restantes
    }

    // Restaurar la posición del checkpoint si existe
    if (PlayerPrefs.GetFloat("CheckPointPositionX") != 0)
    {
        transform.position = new Vector2(
            PlayerPrefs.GetFloat("CheckPointPositionX"), // Restaurar la posición X desde PlayerPrefs
            PlayerPrefs.GetFloat("CheckPointPositionY")  // Restaurar la posición Y desde PlayerPrefs
        );
    }
}

    // Método que verifica las vidas restantes y maneja las acciones correspondientes
    private void CheckLife()
{
    if (life < 1)
    {
        // Si no quedan vidas, reiniciar las vidas a 3 y reiniciar la escena
        PlayerPrefs.SetInt("CurrentLives", 3); // Restablecer las vidas a 3 en PlayerPrefs
        Destroy(hearts[0].gameObject); // Destruir el último corazón
        animator.Play("Hit"); // Reproducir la animación de daño
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
//método para guardar las vidas actuales en PlayerPrefs antes de cambiar de nivel.
    public void SaveCurrentLives()
{
    PlayerPrefs.SetInt("CurrentLives", life); // Guardar las vidas actuales en PlayerPrefs
}
}