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

    public int totalEnemies;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI enemiesText;

    private static Manager _singleton;
    public static Manager Singleton
    {
        get => _singleton;
        private set
        {
            if (_singleton == null)
                _singleton = value;
            else if (_singleton != value)
            {
                Debug.Log($"{nameof(Manager)} instance already exists, destroying duplicate!");
                Destroy(value);
            }
        }
    }

    private void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        gameover = true;
        enemies.Clear();
        totalEnemies = Random.Range(2, 5);

        for (int i = 0; i < totalEnemies; i++)
        {
            enemies.Add(Instantiate(enemy, new Vector3(
                Random.Range(xMaxPosition[0], xMaxPosition[1]),
                0.5f,
                Random.Range(zMaxPosition[0], xMaxPosition[1])),
                Quaternion.identity));
        }

        enemiesText.text = $"Enemies: {totalEnemies}";
        StartCoroutine(Timer());
    }

    private void Update()
    {
        if(totalEnemies == 0)
        {
            gameover = false;
            SceneManager.LoadScene("GameOver");
        }
    }

    public IEnumerator Timer()
    {
        while (timer > 0)
        {
            timerText.text = $"{timer} seconds";
            yield return new WaitForSeconds(1.0f);
            timer--;
        }
        SceneManager.LoadScene("GameOver");
    }

    public void enemyCount()
    {
        totalEnemies--;
        enemiesText.text = $"Enemies: {totalEnemies}";
    }
}
