using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public void ReloadGame()
    {
        Time.timeScale = 1.0f;
        AudioListener.pause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        FindObjectOfType<PauseGame>().PausedReset();
        PlayerPrefs.SetInt("continue", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(0);
    }
}
