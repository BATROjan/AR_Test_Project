using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class InputController : MonoBehaviour
{
    [SerializeField] [Tooltip("Instantiate this prefab on a plane")] private GameObject pref;
    private GameObject spawnObject;

    private ARRaycastManager ARRaycastManager;
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();
    void Start()
    {
        ARRaycastManager = GetComponent<ARRaycastManager>();
    }
    
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (ARRaycastManager.Raycast(Input.GetTouch(0).position, _hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = _hits[0].pose;
                if (!spawnObject)
                {
                    spawnObject = Instantiate(pref, hitPose.position, hitPose.rotation);
                }
                else
                {
                    spawnObject.transform.position = hitPose.position;
                    spawnObject.transform.rotation = hitPose.rotation;
                }
            }
        }  
    }
}
