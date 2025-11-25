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
    public GameObject[] winMenuOptions;
    public GameObject pCursor;
    public GameObject wCursor;
    GameObject curCursor;

    public int menuLocation;

    public string curMenu;


    private void Start()
    {
        localTimeScale = gameSpeed;
        //isPaused = false;
        menuLocation = 0;
        curMenu = "None";
        curCursor = pCursor;
}
    void Update()
    {
        if (curMenu == "Pause")
        {
            curCursor = pCursor;
        }
        if (curMenu == "Win")
        {
            curCursor = wCursor;
           
        }
        //Debug.Log(deltaTime);
        //Debug.Log(isPaused);
    }  

    public void PauseToggle()
    {
        if(curMenu != "Win")
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                curMenu = "Pause";
                menuLocation = 0;
                curCursor.transform.position = new Vector2(curCursor.transform.position.x, menuOptions[0].transform.position.y - 25);
                pauseMenu.SetActive(true);
                localTimeScale = 0f;
            }
            else
            {
                curMenu = "None";
                pauseMenu.SetActive(false);
                localTimeScale = gameSpeed;
            }
        }
        
    }

    public void MenuNavigation(InputAction.CallbackContext context)
    {   
        
        Vector2 inputVector = context.ReadValue<Vector2>();
        menuLocation -= Mathf.RoundToInt(inputVector.y);
        if (curMenu == "Pause")
        {
            if (menuLocation > menuOptions.Length - 1)
            {
                menuLocation = 0;
            }
            if (menuLocation < 0)
            {
                menuLocation = menuOptions.Length - 1;
            }
            curCursor.transform.position = new Vector2(curCursor.transform.position.x, menuOptions[menuLocation].transform.position.y - 25);
        }
        else if(curMenu == "Win")
        { 
            if (menuLocation > winMenuOptions.Length - 1)
            {
                menuLocation = 0;
            }
            if (menuLocation < 0)
            {
                menuLocation = winMenuOptions.Length - 1;
            }
            curCursor.transform.position = new Vector2(curCursor.transform.position.x, winMenuOptions[menuLocation].transform.position.y - 25);
        }
       
    }

    public void MenuConfirm()
    {
        if(curMenu == "Pause")
        {
            switch (menuLocation)
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
                    RoundManager.QuitToMenu();
                    break;
            }
        }
        if (curMenu == "Win")
        {         
            switch (menuLocation)
            {            
                //restart
                case 0:
                    RoundManager.GameReset();
                    Debug.Log("restart");
                    break;
                //quit
                case 1:
                    RoundManager.QuitToMenu();
                    Debug.Log("quit");
                    break;
            }
        }
    }

}