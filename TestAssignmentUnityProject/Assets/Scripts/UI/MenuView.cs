using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuView : MonoBehaviour
{
    public static bool IsPaused;
    
    public void OnStartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnPauseButton()
    {
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void OnContinueButton()
    {
        Time.timeScale = 1f;
        IsPaused = false;
    }
    
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
