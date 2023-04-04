using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    void Update()
    {
        // Move the player based on user input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime);

        // Shoot a bullet when the user presses the spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 20;
        }
    }
}