using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void Exit()
    {
        Debug.Log("Game Closd");
        Application.Quit();
    }

    public void StartGame()
    {
        Debug.Log("Start");
        int userId = PlayerPrefs.GetInt("userId");
        userId += 1;
        PlayerPrefs.SetInt("userId", userId);
        SceneManager.LoadScene("Escape Room");
    }
}
