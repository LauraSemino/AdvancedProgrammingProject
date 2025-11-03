using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int pNum;
    public Rigidbody2D rb;
    public float speed;

    Vector2 dir;

    //PlayerController controls;
    //Gamepad currentGamepad;
    //Keyboard currentKeyboard;

    InputDevice currentInputDevice;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
       // currentInputDevice = ;
       // deviceType = currentInputDevice.device.name;
        if (currentInputDevice != null)
        {
            
            return;
           //connected controller
        }
        else if (currentInputDevice != null)
        {
            return;
            //connected keybaord
        }
       
    }

    private void FixedUpdate()
    {     
        rb.linearVelocityX = dir.x * speed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        Debug.Log(context.control);
        InputControl control = context.control;

        if (control.device == Gamepad.current)
        {
            Gamepad gamepad = (Gamepad)control.device;
            dir = gamepad.leftStick.ReadValue();
        }
        else if (control.device == Keyboard.current)
        {
            Keyboard gamepad = (Keyboard)control.device;
            dir = new Vector2(gamepad.dKey.ReadValue() - gamepad.aKey.ReadValue(), 0);
        }

    }

    

}
