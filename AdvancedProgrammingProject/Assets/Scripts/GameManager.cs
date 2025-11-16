using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements.InputSystem;

public class GameManager
{
    public static GameManager Instance;
    public enum GameStates
    {
        Play,
        Paused
    }
    public GameStates state;
    PlayerInput playerInput;

    public void ChangeGameState(GameStates newState)
    {
        state = newState;

        switch (newState)
        {
            
            case GameStates.Play:
                playerInput.SwitchCurrentActionMap("Player");
                break;
            case GameStates.Paused:
                playerInput.SwitchCurrentActionMap("UI");
                break;

        }
    }
}

