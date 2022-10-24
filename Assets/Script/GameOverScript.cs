using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    public TextMeshProUGUI titelText;

    private void Awake()
    {
        if (Manager.gameover)
        {
            titelText.text = "You Lost";
        }
        else
        {
            titelText.text = "You Win";
        }
        Cursor.lockState = CursorLockMode.None;
    }

    public void GotoLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
