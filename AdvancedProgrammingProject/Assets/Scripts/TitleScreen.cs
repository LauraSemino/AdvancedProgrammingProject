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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
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
            p1Cursor.transform.position = new Vector2(p1Cursor.transform.position.x, menuOptions[p1MenuLocation].transform.position.y - 25);
       
    }

    public void P1MenuConfirm()
    {
        switch (p1MenuLocation)
        {
            //resume
            case 0:
                Debug.Log("versus match");
                SceneManager.LoadScene("Main");
                break;
            //restart
            case 1:
                RoundManager.GameReset();
                Debug.Log("options");
                break;
            //quit
            case 2:
                Debug.Log("quit");
                RoundManager.QuitToMenu();
                break;
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
        p2Cursor.transform.position = new Vector2(p2Cursor.transform.position.x, menuOptions[p2MenuLocation].transform.position.y - 25);

    }

    public void P2MenuConfirm()
    {
        switch (p2MenuLocation)
        {
            //resume
            case 0:
                Debug.Log("versus match");
                SceneManager.LoadScene("Main");
                break;
            //restart
            case 1:
                
                Debug.Log("options");
                break;
            //quit
            case 2:
                Debug.Log("quit");
                
                break;
        }

    }

}
