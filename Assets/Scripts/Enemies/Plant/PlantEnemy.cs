using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    private float waitedTime;
    public float waitTimeToAttack = 3;
    public Animator animator;
    public GameObject bulletPrefab;
    public Transform launchSpawnPoint;
    private void Start()
    {
        waitedTime = waitTimeToAttack;
    }
    private void Update()
    {
        if (waitedTime <= 0)
        {
            waitedTime = waitTimeToAttack;
            //animator.Play("Attack");
            if (animator != null)
                animator.Play("Attack");

            Invoke("LaunchBullet", 0.5f);
        }
        else
        {
            waitedTime -= Time.deltaTime;
        }
    }
    public void LaunchBullet()
    {
        //GameObject newBullet;
        //newBullet = Instantiate(bulletPrefab, launchSpawnPoint.position, launchSpawnPoint.rotation);


        if (bulletPrefab != null && launchSpawnPoint != null)
        {
            GameObject newBullet = Instantiate(bulletPrefab, launchSpawnPoint.position, launchSpawnPoint.rotation);
        }
        else
        {
            Debug.LogWarning("bulletPrefab o launchSpawnPoint no están asignados o han sido destruidos.");
        }

    }


}
