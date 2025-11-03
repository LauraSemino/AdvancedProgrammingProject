using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int pNum;
    public Rigidbody2D rb;
    public float speed;

    Vector2 dir;

    public string deviceType;
    Gamepad currentGamepad;
    Keyboard currentKeyboard;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentGamepad = Gamepad.current;
        if (currentGamepad != null)
        {
            Debug.Log(currentGamepad.name);
            return;
           //connected device
        }
       
    }

    private void FixedUpdate()
    {     
        rb.linearVelocityX = dir.x * speed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        dir = currentGamepad.leftStick.ReadValue();
    }
}
