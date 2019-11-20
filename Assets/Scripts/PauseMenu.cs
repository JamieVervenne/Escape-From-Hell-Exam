using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenuUI;
    [SerializeField] private bool isPaused;

    private void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            OpenMenu();
        }
        else
        {
            CloseMenu();
        }
    }

    void OpenMenu()
    {
        Time.timeScale = 0;
        PauseMenuUI.SetActive(true);
        AudioListener.pause = true;
    }

    public void CloseMenu()
    {
        Time.timeScale = 1;
        PauseMenuUI.SetActive(false);
        AudioListener.pause = false;
        isPaused = false;
    }
}
