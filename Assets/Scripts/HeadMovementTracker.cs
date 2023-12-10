using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARFaceManager))]
public class HeadMovementTracker : MonoBehaviour
{
    public GameObject objectToMove;

    private ARFaceManager arFaceManager;

    void Start()
    {
        arFaceManager = GetComponent<ARFaceManager>();

        // Register to the face updated event
        arFaceManager.facesChanged += OnFacesUpdated;
    }

    void OnFacesUpdated(ARFacesChangedEventArgs eventArgs)
    {
        if (objectToMove == null)
            return;

            foreach (var face in eventArgs.updated)
        {
         
            
                // Apply face's position and rotation to the object
                objectToMove.transform.localPosition = face.transform.localPosition;
                objectToMove.transform.localRotation = face.transform.localRotation;
                break;
            
        }
    }

    void OnDestroy()
    {
        // Unregister from the face updated event
        if (arFaceManager != null)
        {
            arFaceManager.facesChanged -= OnFacesUpdated;
        }
    }
}