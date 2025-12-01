using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static float gameSpeed;
    private void Start()
    {
        gameSpeed = 1;
        DontDestroyOnLoad(gameObject);
    }
    
}
