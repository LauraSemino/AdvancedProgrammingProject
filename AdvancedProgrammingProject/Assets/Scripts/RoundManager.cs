using System;
using System.Collections;
using TMPro;
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

    public float roundTimer;
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI startText;

    public MenuScript ms;

    public GameObject[] stages;

    public static bool canPause;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switch (GameSettings.stage)
        {

            case "ALLEY":
                Instantiate(stages[0]);
                break;
            case "PLACEHOLDER":
                Instantiate(stages[1]);
                break;
        }
        //canPause = true;
        MenuScript.localTimeScale = 1;
        MenuScript.isPaused = false;
        roundTimer = 99;
        StartCoroutine(Countdown());

    }

    // Update is called once per frame
    void Update()
    {
        roundTimer -= (Time.deltaTime * MenuScript.localTimeScale);

        int t = Mathf.FloorToInt(roundTimer);
        roundText.text = t.ToString();
        if(t <= 0)
        {
            RoundOver(0);
        }
    }

    public void RoundOver(int winner)
    {
        canPause = false;
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
        MenuScript.localTimeScale = GameSettings.gameSpeed;
        RoundReset();
    }

    IEnumerator Countdown()
    {
        canPause = false;
        startText.gameObject.SetActive(true);
        yield return new WaitForFixedUpdate();
        startText.text = "Ready";
        MenuScript.localTimeScale = 0;
        yield return new WaitForSecondsRealtime(0.65f);
        startText.text = "Ready.";
        yield return new WaitForSecondsRealtime(0.65f);
        startText.text = "Ready..";
        yield return new WaitForSecondsRealtime(0.65f);
        startText.text = "Ready...";
        yield return new WaitForSecondsRealtime(1f);
        startText.text = "GO";
        MenuScript.localTimeScale = GameSettings.gameSpeed;
        yield return new WaitForSecondsRealtime(0.5f);
        startText.enabled = false;
        canPause = true;
    }
    public void RoundReset()
    {
       //resets the round

        //win screen
       if(p1wins >= 5)
       {
           // Debug.Log("p1 wins");
            winScreen.SetActive(true);
            p2.SetActive(false);
            cam.transform.position = new Vector3(p1.transform.position.x, p1.transform.position.y, -10);
            cam.orthographicSize = 2;
            MenuScript.isPaused = true;
            ms.curMenu = "Win";
            MenuScript.localTimeScale = 0;
            
            
       }
       else if(p2wins >= 5)
       {
            //Debug.Log("p2 wins");
            winScreen.SetActive(true);
            p1.SetActive(false);
            cam.transform.position = new Vector3(p2.transform.position.x,p2.transform.position.y,-10);
            cam.orthographicSize = 2;
            MenuScript.isPaused = true;
            ms.curMenu = "Win";
            MenuScript.localTimeScale = 0;
           
            
        }
       else
        {            
            roundTimer = 99;
            p1.transform.position = p1Start.transform.position;
            p2.transform.position = p2Start.transform.position;
            canPause = true;
        }
                     
    }
    public static void GameReset()
    { 
        MenuScript.localTimeScale = 1;
        SceneManager.LoadScene("Main");
    }
    public static void QuitToMenu()
    {
        MenuScript.localTimeScale = 1;
        SceneManager.LoadScene("Title Screen");
    }
}
