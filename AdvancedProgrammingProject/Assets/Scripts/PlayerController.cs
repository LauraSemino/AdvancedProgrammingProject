using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int pNum;
    public Rigidbody2D rb;

    public float speed;
    public float maxSpeed;
    public float jumpForce;

    public Vector2 dir;
    public bool doJump;
    public bool grounded;

    public RoundManager roundManager;
    private InputActionAsset actionAsset;
    public PlayerInput pi;

    public InputActionMap aPlayer;
    public InputActionMap aUI;
     
    //public MenuScript menuScript;
    //PlayerController controls;
    //Gamepad currentGamepad;
    //Keyboard currentKeyboard;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        actionAsset = pi.actions;
        aPlayer = actionAsset.FindActionMap("Player");
        aUI = actionAsset.FindActionMap("UI");

        aPlayer.Disable();
        aUI.Disable();
        //pi.actions
        //GetComponent<PlayerInput>().actions.FindActionMap("UI").Disable();
        //GetComponent<PlayerInput>().actions.FindActionMap("Player").Disable();
        Physics2D.simulationMode = SimulationMode2D.Script;
    }

    // Update is called once per frame
    void Update()
    {
        //pausing stopping rigidbodies
        Physics2D.Simulate(MenuScript.deltaTime);

        //changes the control scheme between gameplay and UI
        if (MenuScript.isPaused == true)
        {
            aPlayer.Disable();
            aUI.Enable();

        }
        if (MenuScript.isPaused == false)
        {
            aPlayer.Enable();
            aUI.Disable();
        }
        //Debug.Log(GetComponent<PlayerInput>().currentActionMap);

    }


    private void FixedUpdate()
    {

        if (grounded)
            {
                //ground movement is full accel
                rb.linearVelocityX += dir.x * speed;
            }
            else
            {
                //air movement has a slower accel
                rb.linearVelocityX += dir.x * (speed / 5);
            }

            //allow the player to do a break to stop momentum
            if (dir.y <= -0.5f && grounded == true)
            {
                rb.linearVelocityX = 0f;
            }

            //caps speed
            if (rb.linearVelocityX >= maxSpeed)
            {
                rb.linearVelocityX = maxSpeed;
            }
            if (rb.linearVelocityX <= -maxSpeed)
            {
                rb.linearVelocityX = -maxSpeed;
            }

            if (doJump == true)
            {
                //Debug.Log("trying jump");
                if (grounded == true)
                {
                    rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                }
                doJump = false;
            }
        
       
    }

    public void Move(InputAction.CallbackContext context)
    {
       
           //Debug.Log(context.control);


            Vector2 inputVector = context.ReadValue<Vector2>();
            dir = inputVector;
        
        //this is all the old way i made it work, in case i need it for some reason
        //InputControl control = context.control;
        /*  if (control.device == Gamepad.current)
          {
              Gamepad gamepad = (Gamepad)control.device;
              dir = gamepad.leftStick.ReadValue();
          }
          else if (control.device == Keyboard.current)
          {
              Keyboard gamepad = (Keyboard)control.device;
              dir = new Vector2(gamepad.dKey.ReadValue() - gamepad.aKey.ReadValue(), 0);
          }*/

    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (MenuScript.isPaused == false)
        {
            //makes sure the jump only happens when held down
            if (context.performed)
            {
                doJump = true;
            }
        }
        
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (rb.linearVelocityY < collision.GetComponent<Rigidbody2D>().linearVelocityY && collision.gameObject.CompareTag("Player"))
        {
            roundManager.RoundOver(pNum);
        }
        
    }

}
