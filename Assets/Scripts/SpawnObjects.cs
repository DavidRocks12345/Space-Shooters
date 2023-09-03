using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    // THIS IS A COMMENT!
    /*
    THIS IS A MULTILINE COMMENT!!!
    int playerLives;
    string playerNames= "David";
    float playerSpeed= 5.0f;
    char playerRank= 'a';
    bool isAlive= true;
    
    */ 
    public GameObject shape;
    public MeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeShapeColor(){
        Color ourNewColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f,1f));
        shape.GetComponent<MeshRenderer>().material.color = ourNewColor;
    }
}
