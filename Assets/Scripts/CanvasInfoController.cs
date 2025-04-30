using UnityEngine;

public class CanvasInfoController : MonoBehaviour
{
    public GameObject textControles; // Referencia al objeto TextControles

    // Método para mostrar el texto al hacer clic y ocultarlo al soltar
    public void MostrarTextControles(bool mostrar)
    {
        if (textControles != null)
        {
            textControles.SetActive(mostrar); // Activa o desactiva el texto según el parámetro
        }
    }
}