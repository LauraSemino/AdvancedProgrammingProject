using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuScript : MonoBehaviour
{
    public float gameSpeed;

    public static bool isPaused = false;
    public static float localTimeScale;

    public static float deltaTime
    {
        get
        {
            return Time.deltaTime * localTimeScale;
        }

    }
    public GameObject pauseMenu;

    private void Start()
    {
        localTimeScale = gameSpeed;
    }
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
            localTimeScale = gameSpeed;
        }
    }
}