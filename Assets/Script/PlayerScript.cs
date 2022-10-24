using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speedMove = 10.0f;

    public GameObject Bullet;
    public float bulletForce;
    public Transform spawnPosition;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float moveForward = Input.GetAxis("Vertical") * speedMove * Time.deltaTime;
        float moveSide = Input.GetAxis("Horizontal") * speedMove * Time.deltaTime;

        transform.Translate(moveSide, 0, moveForward);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletClone = Instantiate(Bullet, spawnPosition.position, spawnPosition.rotation);

            Rigidbody rb = bulletClone.GetComponent<Rigidbody>();

            rb.AddRelativeForce(Vector3.up * bulletForce, ForceMode.Impulse);

            Destroy(bulletClone, 5);
        }
    }
}
