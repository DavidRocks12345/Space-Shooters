using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    float minTime = 0.2f;
    float maxTime = 2f;
    Vector2 leftCOrner = new Vector2(-20,20);
    Vector2 rightCOrner = new Vector2(20,20); 
    // Start is called before the first frame update
    void Start()
    {
        MakeEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MakeEnemy(){
        Vector3 pos = new Vector3(Random.Range(leftCOrner.x, rightCOrner.x),Random.Range(leftCOrner.y, rightCOrner.y),0);
        Instantiate(enemyPrefab, pos, Quaternion.identity);
        Invoke("MakeEnemy", Random.Range(minTime, maxTime));
    }
}
