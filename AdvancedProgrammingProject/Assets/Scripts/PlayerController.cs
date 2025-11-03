using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int pNum;
    public Rigidbody2D rb;

    public float speed;
    public float jumpForce;

    Vector2 dir;
    public bool doJump;
    public bool grounded;
    //PlayerController controls;
    //Gamepad currentGamepad;
    //Keyboard currentKeyboard;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          

       
    }

    private void FixedUpdate()
    {     
        rb.linearVelocityX = dir.x * speed;

        if(doJump == true)
        {
            Debug.Log("trying jump");
            if (grounded == true)
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }    
            doJump = false;
        }
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

    public void Jump(InputAction.CallbackContext context)
    {
        doJump = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
