using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDataManager : MonoBehaviour
{
    public void gameOver()
    {
        PlayerPrefs.SetInt("sessionPlayed", 1);
        int userId = PlayerPrefs.GetInt("userId");
        if (String.IsNullOrEmpty(userId.ToString()))
        {
            userId = 0;
        }

        userId++;
        var name = "user" + userId.ToString();
        var time = (float) Time.timeSinceLevelLoad;
        saveUserPerformance(time, name);

        PlayerPrefs.SetFloat("currPlayerScore", time);
        PlayerPrefs.SetString("currPlayerName", name);
        
        SceneManager.LoadScene("Lobby Room");
    }

    private void saveUserPerformance(float time, string name)
    {
        if (PlayerPrefs.GetFloat("HighScore1") == 0)
        {
            PlayerPrefs.SetFloat("HighScore1", time);
            PlayerPrefs.SetString("HighScore1Name", name);
            return;
        }
        if (PlayerPrefs.GetFloat("HighScore2") == 0)
        {
            if (time < PlayerPrefs.GetFloat("HighScore1"))
            {
                PlayerPrefs.SetFloat("HighScore2", PlayerPrefs.GetFloat("HighScore1"));
                PlayerPrefs.SetString("HighScore2Name", PlayerPrefs.GetString("HighScore1Name"));
                PlayerPrefs.SetFloat("HighScore1", time);
                PlayerPrefs.SetString("HighScore1Name", name);
                return;
            } else
            {
                PlayerPrefs.SetFloat("HighScore2", time);
                PlayerPrefs.SetString("HighScore2Name", name);
            }
            return;
        }
        if (PlayerPrefs.GetFloat("HighScore3") == 0)
        {
            if (time < PlayerPrefs.GetFloat("HighScore1"))
            {
                insertToFirst(name, time);
            } else if (time < PlayerPrefs.GetFloat("HighScore2"))
            {
                insertToSecond(name, time);
            } else
            {
                insertToThird(name, time);
            }
            return;
        }

        if (time < PlayerPrefs.GetFloat("HighScore1"))
        {
            insertToFirst(name, time);
        } else if (time < PlayerPrefs.GetFloat("HighScore2"))
        {
            insertToSecond(name, time);
        } else if (time < PlayerPrefs.GetFloat("HighScore3"))
        {
            insertToThird(name, time);
        }
    }

    private void insertToFirst(string name, float time)
    {
        PlayerPrefs.SetFloat("HighScore3", PlayerPrefs.GetFloat("HighScore2"));
        PlayerPrefs.SetString("HighScore3Name", PlayerPrefs.GetString("HighScore2Name"));
        PlayerPrefs.SetFloat("HighScore2", PlayerPrefs.GetFloat("HighScore1"));
        PlayerPrefs.SetString("HighScore2Name", PlayerPrefs.GetString("HighScore1Name"));
        PlayerPrefs.SetFloat("HighScore1", time);
        PlayerPrefs.SetString("HighScore1Name", name);
    }

    private void insertToSecond(string name, float time)
    {
        PlayerPrefs.SetFloat("HighScore3", PlayerPrefs.GetFloat("HighScore2"));
        PlayerPrefs.SetString("HighScore3Name", PlayerPrefs.GetString("HighScore2Name"));
        PlayerPrefs.SetFloat("HighScore2", time);
        PlayerPrefs.SetString("HighScore2Name", name);
    }

    private void insertToThird(string name, float time)
    {
        PlayerPrefs.SetFloat("HighScore3", time);
        PlayerPrefs.SetString("HighScore3Name", name);
    }
}
