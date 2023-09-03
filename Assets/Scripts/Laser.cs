using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public AudioSource audioSource;
    public Vector3 direction;
    public Rigidbody rb;
    public float forceAmount;
    public float lifespan;
    // Start is called before the first frame update
    void Start()
    {
        direction = transform.up;
        rb=GetComponent<Rigidbody>();
        Destroy(this.gameObject, lifespan);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce( direction * forceAmount, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other){
        
       if (other.tag=="Enemy")
       {
            UIHandler.Score += 10;
            audioSource.Play();
            Destroy(other.gameObject);
            Explodehelper.exploder.Explode(this.transform.position);
            Destroy(this.gameObject, 1f);
            
       
            

       }


    }
    
}
