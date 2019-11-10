using System.Collections;
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
                StartCoroutine(CaptureScreenshots());
            }
        }
        IEnumerator CaptureScreenshots()
        {
            yield return new WaitForEndOfFrame();
            
            
            Camera camera=Camera.main;

            string directoryName = "H:\\UnityProjects\\ScreenShots\\Screenshots\\";//checkSaveDirectory();
           // string fileName = directoryName + getFileName(id);
           string fileName = directoryName + "CUSTOM.png";//getFileName(id);

           
           /*var startX = (int)(settings.cutoutPosition.x - settings.cutoutSize.x / 2f);
           var startY = (int)((Screen.height - settings.cutoutPosition.y) - settings.cutoutSize.y / 2f);
           var width = (int)settings.cutoutSize.x;
           var height = (int)settings.cutoutSize.y;*/
            var startX = (int)(0);
            var startY = (int)(0);
            var width = (int) (Screen.width);
            var height = (int)(Screen.height);
            var tex = new Texture2D(width, height, TextureFormat.RGB24, false);

            tex.ReadPixels(new Rect(startX, startY, width, height), 0, 0);
            tex.Apply();

            var bytes = tex.EncodeToPNG();
            Destroy(tex);

            File.WriteAllBytes(fileName, bytes);
            
            
            
            
            
            
            
            
           // string directoryName = checkSaveDirectory();
            

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