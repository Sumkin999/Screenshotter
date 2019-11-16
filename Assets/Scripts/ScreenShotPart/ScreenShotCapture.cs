using System.Collections;
using UnityEngine;
using System.IO;
using DefaultNamespace.DrawingPart;

namespace DefaultNamespace.ScreenShotPart
{
    public class ScreenShotCapture:MonoBehaviour
    {

        public TextureInic TextureInic;
        
        public SpriteRenderer DrawingSpriteRenderer;


        public void Capture()
        {
            StartCoroutine(CaptureScreenshots());
        }
        /*public void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine(CaptureScreenshots());
            }
        }*/
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

            Sprite sp=LoadNewSprite(fileName);
            TextureInic.ImageScreenshot.sprite = sp;
            
            
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
        
        
        
        
        
        
        public Texture2D LoadTexture(string FilePath) {
 
            // Load a PNG or JPG file from disk to a Texture2D
            // Returns null if load fails
 
            Texture2D Tex2D;
            byte[] FileData;
 
            if (File.Exists(FilePath)){
                FileData = File.ReadAllBytes(FilePath);
                Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
                if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
                    return Tex2D;                 // If data = readable -> return texture
            }  
            return null;                     // Return null if load failed
        }
        
        public Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f) {
   
            // Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference
     
           // Sprite NewSprite = new Sprite();
            Texture2D SpriteTexture = LoadTexture(FilePath);
            Sprite NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height),new Vector2(0,0), PixelsPerUnit);
 
            return NewSprite;
        }
    }
}