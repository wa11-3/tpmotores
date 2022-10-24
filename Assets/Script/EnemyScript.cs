using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private int hp;
    private GameObject player;
    public int velocity;

    private void Start()
    {
        hp = 100;
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        transform.LookAt(player.transform);
        transform.Translate(velocity * Vector3.forward * Time.deltaTime);
    }

    public void Damage()
    {
        hp = hp - 25;
        if (hp < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Damage();
            Destroy(collision.gameObject);
        }
    }
}
