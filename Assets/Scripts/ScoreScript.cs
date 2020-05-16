using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{


    public static int pointValue = 0;
    Text gamescore;
    
    
    // Start is called before the first frame update
    void Start()
    {
        gamescore = GetComponent<Text> ();
    }

    // Update is called once per frame
    public void Update()
    {
        gamescore.text = "Score: " + pointValue;
    }


}
