using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    private float CheckPointPositionX, CheckPointPositionY;
    public Animator animator;


    void Start()
    {
        if (PlayerPrefs.GetFloat("CheckPointPositionX") != 0)
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("CheckPointPositionX"), PlayerPrefs.GetFloat("CheckPointPositionY")));
        }
    }
    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("CheckPointPositionX", x);
        PlayerPrefs.SetFloat("CheckPointPositionY", y);
    }
    public void PlayerDamaged()
    {
        animator.Play("Hit");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//para resetar el nivel o escena
    }

}
