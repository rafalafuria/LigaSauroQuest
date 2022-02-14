using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;
    public static ScoreScript instance;

    
    void Start()
    {
        //scoreValue = 0; 
    }

    void Awake()
    {
        score = GetComponent<Text>();
        //scoreValue = 0;
    }

    // Start is called before the first frame update
    void Update()
    {
        score.text = "Score: " + scoreValue;
    }

    // Add to score manager
    public void ResetScore()
    {
        scoreValue = 0;
        PlayerPrefs.SetInt("Score: ", scoreValue);
    }

}
