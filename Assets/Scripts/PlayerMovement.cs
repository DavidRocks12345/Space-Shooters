using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 turn;
    public float speed = 10f;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    { 
       // PlayerRotate();
       ChangePlayerPosition();
    } 
    void PlayerRotate()
    {
        Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + -90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void ChangePlayerPosition()
    {
#if UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
        Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        direction = new Vector3(direction.x, direction.y, 0);
        // FIX THIS IN THE FUTURE!!!
    
#else
        Vector3 direction = Vector3.Lerp(AREyeManager.LeftEyeLocation, AREyeManager.RightEyeLocation, 0.5f);
        direction = new Vector3(direction.x, direction.y, 0);
        
#endif
        if(Vector2.Distance(transform.position, direction)<=0.25){
            return;
        }
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, direction, step);
    }
}
