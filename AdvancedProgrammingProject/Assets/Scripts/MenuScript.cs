using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuScript : MonoBehaviour
{
   

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
    public GameObject p1Cursor;
    public GameObject w1Cursor;
    public GameObject p2Cursor;
    public GameObject w2Cursor;
    GameObject P1curCursor;
    GameObject P2curCursor;

    public int P1menuLocation;
    public int P2menuLocation;

    public string curMenu;


    private void Start()
    {
        localTimeScale = GameSettings.gameSpeed;
        //isPaused = false;
        P1menuLocation = 0;
        P2menuLocation = 0;
        curMenu = "None";
        P1curCursor = p1Cursor;
        P2curCursor = p2Cursor;
}
    void Update()
    {
        if (curMenu == "Pause")
        {
            P1curCursor = p1Cursor;
            P2curCursor = p2Cursor;
        }
        if (curMenu == "Win")
        {
            P2curCursor = w2Cursor;
           
        }
        //Debug.Log(deltaTime);
        //Debug.Log(isPaused);
    }  

    public void PauseToggle()
    {
        if(RoundManager.canPause == false)
        {
            return;
        }
        if(curMenu != "Win")
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                curMenu = "Pause";
                P1menuLocation = 0;
                P2menuLocation = 0;
                P1curCursor.transform.position = new Vector2(P1curCursor.transform.position.x, menuOptions[0].transform.position.y - 25);
                P2curCursor.transform.position = new Vector2(P2curCursor.transform.position.x, menuOptions[0].transform.position.y - 25);
                pauseMenu.SetActive(true);
                localTimeScale = 0f;
            }
            else
            {
                curMenu = "None";
                pauseMenu.SetActive(false);
                localTimeScale = GameSettings.gameSpeed;
            }
        }
        
    }

    public void P1MenuNavigation(InputAction.CallbackContext context)
    {
        
        Vector2 inputVector = context.ReadValue<Vector2>();
        P1menuLocation -= Mathf.RoundToInt(inputVector.y);
        if (curMenu == "Pause")
        {
            if (P1menuLocation > menuOptions.Length - 1)
            {
                P1menuLocation = 0;
            }
            if (P1menuLocation < 0)
            {
                P1menuLocation = menuOptions.Length - 1;
            }
            P1curCursor.transform.position = new Vector2(P1curCursor.transform.position.x, menuOptions[P1menuLocation].transform.position.y - 25);
        }
        else if(curMenu == "Win")
        { 
            if (P1menuLocation > winMenuOptions.Length - 1)
            {
                P1menuLocation = 0;
            }
            if (P1menuLocation < 0)
            {
                P1menuLocation = winMenuOptions.Length - 1;
            }
            P1curCursor.transform.position = new Vector2(P1curCursor.transform.position.x, winMenuOptions[P1menuLocation].transform.position.y - 25);
        }
       
    }

    public void P1MenuConfirm()
    {
        if(curMenu == "Pause")
        {
            switch (P1menuLocation)
            {
                //resume
                case 0:
                    //Debug.Log("resume");
                    PauseToggle();
                    break;
                //restart
                case 1:
                    RoundManager.GameReset();
                   // Debug.Log("restart");
                    break;
                //quit
                case 2:
                    RoundManager.QuitToMenu();
                    break;
            }
        }
        if (curMenu == "Win")
        {         
            switch (P1menuLocation)
            {            
                //restart
                case 0:
                    RoundManager.GameReset();
                   // Debug.Log("restart");
                    break;
                //quit
                case 1:
                    RoundManager.QuitToMenu();
                    //Debug.Log("quit");
                    break;
            }
        }
    }
    public void P2MenuNavigation(InputAction.CallbackContext context)
    {
        
        Vector2 inputVector = context.ReadValue<Vector2>();
        P2menuLocation -= Mathf.RoundToInt(inputVector.y);
        if (curMenu == "Pause")
        {
            if (P2menuLocation > menuOptions.Length - 1)
            {
                P2menuLocation = 0;
            }
            if (P2menuLocation < 0)
            {
                P2menuLocation = menuOptions.Length - 1;
            }
            P2curCursor.transform.position = new Vector2(P2curCursor.transform.position.x, menuOptions[P2menuLocation].transform.position.y - 25);
        }
        else if (curMenu == "Win")
        {
            if (P2menuLocation > winMenuOptions.Length - 1)
            {
                P2menuLocation = 0;
            }
            if (P2menuLocation < 0)
            {
                P2menuLocation = winMenuOptions.Length - 1;
            }
            P2curCursor.transform.position = new Vector2(P2curCursor.transform.position.x, winMenuOptions[P2menuLocation].transform.position.y - 25);
        }

    }

    public void P2MenuConfirm()
    {
        if (curMenu == "Pause")
        {
            switch (P2menuLocation)
            {
                //resume
                case 0:
                  //  Debug.Log("resume");
                    PauseToggle();
                    break;
                //restart
                case 1:
                    RoundManager.GameReset();
               //     Debug.Log("restart");
                    break;
                //quit
                case 2:
                    RoundManager.QuitToMenu();
                    break;
            }
        }
        if (curMenu == "Win")
        {
            switch (P2menuLocation)
            {
                //restart
                case 0:
                    RoundManager.GameReset();
                //    Debug.Log("restart");
                    break;
                //quit
                case 1:
                    RoundManager.QuitToMenu();
                 //   Debug.Log("quit");
                    break;
            }
        }


    }
}