using UnityEngine;
using UnityEngine.SceneManagement; // Importar el espacio de nombres para SceneManager

public class NextLevel : MonoBehaviour
{
    public PlayerRespawn playerRespawn; // Referencia al script PlayerRespawn para guardar las vidas

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si el objeto que entra en el área tiene la etiqueta "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            SavePlayerLives(); // Guardar las vidas antes de cambiar de nivel
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Cargar el siguiente nivel
        }
    }

    // Método para guardar las vidas del jugador
    private void SavePlayerLives()
    {
        if (playerRespawn != null)
        {
            playerRespawn.SaveCurrentLives(); // Llamar al método SaveCurrentLives del script PlayerRespawn
        }
        else
        {
            Debug.LogWarning("PlayerRespawn no está asignado. No se guardarán las vidas.");
        }
    }
}