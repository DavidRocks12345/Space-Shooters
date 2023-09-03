using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenseEnemy : MonoBehaviour
{
    public GameObject enemy; 
    public float whoCares;
    private void OnTriggerEnter(Collider other){
        
       if (other.tag=="Enemy")
       {
        Enemy thisEnemy = other.gameObject.GetComponent<Enemy>();
        // listen to me
       // print(thisEnemy.enemyName);
       /*
       kpop is cringe
       pineapple belongs on pizza
       */
       Destroy(other.gameObject);

       Vector3 newPosition= new Vector3(Random.Range(-10f,10f),Random.Range(-10f,10f),0);
       Instantiate(enemy, newPosition, Quaternion.identity);
       
       UIHandler.Score += 10;

       }


    }   

}
