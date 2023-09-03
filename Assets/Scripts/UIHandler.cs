using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{

    public GameObject player; // store our player object in here.
    public TMP_Text scoreText;
    public TMP_Text timerText;
    private float timer;
    public static int Score;

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
        scoreText.text = Score.ToString();
    }
}
