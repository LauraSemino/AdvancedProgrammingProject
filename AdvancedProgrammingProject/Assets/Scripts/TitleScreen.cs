using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public int p1MenuLocation;
    public int p2MenuLocation;
    public GameObject p1Cursor;
    public GameObject p2Cursor;
    public GameObject[] menuOptions;
    public GameObject[] gameOptions;
    public string curMenu;

    public GameObject titleMenu;
    public GameObject optionsMenu;

    public float[] speeds;
    float curSpeedOption;

    public void Start()
    {
        curSpeedOption = 0;
        curMenu = "Title";
    }

    public void LoadMenu(string menu)
    {
        if(menu == "Title")
        {         
            curMenu = "Title";
            p1MenuLocation = 0;
            p1Cursor.transform.position = new Vector2(p1Cursor.transform.position.x, gameOptions[0].transform.position.y - 25);
            p2MenuLocation = 0;
            p2Cursor.transform.position = new Vector2(p2Cursor.transform.position.x, gameOptions[0].transform.position.y - 25);
            titleMenu.gameObject.SetActive(true);
            optionsMenu.gameObject.SetActive(false);
        }
        else if(menu == "Options")
        {
            curMenu = "Options";
            p1MenuLocation = 0;
            p1Cursor.transform.position = new Vector2(p1Cursor.transform.position.x, menuOptions[0].transform.position.y - 25);
            p2MenuLocation = 0;
            p2Cursor.transform.position = new Vector2(p2Cursor.transform.position.x, menuOptions[0].transform.position.y - 25);
            optionsMenu.gameObject.SetActive(true);
            titleMenu.gameObject.SetActive(false);
        }
    }

    public void P1MenuNavigation(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
        p1MenuLocation -= Mathf.RoundToInt(inputVector.y);
       
            if (p1MenuLocation > menuOptions.Length - 1)
            {
                p1MenuLocation = 0;
            }
            if (p1MenuLocation < 0)
            {
                p1MenuLocation = menuOptions.Length - 1;
            }
            if(curMenu == "Title")
            {
                p1Cursor.transform.position = new Vector2(p1Cursor.transform.position.x, menuOptions[p1MenuLocation].transform.position.y - 25);
            }
            if (curMenu == "Options")
            {
                p1Cursor.transform.position = new Vector2(p1Cursor.transform.position.x, gameOptions[p1MenuLocation].transform.position.y - 25);
            }

    }

    public void P1MenuConfirm(InputAction.CallbackContext context)
    {
        if (!context.started )
        { return; }
       
        if (curMenu == "Title")
        {
            switch (p1MenuLocation)
            {
                //resume
                case 0:
                    // Debug.Log("versus match");
                    SceneManager.LoadScene("Main");
                    break;
                //restart
                case 1:
                   
                    LoadMenu("Options");
                    break;
                //quit
                case 2:
                    Application.Quit();
                    break;
            }
        }
        else if (curMenu == "Options")
        {
            switch (p1MenuLocation)
            {
                
                case 0:
                    ChangeSpeed();
                    break;
                
                case 1:
                    LoadMenu("Title");
                    break;
                
                case 2:
                    
                    break;
            }
        }

    }
    public void P2MenuNavigation(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
        p2MenuLocation -= Mathf.RoundToInt(inputVector.y);

        if (p2MenuLocation > menuOptions.Length - 1)
        {
            p2MenuLocation = 0;
        }
        if (p2MenuLocation < 0)
        {
            p2MenuLocation = menuOptions.Length - 1;
        }
        if (curMenu == "Title")
        {
            p2Cursor.transform.position = new Vector2(p2Cursor.transform.position.x, menuOptions[p2MenuLocation].transform.position.y - 25);
        }
        if (curMenu == "Options")
        {
            p2Cursor.transform.position = new Vector2(p2Cursor.transform.position.x, gameOptions[p2MenuLocation].transform.position.y - 25);
        }

    }

    public void P2MenuConfirm(InputAction.CallbackContext context)
    {
        
        if(!context.started)
        { return; }
       
        if (curMenu == "Title")
        {
            switch (p2MenuLocation)
            {
                //resume
                case 0:
                    // Debug.Log("versus match");
                    SceneManager.LoadScene("Main");
                    break;
                //restart
                case 1:
                    LoadMenu("Options");
                    break;
                //quit
                case 2:
                    Application.Quit();
                    break;
            }
        }
        else if (curMenu == "Options")
        {
            switch (p2MenuLocation)
            {
                //resume
                case 0:
                    
                    ChangeSpeed();
                    break;

                case 1:
                    LoadMenu("Title");
                    break;

                case 2:

                    break;
            }
        }

    }

    public void ChangeSpeed()
    {
        curSpeedOption += 1;
        if(curSpeedOption > speeds.Length - 1)
        {
            curSpeedOption = 0;
        }
        string displaySpeed = "TURBO";
        switch (curSpeedOption)
        {
            case 0:
                GameSettings.gameSpeed = 1;
                displaySpeed = "TURBO";
                break;
            case 1:
                GameSettings.gameSpeed = 1.25f;
                displaySpeed = "SUPER TURBO";           
                break;
            case 2:
                GameSettings.gameSpeed = 0.75f;
                displaySpeed = "NORMAL";
                break;
        }
        gameOptions[0].GetComponent<TextMeshProUGUI>().text = displaySpeed;
    }
}
