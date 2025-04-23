using UnityEngine;

public class DamageObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //Debug.Log("Player Dañado");
            collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();
            //Destroy(collision.gameObject);
        }
    }

}
