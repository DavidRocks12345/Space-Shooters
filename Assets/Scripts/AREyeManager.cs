using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;


public class AREyeManager : MonoBehaviour
{
    public static Vector3 LeftEyeLocation;
    public static Vector3 RightEyeLocation;
    [SerializeField] private GameObject leftEyePrefab;
    [SerializeField] private GameObject rightEyePrefab;

    private ARFace arFace;
    private GameObject leftEye, rightEye;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("OK!");
        arFace = GetComponent<ARFace>();
        ARFaceManager arFaceManager = FindObjectOfType<ARFaceManager>();
        
        if(arFaceManager != null && arFaceManager.subsystem.subsystemDescriptor.supportsEyeTracking)
        {
            arFace.updated += ARFaceUpdated;
        }
    }

    void Update(){

        if(arFace.leftEye != null){
            LeftEyeLocation = arFace.leftEye.position;
        }
        else{
            LeftEyeLocation = Vector3.zero;
        }
        if(arFace.rightEye != null){
            RightEyeLocation = arFace.rightEye.position;
        }
        else{
            RightEyeLocation = Vector3.zero;
        }

    }
  
    private void ARFaceUpdated(ARFaceUpdatedEventArgs obj)
    {
        if(arFace.leftEye != null && leftEye == null)
        {
            leftEye = Instantiate(leftEyePrefab, arFace.leftEye);
            leftEye.name = "LeftEye";
            leftEye.SetActive(false);
        }

        if (arFace.rightEye != null && rightEye == null)
        {
            rightEye = Instantiate(rightEyePrefab, arFace.rightEye);
            rightEye.name = "RightEye";
            rightEye.SetActive(false);
        }
        
        if(arFace.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking && ARSession.state > ARSessionState.Ready)
        {
            if(leftEye != null)
            {
                leftEye.SetActive(true);
            }
            if (rightEye != null)
            {
                rightEye.SetActive(true);
            }

        }
    }

    private void OnDisable()
    {
        arFace.updated -= ARFaceUpdated;
        leftEye.SetActive(false);
        rightEye.SetActive(false);
    }
}
