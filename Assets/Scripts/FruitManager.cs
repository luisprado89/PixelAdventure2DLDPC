using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class FruitManager : MonoBehaviour
{
    public TMP_Text levelCleared;
    public GameObject transition;
    public TMP_Text totalFruits;
    public TMP_Text fruitsCollected;
    private int totalFruitsInLevel;
    void Start()
    {
        totalFruitsInLevel = transform.childCount;
    }
    private void Update()
    {
        AllFruitCollected();
        totalFruits.text = totalFruitsInLevel.ToString();
        fruitsCollected.text = transform.childCount.ToString();
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
