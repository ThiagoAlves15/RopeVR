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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        menuBackgroundUI.SetActive(true);
        scoreUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void Restart()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        menuBackgroundUI.SetActive(false);
        scoreUI.SetActive(true);
        endGameUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameIsPaused = false;
        EndGame.GameHaveEnded = false;
        SceneManager.LoadScene("GrapplingRopeScene");
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        GameIsPaused = false;
        SceneManager.LoadScene("MainMenu");
    }
}
