using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class FruitManager : MonoBehaviour
{
    public TMP_Text levelCleared;
    public GameObject transition;
    private void Update()
    {
        AllFruitCollected();
    }
    public void AllFruitCollected()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("No quedan frutas");
            levelCleared.gameObject.SetActive(true);//Aqui activamos el texto
            transition.SetActive(true);
            Invoke("ChangeScene", 2);//Asi tardara 2 segundo en llamar al cambio de escena

        }
    }
    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
