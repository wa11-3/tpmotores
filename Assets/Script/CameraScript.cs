using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Vector2 mouseView = new Vector2(-120f, 0.0f);
    Vector2 smoothness;

    public float sensibility = 5.0f;
    public float smooth = 2.0f;

    GameObject player;

    private void Start()
    {
        player = this.transform.parent.gameObject;
    }

    private void Update()
    {
        Vector2 moveCamera = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        moveCamera = Vector2.Scale(moveCamera, new Vector2(sensibility * smooth, sensibility * smooth));

        smoothness.x = Mathf.Lerp(smoothness.x, moveCamera.x, 1.0f / smooth);
        smoothness.y = Mathf.Lerp(smoothness.y, moveCamera.y, 1.0f / smooth);

        mouseView += smoothness;

        mouseView.y = Mathf.Clamp(mouseView.y, -90f, 90f);

        transform.localRotation = Quaternion.AngleAxis(-mouseView.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseView.x, player.transform.up);

    }
}
