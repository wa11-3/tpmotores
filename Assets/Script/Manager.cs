using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Manager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    public List<GameObject> enemies;
    public float timer;

    public float[] xMaxPosition;
    public float[] zMaxPosition;

    public static bool gameover = true;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI enemiesText;

    private void Start()
    {
        enemies.Clear();
        var totalEmenies = Random.Range(2, 5);

        for (int i = 0; i < totalEmenies; i++)
        {
            enemies.Add(Instantiate(enemy, new Vector3(
                Random.Range(xMaxPosition[0], xMaxPosition[1]),
                0.5f,
                Random.Range(zMaxPosition[0], xMaxPosition[1])),
                Quaternion.identity));
        }

        StartCoroutine(Timer());
    }

    private void Update()
    {

    }

    public IEnumerator Timer()
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(1.0f);
            timer--;
        }
        SceneManager.LoadScene("GameOver");
    }
}
