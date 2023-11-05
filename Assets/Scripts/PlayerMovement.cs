using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 turn;
    public float speed;
    public int shields;
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
       CheckShipType();
       ChangePlayerPosition();
    } 
    void CheckShipType()
    {
        if(PlayerManagement.player.equippedShip==ShipType.StarterShip){
            speed=4f;
        }
        if(PlayerManagement.player.equippedShip==ShipType.RedShip){
            speed=5f;
        }
        if(PlayerManagement.player.equippedShip==ShipType.CopperShip){
            speed=6f;
        }
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
       
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        Debug.Log(targetPosition);
        transform.position = Vector2.Lerp(transform.position, targetPosition, speed*Time.deltaTime);
    }
}
