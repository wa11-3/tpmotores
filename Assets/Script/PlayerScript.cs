using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speedMove = 10.0f;

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
    }
}
