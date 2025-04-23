using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class OpenDoor : MonoBehaviour
{
    public TMP_Text text;
    public string levelName;
    private bool inDoor = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(true);
            inDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // text.gameObject.SetActive(false);
        // inDoor = false;

        //Version que me da CHatgpt
        if (text != null)
        {
            text.gameObject.SetActive(false);
        }
        inDoor = false;

    }
    private void Update()
    {
        if (inDoor && Input.GetKey("e"))
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
