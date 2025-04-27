using UnityEngine;

public class FruitCollectedController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Desactivar el sprite de la fruta y activar el efecto visual
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            // Reproducir el sonido de recolectar fruta desde el GameAudioManager
            GameAudioManager.Instance.PlayFruitCollectedSound();

            // Destruir el objeto después de un breve retraso
            Destroy(gameObject, 0.5f);
        }
    }
}