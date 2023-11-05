using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement : MonoBehaviour

{
    public static PlayerManagement player;

    public ShipType equippedShip;
    public int playerHealth = 100;
    public float scoreOvertime = 0;
    public float creditCounter = 0;
    public int credits = 0;


    
    void Awake()
    {
        if (player == null)
            player = this;
        else if(player != null)
            Destroy(this);
    }
     
    public void TakeDamage(int damage)
    {
        playerHealth = playerHealth - damage;
        Debug.Log("Player Took Damage. Total Health: " + playerHealth);
        
    }
    void Start()
    {
        equippedShip = ShipType.StarterShip;
    }

    // Update is called once per frame
    void Update()
    {
        IncreaseScore();
        IncreaseCredits();
    }
    void IncreaseScore()
    {
        
        scoreOvertime+=Time.deltaTime*5;
        UIHandler.TotalScore=(int)scoreOvertime+UIHandler.Score;


    }
    void IncreaseCredits()
    {
        creditCounter += Time.deltaTime;
        credits=(int)creditCounter;

    }
    
}
