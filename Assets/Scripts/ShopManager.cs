using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour

{
    
    public GameObject startingShip;

    public GameObject redShip;
    
    public TMP_Text redShipText;

    public GameObject copperShip;

    public TMP_Text copperShipText;

    public bool redShipPurchased=false;

    public bool copperShipPurchased=false;

    //audio variables//
    public AudioSource audioSource;

    public AudioClip unlockSound;

    public AudioClip equipSound;

    public AudioClip brokeSound;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RedShipUpgrade()
    {
        if(PlayerManagement.player.credits>=250){
            startingShip.SetActive(false);
            copperShip.SetActive(false);
            redShip.SetActive(true);
            PlayerManagement.player.creditCounter-=250;
            Debug.Log("Successfully Upgraded!");
            redShipPurchased = true;
            redShipText.text = "EQUIP";
            PlayerManagement.player.equippedShip=ShipType.RedShip;
            audioSource.PlayOneShot(unlockSound);
        }
        else if (redShipPurchased == true){
            startingShip.SetActive(false);
            copperShip.SetActive(false);
            redShip.SetActive(true);
            PlayerManagement.player.equippedShip=ShipType.RedShip;
            audioSource.PlayOneShot(equipSound);
        }
        else 
        {
            Debug.Log("You don't have enough credits!");
            audioSource.PlayOneShot(brokeSound);
        }
    }
    public void CopperShipUpgrade()
    {
        if(PlayerManagement.player.credits>=500){
            startingShip.SetActive(false);
            redShip.SetActive(false);
            copperShip.SetActive(true);
            PlayerManagement.player.creditCounter-=500;
            Debug.Log("Successfully Upgraded!");
            copperShipPurchased = true;
            copperShipText.text = "EQUIP";
            PlayerManagement.player.equippedShip=ShipType.CopperShip;
            audioSource.PlayOneShot(unlockSound);
        }
        else if (copperShipPurchased == true){
            startingShip.SetActive(false);
            redShip.SetActive(false);
            copperShip.SetActive(true);
            PlayerManagement.player.equippedShip=ShipType.CopperShip;
            audioSource.PlayOneShot(equipSound);
        }
        else 
        {
            Debug.Log("You don't have enough credits!");
            audioSource.PlayOneShot(brokeSound);
        }
    }
    public void EquipStarterShip()
    {
        startingShip.SetActive(true);
        redShip.SetActive(false);
        copperShip.SetActive(false);
        PlayerManagement.player.equippedShip=ShipType.StarterShip;
        audioSource.PlayOneShot(equipSound);
    }
}
