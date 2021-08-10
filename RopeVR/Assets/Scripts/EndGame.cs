using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform end;
    [SerializeField] LayerMask endMask;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.2f;

    public GameObject menuBackgroundUI;
    public GameObject endMenuUI;

    public bool touchedEnd { get; private set; }
    public static bool GameHaveEnded = false;
    public AudioSource gameMusic;
    public AudioSource endSound;

    void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, -10, player.transform.position.z);

        touchedEnd = Physics.CheckSphere(groundCheck.position, groundDistance, endMask);

        if (touchedEnd)
        {
            End();
        }
    }

    public void End()
    {
        gameMusic.Stop();
        endSound.Play(0);
        endMenuUI.SetActive(true);
        menuBackgroundUI.SetActive(true);
        Time.timeScale = 0f;
        PauseMenu.GameIsPaused = true;
        GameHaveEnded = true;
    }
}
