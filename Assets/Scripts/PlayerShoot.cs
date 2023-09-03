using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform BulletSpawnpoint;
    public GameObject BulletPrefab;
    public AudioSource audioSource;
    public AudioClip zap;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)) {
            //print ("Down");
            Instantiate(BulletPrefab, BulletSpawnpoint.position,this.transform.rotation);
            audioSource.PlayOneShot(zap);
            

        } 
    
    }
}
