using System;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenu;
    void Update()
    {
        
    }  

    public void PauseToggle()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}