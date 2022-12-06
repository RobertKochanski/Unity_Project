using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    private void Update()
    {
        if (PlayerPrefs.HasKey("continue"))
        {
            PlayerPrefs.DeleteKey("continue");
        }

        if (Input.anyKeyDown)
        {
            ReturnToMenuEvent();
        }
    }

    public void ReturnToMenuEvent()
    {
        SceneManager.LoadScene(0);
    }
}
