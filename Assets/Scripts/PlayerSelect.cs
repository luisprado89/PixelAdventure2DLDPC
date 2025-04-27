using UnityEngine;

// Clase que controla la selección del personaje y su apariencia
public class PlayerSelect : MonoBehaviour
{
    // Enumeración que define los diferentes personajes disponibles
    public enum Player { Frog, BlueMan, VirtualGuy, MaskDude };

    public bool enabledSelectectPlayer; // Indica si la selección de personaje está habilitada
    public Player playerSelected; // Personaje seleccionado por defecto
    public Animator animator; // Referencia al componente Animator para controlar las animaciones del personaje
    public SpriteRenderer spriteRenderer; // Referencia al SpriteRenderer para cambiar la apariencia del personaje
    public RuntimeAnimatorController[] playersController; // Array de controladores de animación para cada personaje
    public Sprite[] playersRenderer; // Array de sprites para cada personaje

    void Start()
    {
        // Verificar si la selección de personaje está deshabilitada
        if (!enabledSelectectPlayer)
        {
            // Cambiar el personaje según la selección guardada en PlayerPrefs
            ChangePlayerInMenu();
        }
        else
        {
            // Cambiar el personaje según el valor de playerSelected
            switch (playerSelected)
            {
                case Player.Frog:
                    spriteRenderer.sprite = playersRenderer[0]; // Asignar el sprite del personaje Frog
                    animator.runtimeAnimatorController = playersController[0]; // Asignar el controlador de animación de Frog
                    break;
                case Player.BlueMan:
                    spriteRenderer.sprite = playersRenderer[1]; // Asignar el sprite del personaje BlueMan
                    animator.runtimeAnimatorController = playersController[1]; // Asignar el controlador de animación de BlueMan
                    break;
                case Player.VirtualGuy:
                    spriteRenderer.sprite = playersRenderer[2]; // Asignar el sprite del personaje VirtualGuy
                    animator.runtimeAnimatorController = playersController[2]; // Asignar el controlador de animación de VirtualGuy
                    break;
                case Player.MaskDude:
                    spriteRenderer.sprite = playersRenderer[3]; // Asignar el sprite del personaje MaskDude
                    animator.runtimeAnimatorController = playersController[3]; // Asignar el controlador de animación de MaskDude
                    break;
                default:
                    break;
            }
        }
    }

    // Método que cambia el personaje según la selección guardada en PlayerPrefs
    public void ChangePlayerInMenu()
    {
        switch (PlayerPrefs.GetString("PlayerSelected"))
        {
            case "Frog":
                spriteRenderer.sprite = playersRenderer[0]; // Asignar el sprite del personaje Frog
                animator.runtimeAnimatorController = playersController[0]; // Asignar el controlador de animación de Frog
                break;
            case "BlueMan":
                spriteRenderer.sprite = playersRenderer[1]; // Asignar el sprite del personaje BlueMan
                animator.runtimeAnimatorController = playersController[1]; // Asignar el controlador de animación de BlueMan
                break;
            case "VirtualGuy":
                spriteRenderer.sprite = playersRenderer[2]; // Asignar el sprite del personaje VirtualGuy
                animator.runtimeAnimatorController = playersController[2]; // Asignar el controlador de animación de VirtualGuy
                break;
            case "MaskDude":
                spriteRenderer.sprite = playersRenderer[3]; // Asignar el sprite del personaje MaskDude
                animator.runtimeAnimatorController = playersController[3]; // Asignar el controlador de animación de MaskDude
                break;
            default:
                break;
        }
    }
}