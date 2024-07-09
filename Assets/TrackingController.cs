using UnityEngine;
using UnityEngine.XR.ARSubsystems;

namespace DefaultNamespace
{
    public class TrackingController : MonoBehaviour
    {
        private XRReferenceImageLibrary _library;
        
        public TrackingController()
        {
            
        }

        public void LoadToLibrary(XRReferenceImageLibrary imageLibrary)
        { 
            /*Texture2D imageTexture = Resources.Load<Texture2D>("Object0");
            var aaa = imageLibrary[0].texture;
            aaa = imageTexture;*/
        }
    }
}