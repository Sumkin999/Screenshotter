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


        private float timer = -0.25f;
        private bool toChange = false;
        public void Update()
        {
            timer -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.A))
            {
                //PrepareCamera();
                //SetCanvasDepth();
                ScreenShotCapture.Capture();


                timer = .25f;
                toChange = true;
            }

            if (timer < 0 && toChange)
            {
                toChange = false;
                PrepareCamera();
                SetCanvasDepth();
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



        private bool isCameraPerspective = false;
        public void PrepareCamera()
        {
            Camera curCamera=Camera.main;
            if (curCamera==null)
            {
                return;
            }
            if (!curCamera.orthographic)
            {
                isCameraPerspective = true;
                curCamera.orthographic = true;
            }
            /*Camera tempmaincamera=Camera.main;
            SceneCamera.gameObject.SetActive(true);

            if (Camera.current!=SceneCamera)
            {
                Debug.Log("Need Change Camera!");
                tempmaincamera.gameObject.SetActive(false);
            }*/
        }
    }
}