using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    public GameObject[] enemiesPosition;
    public GameObject[] enemies;
    float timer;

    public float[] xMaxPosition;
    public float[] zMaxPosition;

    private void Start()
    {
        ResetGame();
    }

    private void Update()
    {

    }

    void ResetGame()
    {
        var totalEmenies = Random.Range(2, 5);
        enemies = new GameObject[totalEmenies];
        enemiesPosition = new GameObject[totalEmenies];

        for(int i = 0; i < enemies.Length; i++)
        {
            enemies[i] = Instantiate(enemy, new Vector3(
                Random.Range(xMaxPosition[0], xMaxPosition[1]),
                0.5f,
                Random.Range(zMaxPosition[0], xMaxPosition[1])),
                Quaternion.identity) ;
        }
    }
}
