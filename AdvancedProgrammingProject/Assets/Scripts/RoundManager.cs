using System.Collections;
using UnityEngine;
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        winner = 0;
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
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.65f);
        Time.timeScale = 1;
        RoundReset();
    }
    public void RoundReset()
    {
       //resets the round
       if(p1wins >= 5)
       {
            Debug.Log("p1 wins");
       }
       if(p2wins >= 5)
       {
            Debug.Log("p2 wins");
       }
       p1.transform.position = p1Start.transform.position;
       p2.transform.position = p2Start.transform.position;

       
        
    }

}
