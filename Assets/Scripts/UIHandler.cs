using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{

    public GameObject player; // store our player object in here.
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text creditText;
    public float timer;
    public static int Score;

    public static int TotalScore;

    // Start is called before the first frame update
    void Start()
    { 
        scoreText.text = "hello";
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        timerText.text = timer.ToString();
        scoreText.text = TotalScore.ToString();
        creditText.text = "Credits: "+PlayerManagement.player.credits.ToString();
    }
}
