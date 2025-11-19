using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class RoundManager : MonoBehaviour
{

    public int p1wins;
    public int p2wins;

    public GameObject p1;
    public GameObject p2;

    public GameObject p1Start;
    public GameObject p2Start;

    public GameObject[] p1WinUI;
    public GameObject[] p2WinUI;

    public Color RoundColour;
    public Color wonRoundColour;

    public GameObject winScreen;
    public Camera cam;

    public MenuScript ms;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MenuScript.localTimeScale = 1;
        MenuScript.isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RoundOver(int winner)
    {
        //records round winner
        if (winner == 1)
        {
            p1wins++;
        }
        if (winner == 2)
        {
            p2wins++;         
        }
        //winner = 0;
        //check for if won enough rounds here
        StartCoroutine(ScreenFreeze());
        
    }

    IEnumerator ScreenFreeze()
    {
        for (int i = 0; i < p1wins; i++)
        {
            p1WinUI[i].gameObject.GetComponent<Image>().color = wonRoundColour;
        }
        for (int i = 0; i < p2wins; i++)
        {
            p2WinUI[i].gameObject.GetComponent<Image>().color = wonRoundColour;
        }
        MenuScript.localTimeScale = 0;
        yield return new WaitForSecondsRealtime(0.65f);
        MenuScript.localTimeScale = ms.gameSpeed;
        RoundReset();
    }
    public void RoundReset()
    {
       //resets the round

        //win screen
       if(p1wins >= 5)
       {
            Debug.Log("p1 wins");
            winScreen.SetActive(true);
            p2.SetActive(false);
            cam.transform.position = new Vector3(p1.transform.position.x, p1.transform.position.y, -10);
            cam.orthographicSize = 2;          
            MenuScript.localTimeScale = 0;
            p1wins = 0;
            p2wins = 0;
            
       }
       else if(p2wins >= 5)
       {
            Debug.Log("p2 wins");
            winScreen.SetActive(true);
            p1.SetActive(false);
            cam.transform.position = new Vector3(p2.transform.position.x,p2.transform.position.y,-10);
            cam.orthographicSize = 2;
            MenuScript.localTimeScale = 0;
            p1wins = 0;
            p2wins = 0;
            
        }
       else
        {
            p1.transform.position = p1Start.transform.position;
            p2.transform.position = p2Start.transform.position;
        }
                     
    }
    public static void GameReset()
    {
        MenuScript.localTimeScale = 1;
        SceneManager.LoadScene("Main");
    }
}
