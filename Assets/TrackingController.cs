using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace DefaultNamespace
{
    public class TrackingController : MonoBehaviour
    {
        public TrackingController()
        {
            
        }

        public void LoadToLibrary( ARTrackedImageManager arTrackedImageManager, Texture2D imageToAdd)
        { 
            if (!(ARSession.state == ARSessionState.SessionInitializing || ARSession.state == ARSessionState.SessionTracking))
                return;

            if (arTrackedImageManager.referenceLibrary is MutableRuntimeReferenceImageLibrary mutableLibrary)
            {
                mutableLibrary.ScheduleAddImageWithValidationJob(
                    imageToAdd,
                    "Object0",
                    0.5f /* 50 cm */);
            }
        }
    }
}