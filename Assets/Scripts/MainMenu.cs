using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public int playerLives;
    public int playerKeys;
    public int playerScore;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);
        PlayerPrefs.SetInt("PlayerKeys", playerKeys);
        PlayerPrefs.SetInt("PlayerScore", playerScore);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
