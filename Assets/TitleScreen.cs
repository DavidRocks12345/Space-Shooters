using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleScreen : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        BeginGame();
    }
    void BeginGame(){
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("Enter was pressed!");
            SceneManager.LoadScene(1);
        }
    }   
}
