using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class DataDisplay : MonoBehaviour
{
    public TextMeshProUGUI player1Name;
    public TextMeshProUGUI player1Score;
    public TextMeshProUGUI player2Name;
    public TextMeshProUGUI player2Score;
    public TextMeshProUGUI player3Name;
    public TextMeshProUGUI player3Score;
    public TextMeshProUGUI currUser;

    public GameObject MenuEmptyUI;
    public GameObject GameOverUI;

    private Vector3 startPosition = new Vector3(-2.15f, 0, -0.34f);
    private Vector3 startDirection = new Vector3(0, 174.001f, 0);

    void Start()
    {
        setPlayerPositionAndDirection(startPosition, startDirection);

        if (PlayerPrefs.GetInt("sessionPlayed") == 1)
        {
            DisplayPlayerData();
            DisplayGameOverUI();
        }

        InitData();
    }

    private void setPlayerPositionAndDirection(Vector3 position, Vector3 direction)
    {
        gameObject.transform.position = position;
        gameObject.transform.rotation = Quaternion.Euler(direction);
    }


    private void DisplayPlayerData()
    {
        currUser.text = $"Hi {PlayerPrefs.GetString("currPlayerName")}, your time playing: {(int)PlayerPrefs.GetFloat("currPlayerScore")}s";
    }

    public void DisplayGameOverUI()
    {
        // set mainmenu ui to disable
        MenuEmptyUI.gameObject.SetActive(false);

        //set gameover ui to enable
        GameOverUI.gameObject.SetActive(true);
    }

    public void DisplayMainMenuUI()
    {
        PlayerPrefs.SetInt("sessionPlayed", 0);
        MenuEmptyUI.gameObject.SetActive(true);
        GameOverUI.gameObject.SetActive(false);
    }

    private void InitData()
    {
        player1Name.text = PlayerPrefs.GetString("HighScore1Name");
        player1Score.text = ((int)PlayerPrefs.GetFloat("HighScore1")).ToString() + "s";
        player2Name.text = PlayerPrefs.GetString("HighScore2Name");
        player2Score.text = ((int)PlayerPrefs.GetFloat("HighScore2")).ToString() + "s";
        player3Name.text = PlayerPrefs.GetString("HighScore3Name");
        player3Score.text = ((int)PlayerPrefs.GetFloat("HighScore3")).ToString() + "s";
    }
}

