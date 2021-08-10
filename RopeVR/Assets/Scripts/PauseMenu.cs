using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject menuBackgroundUI;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject endGameUI;
    public GameObject scoreUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !EndGame.GameHaveEnded)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        menuBackgroundUI.SetActive(false);
        scoreUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        menuBackgroundUI.SetActive(true);
        scoreUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Restart()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        menuBackgroundUI.SetActive(false);
        scoreUI.SetActive(true);
        endGameUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        EndGame.GameHaveEnded = false;
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(0);
    }
}
