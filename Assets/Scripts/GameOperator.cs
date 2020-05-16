using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

//references to the start & game over pages
public class GameOperator : MonoBehaviour
{
    public static GameOperator Instance; //allow to be accessable from other scripts
    public GameObject Start;
    public GameObject GameOver;
    public Text ScoreText; //ref to UI text component that displays the player's score
    public Text GameOverText; // text displays when the player dies

    private int score = 0;
    private bool isGameOver = false;
    public int Score { get { return score; } }

   
    
    
    public enum PageState
    {
        None,
        Start,
        GameOver
    }

    void Awake() 
    {
        if (Instance == null)
        Instance = this;
    }

    void Update()
    {
        
    }

    //lets the game know when to switch the page to Start or Game Over 
    //and when to activate page
    public void SetPageState(PageState state)
    {
        switch (state) 
        {
            case PageState.None:
                isGameOver = false;
                Start.SetActive(false);
                GameOver.SetActive(false);
                break;
            case PageState.Start:
                isGameOver = false;
                Start.SetActive(true);
                GameOver.SetActive(false);
                break;
            case PageState.GameOver:
                isGameOver = true;
                Start.SetActive(false);
                GameOver.SetActive(true); 
                break; 
        }
    }
    //activated when replay button is hit
    public void ConfirmGameOver() 
    {
        
        SetPageState(PageState.Start);
        isGameOver = true;
        
        SetPageState(PageState.GameOver);
        GameOver.SetActive(true);
    }
   
    //activated when play button is hit
    public void StartGame() 
    {
        isGameOver = true;
        SetPageState(PageState.Start);
    }
}