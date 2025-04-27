using UnityEngine;

// Clase que controla el comportamiento de las frutas recolectables
public class FruitCollectedController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si el objeto que colisiona tiene la etiqueta "Player"
        if (collision.CompareTag("Player"))
        {
            // Desactivar el sprite de la fruta para que desaparezca visualmente
            GetComponent<SpriteRenderer>().enabled = false;

            // Activar el efecto visual asociado a la fruta (hijo del objeto)
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            // Reproducir el sonido de recolección utilizando el GameAudioManager
            GameAudioManager.Instance.PlayFruitCollectedSound();

            // Destruir el objeto de la fruta después de un breve retraso (0.5 segundos)
            Destroy(gameObject, 0.5f);
        }
    }
}