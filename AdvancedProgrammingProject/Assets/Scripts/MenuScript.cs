using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuScript : MonoBehaviour
{
    public float gameSpeed;

    public static bool isPaused;
    public static float localTimeScale;

    public static float deltaTime
    {
        get
        {
            return Time.deltaTime * localTimeScale;
        }

    }
    public GameObject pauseMenu;

    //menu navigation stuff
    public GameObject[] menuOptions;
    public GameObject cursor;
    public int menuLocation;

    private void Start()
    {
        localTimeScale = gameSpeed;
        //isPaused = false;
        menuLocation = 0;
}
    void Update()
    {
        //Debug.Log(deltaTime);
       // Debug.Log(isPaused);
    }  

    public void PauseToggle()
    {

        isPaused = !isPaused;
        if (isPaused)
        {
            menuLocation = 0;
            cursor.transform.position = new Vector2(cursor.transform.position.x, menuOptions[0].transform.position.y - 25);
            pauseMenu.SetActive(true);
            localTimeScale = 0f;  
        }
        else
        {
            pauseMenu.SetActive(false);
            localTimeScale = gameSpeed;
        }
    }

    public void MenuNavigation(InputAction.CallbackContext context)
    {
        
        Vector2 inputVector = context.ReadValue<Vector2>();
        menuLocation -= Mathf.RoundToInt(inputVector.y);
        if(menuLocation > menuOptions.Length-1)
        {
            menuLocation = 0;
        }
        if (menuLocation < 0)
        {
            menuLocation = menuOptions.Length - 1;
        }
        cursor.transform.position = new Vector2(cursor.transform.position.x, menuOptions[menuLocation].transform.position.y - 25);
    }

    public void MenuConfirm()
    {
        switch(menuLocation)
        {
            //resume
            case 0:
                Debug.Log("resume");
                PauseToggle();
                break;
            //restart
            case 1:
                RoundManager.GameReset();
                Debug.Log("restart");
                break;
            //quit
            case 2:
                Debug.Log("quit");
                break;
        }
    }

}