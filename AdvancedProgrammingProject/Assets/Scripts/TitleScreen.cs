using UnityEngine;
using UnityEngine.InputSystem;

public class TitleScreen : MonoBehaviour
{
    public int menuLocation;
    public GameObject curCursor;
    public GameObject[] menuOptions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void MenuNavigation(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
        menuLocation -= Mathf.RoundToInt(inputVector.y);
       
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

    public void MenuConfirm()
    {
        switch (menuLocation)
        {
            //resume
            case 0:
                Debug.Log("versus match");
                
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

}
