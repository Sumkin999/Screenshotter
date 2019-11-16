using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.ScreenShotPart;
using UnityEngine;

namespace DefaultNamespace.ScreenshotControlPart
{
    
    public class CanvasController:MonoBehaviour
    {
        public ScreenShotCapture ScreenShotCapture;
        public Canvas MainCanvas;
        public Camera SceneCamera;

        
        
        List<Canvas>otherCanvases=new List<Canvas>();


        
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                PrepareCamera();
                SetCanvasDepth();
                ScreenShotCapture.Capture();
            }
        }
        
        public void SetCanvasDepth()
        {
            otherCanvases = Object.FindObjectsOfType<Canvas>().ToList();
            
            MainCanvas.gameObject.SetActive(true);

            int depth = 0;
            
            foreach (var VARIABLE in otherCanvases)
            {
                if (VARIABLE!=MainCanvas && depth<=VARIABLE.sortingOrder)
                {
                    depth = VARIABLE.sortingOrder;
                }
            }

            depth++;
            MainCanvas.sortingOrder = depth;
        }



        public void PrepareCamera()
        {
            Camera tempmaincamera=Camera.main;
            SceneCamera.gameObject.SetActive(true);

           /* if (Camera.current!=SceneCamera)
            {
                Debug.Log("Need Change Camera!");
                tempmaincamera.gameObject.SetActive(false);
            }*/
        }
    }
}