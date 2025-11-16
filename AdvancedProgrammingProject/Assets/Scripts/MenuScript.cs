using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuScript : MonoBehaviour
{
    public static bool isPaused = false;
    public static float localTimeScale = 1;

    public static float deltaTime
    {
        get
        {
            return Time.deltaTime * localTimeScale;
        }

    }
    
    public GameObject pauseMenu;
    void Update()
    {
        Debug.Log(deltaTime);
    }  

    public void PauseToggle()
    {

        isPaused = !isPaused;
        if (isPaused)
        {
            pauseMenu.SetActive(true);
            localTimeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            localTimeScale = 1f;
        }
    }
}