using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;


//this script is the game's point system
public class ScoreScript : MonoBehaviour
{

    public int pointValue = 0;

    public Text gamescore;

    // Start is called before the first frame update
    void Start()
    {
        gamescore.text = "Score: " + pointValue.ToString();  //adds points
        
    }

    // Update is called once per frame
    public void Update()
    {
        gamescore.text = "Score: " + pointValue.ToString();  //adds points
    }
}
