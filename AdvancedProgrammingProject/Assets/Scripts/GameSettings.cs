
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static float gameSpeed;
    public static string stage;
    
    private void Start()
    {
        gameSpeed = 1;
        stage = "ALLEY";
        DontDestroyOnLoad(gameObject);
    }
    
}
