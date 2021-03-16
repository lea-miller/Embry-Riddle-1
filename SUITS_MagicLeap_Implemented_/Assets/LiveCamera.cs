using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MagicLeap;
using MagicLeapTools;
using UnityEngine.XR.MagicLeap;
using UnityEngine.UI;


public class LiveCamera : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject canvas;
    private Texture2D cameraFrameTexture;
    public RawImage displayImage;
    //private MLCamera cam;
    private GameObject screen;
    private bool _isCameraConnected = false;

    void Start()
    {
        displayImage = GetComponent<RawImage>();
        displayImage.enabled = false;
        

    }


    
    // Update is called once per frame
    void Update()
    {
        
        
    }

    
    public void startFeed()
    {
        EnableMLCamera();
        Texture2D feed = MLCamera.StartPreview();
        displayImage.texture = feed;
    }

    public void stopFeed()
    {
        DisableMLCamera();
    }

    /// <summary>
    /// Connects the MLCamera component and instantiates a new instance
    /// if it was never created.
    /// </summary>
    private void EnableMLCamera()
        {
            
            
            MLResult result = MLCamera.Start();
            if (result.IsOk)
            {
                result = MLCamera.Connect();
                _isCameraConnected = true;
            }
            else
            {
                Debug.LogErrorFormat("Error: ImageCaptureExample failed starting MLCamera, disabling script. Reason: {0}", result);
                enabled = false;
                return;
            }
            
            
        }

        /// <summary>
        /// Disconnects the MLCamera if it was ever created or connected.
        /// </summary>
        private void DisableMLCamera()
        {
            
            if (MLCamera.IsStarted)
            {
                MLCamera.Disconnect();
                // Explicitly set to false here as the disconnect was attempted.
                _isCameraConnected = false;
                MLCamera.Stop();
            }
            
           
        }
}
