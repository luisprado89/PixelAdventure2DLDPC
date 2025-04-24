using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;
    private float CheckPointPositionX, CheckPointPositionY;
    public Animator animator;


    void Start()
    {
        life = hearts.Length;
        if (PlayerPrefs.GetFloat("CheckPointPositionX") != 0)
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("CheckPointPositionX"), PlayerPrefs.GetFloat("CheckPointPositionY")));
        }
    }
    private void CheckLife()
    {
        if (life < 1)
        {
            Destroy(hearts[0].gameObject);
            animator.Play("Hit");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);//para resetar el nivel o escena
        }
        else if (life < 2)
        {
            Destroy(hearts[1].gameObject);
            animator.Play("Hit");
        }
        else if (life < 3)
        {
            Destroy(hearts[2].gameObject);
            animator.Play("Hit");
        }
    }
    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("CheckPointPositionX", x);
        PlayerPrefs.SetFloat("CheckPointPositionY", y);
    }
    public void PlayerDamaged()
    {
        life--;
        CheckLife();
    }

}
