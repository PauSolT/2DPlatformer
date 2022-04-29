using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{

    public Text timeText; 
    float currentLevelTime = 0f;

    public static bool isPaused = false;

    public GameObject pauseMenu;

    public void UpdateTimer()
    {
        PauseMenuControl();
        AddTimeToLevel();
    }

    void PauseMenuControl()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
            ShowPauseMenu();
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
            HidePauseMenu();
    }

    void AddTimeToLevel()
    {
        if (!isPaused)
        {
            currentLevelTime += Time.deltaTime;
            timeText.text = currentLevelTime.ToString("0.00");
        }
    }

    void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
    }

    public void HidePauseMenu()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }


}
