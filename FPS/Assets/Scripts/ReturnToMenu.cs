using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    private void Update()
    {
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
