using UnityEngine;
using System.IO;
namespace DefaultNamespace.ScreenShotPart
{
    public class ScreenShotCapture:MonoBehaviour
    {
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                CaptureScreenshots();
            }
        }
        public void CaptureScreenshots()
        {
            Camera camera=Camera.main;

            string directoryName = checkSaveDirectory();
            string fileName = directoryName + "CUSTOM.png";//getFileName(id);

            ScreenCapture.CaptureScreenshot(fileName, 1);
            
            Debug.Log("Screenshot saved to: " + fileName);
            

            //postCapture();
        }
        
        string checkSaveDirectory()
        {
            string directoryPath = getSaveDirectory();

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            return directoryPath;
        }
        public string getSaveDirectory()
        {
            string pickDirectory = "Screenshots";
            
            return Directory.GetCurrentDirectory() + "/" + pickDirectory + "/";
            
        }
    }
}