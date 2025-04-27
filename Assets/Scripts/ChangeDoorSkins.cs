using UnityEngine;

// Clase que controla el cambio de skins del jugador al interactuar con una puerta
public class ChangeDoorSkins : MonoBehaviour
{
    public GameObject skinsPanel; // Panel de selección de skins que se activa al entrar en la puerta
    private bool inDoor = false; // Indica si el jugador está dentro del área de la puerta
    public GameObject player; // Referencia al objeto del jugador

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si el objeto que entra en el área tiene la etiqueta "Player" y si no está ya en la puerta
        if (collision.CompareTag("Player") && !inDoor)
        {
            skinsPanel.gameObject.SetActive(true); // Activar el panel de selección de skins
            inDoor = true; // Marcar que el jugador está en la puerta
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Verificar si el objeto que sale del área tiene la etiqueta "Player" y si estaba en la puerta
        if (collision.CompareTag("Player") && inDoor)
        {
            skinsPanel.gameObject.SetActive(false); // Desactivar el panel de selección de skins
            inDoor = false; // Marcar que el jugador ya no está en la puerta
        }
    }

    public void SetPlayerFrog()
    {
        // Guardar la selección del skin "Frog" en PlayerPrefs
        PlayerPrefs.SetString("PlayerSelected", "Frog");
        ResetPlayerSkin(); // Actualizar el skin del jugador
    }

    public void SetPlayerBlueMan()
    {
        // Guardar la selección del skin "BlueMan" en PlayerPrefs
        PlayerPrefs.SetString("PlayerSelected", "BlueMan");
        ResetPlayerSkin(); // Actualizar el skin del jugador
    }

    public void SetPlayerVirtualGuy()
    {
        // Guardar la selección del skin "VirtualGuy" en PlayerPrefs
        PlayerPrefs.SetString("PlayerSelected", "VirtualGuy");
        ResetPlayerSkin(); // Actualizar el skin del jugador
    }

    public void SetPlayerMaskDude()
    {
        // Guardar la selección del skin "MaskDude" en PlayerPrefs
        PlayerPrefs.SetString("PlayerSelected", "MaskDude");
        ResetPlayerSkin(); // Actualizar el skin del jugador
    }

    void ResetPlayerSkin()
    {
        // Desactivar el panel de selección de skins
        skinsPanel.gameObject.SetActive(false);

        // Llamar al método ChangePlayerInMenu del script PlayerSelect para actualizar el skin del jugador
        player.GetComponent<PlayerSelect>().ChangePlayerInMenu();
    }
}