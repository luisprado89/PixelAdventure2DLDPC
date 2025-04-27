using UnityEngine;

// Clase que controla el comportamiento de un objeto que daña al jugador al colisionar
public class DamageObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el objeto que colisiona tiene la etiqueta "Player"
        if (collision.transform.CompareTag("Player"))
        {
            // Llamar al método PlayerDamaged del script PlayerRespawn para manejar el daño al jugador
            collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();
        }
    }
}