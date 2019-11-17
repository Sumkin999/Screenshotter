using System.Collections;
using System.IO;
using UnityEngine;

namespace DefaultNamespace.DrawingPart
{
    public class CaptureScreenshot:MonoBehaviour
    {
        public void Capture()
        {
            StartCoroutine(CaptureScreenshots());
        }
        
        IEnumerator CaptureScreenshots()
        {
            yield return new WaitForEndOfFrame();
            
            
            Camera camera=Camera.main;

            string directoryName = "H:\\UnityProjects\\ScreenShots\\Screenshots\\";//checkSaveDirectory();
           // string fileName = directoryName + getFileName(id);
           string fileName = directoryName + "CUSTOM.png";//getFileName(id);


            var startX = (int)(0);
            var startY = (int)(0);
            var width = (int) (Screen.width);
            var height = (int)(Screen.height);
            Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

            tex.ReadPixels(new Rect(startX, startY, width, height), 0, 0);
            tex.Apply();
            
          //!!!!!!!!!!!!!
            //TextureInic.ImageScreenshot.sprite=

            var bytes = tex.EncodeToPNG();
            //Destroy(tex);

            File.WriteAllBytes(fileName, bytes);
            
            
            
            
            
            
            
            
           // string directoryName = checkSaveDirectory();
            

           ScreenCapture.CaptureScreenshot(fileName, 1);
            
            Debug.Log("Screenshot saved to: " + fileName);

            /*Sprite sp=LoadNewSprite(fileName);
            TextureInic.ImageScreenshot.sprite = sp;

            ImageToCopy.sprite = drawingSprite;

            bot = tex;
            
            */
            
            
            
            
            /* Texture2D t= new Texture2D(width, height, TextureFormat.RGBA32, false);
             t.ReadPixels(new Rect(startX, startY, width, height), 0, 0);
             t.Apply();
             var bytes2 = tex.EncodeToPNG();
             //Destroy(tex);
             fileName += "temp";
             File.WriteAllBytes(fileName, bytes2);
             Sprite sp2=LoadNewSprite(fileName);
            DrawingSpriteRenderer.sprite = sp2;*/
            //postCapture();
        }
    }
}