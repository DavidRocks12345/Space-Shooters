using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explodehelper : MonoBehaviour
{
    public GameObject explosion;
    public static Explodehelper exploder;

    void Awake(){
        exploder = this;
    
    }
    public void Explode(Vector3 location){
        Instantiate(explosion, location, Quaternion.identity);
    }
    
}
