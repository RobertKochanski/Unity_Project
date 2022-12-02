using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField]
    private Canvas pauseCanvas;

    private bool paused = false;

    private void Start()
    {
        pauseCanvas.enabled = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }

        GamePaused(paused);
    }

    public void GamePaused(bool paused)
    {
        if (paused)
        {
            pauseCanvas.enabled = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            FindObjectOfType<WeaponSwitch>().enabled = false;
            FindObjectOfType<Weapon>().enabled = false;
            AudioListener.pause = true;
        }
        else
        {
            pauseCanvas.enabled = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            FindObjectOfType<WeaponSwitch>().enabled = true;
            FindObjectOfType<Weapon>().enabled = true;
            AudioListener.pause = false;
        }
    }

    public void PausedReset()
    {
        paused = false;
    }
}
