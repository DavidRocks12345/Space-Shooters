using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Rigidbody myRigidbody;
    public string enemyName;
    //static Transform playerLocation;
    public AudioSource source;
    public AudioClip clip;
    Vector3 EndingLocation;
    void Awake(){
        /*float endx = Mathf.Clamp(transform.position.x, -5, 5);
        float endy = Mathf.Clamp(transform.position.y, -2, 2);*/
        EndingLocation = new Vector3(transform.position.x, -100,0);
        transform.LookAt(EndingLocation);
        transform.up=new Vector3(0,0,1);
    }
    void Start(){
        source = GetComponent<AudioSource>();
        /*if(playerLocation == null)
        {
            playerLocation = new GameObject("CENTER POS").transform;
        }*/
        
    }
    void Update(){
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.zero), 0.1f);
        //transform.LookAt(playerLocation);
       /*

        Vector3 moveDirection = Vector3.zero - this.transform.position;
        myRigidbody.AddForce(moveDirection.normalized * enemySpeed);
        */
        if(Vector3.Distance(EndingLocation, this.transform.position)>0.05f){
            transform.position=Vector3.MoveTowards(transform.position, EndingLocation, speed * Time.deltaTime);
        }
        else{
            Destroy(this.gameObject);
        }
    }
    
    void switchScene(){
        SceneManager.LoadScene(2);

    }
    
    void OnCollisionEnter(Collision collision){
    if(collision.gameObject.tag == "Player"){
        Destroy(collision.gameObject);
        source.clip = clip;
        source.Play();
        //switchScene();
        SaveHighScore.SaveToJson();
        Invoke("switchScene", 1.25f);
    }

}
}
