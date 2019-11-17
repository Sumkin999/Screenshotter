using System.Collections;
using UnityEngine;
using System.IO;
using DefaultNamespace.DrawingPart;
using UnityEngine.UI;

namespace DefaultNamespace.ScreenShotPart
{
    public class ScreenShotCapture:MonoBehaviour
    {

        public TextureInic TextureInic;
        
        public SpriteRenderer DrawingSpriteRenderer;

        public Image ImageToCopy;
        public Sprite drawingSprite;
        public void Capture()
        {
            StartCoroutine(CaptureScreenshots());
        }
        public void Update()
        {
            
            /*if (Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine(CaptureScreenshots());
            }*/
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

            ImageToCopy.sprite = drawingSprite;

            bot = tex;
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


        private Texture2D bot;
        private Texture2D upt;
        
        public static Texture2D AlphaBlend( Texture2D aBottom, Texture2D aTop)
        {
           // aTop.Resize(aBottom.width, aBottom.height);
          // string path = "H:\\UnityProjects\\ScreenShots\\Assets\\FreeDraw\\Art\\ReadWriteEnabledImage.png";
         //  Texture2D tmp = LoadTexture(path);
               //Graphics.CopyTexture(aTop,)
            scale(aBottom,aTop.width,aTop.height);
            
            
            if (aBottom.width != aTop.width || aBottom.height != aTop.height)
                throw new System.InvalidOperationException("AlphaBlend only works with two equal sized images");
            var bData = aBottom.GetPixels();
            var tData = aTop.GetPixels();
            int count = bData.Length;
            var rData = new Color[count];
            for(int i = 0; i < count; i++)
            {
                Color B = bData[i];
                Color T = tData[i];
                float srcF = T.a;
                float destF = 1f - T.a;
                float alpha = srcF + destF * B.a;
                Color R = (T * srcF + B * B.a * destF)/alpha;
                R.a = alpha;
                rData[i] = R;
            }
            var res = new Texture2D(aTop.width, aTop.height);
            res.SetPixels(rData);
            res.Apply();
            return res;
        }

        public void MixTextures()
        {
            upt = drawingSprite.texture;

            Texture2D mixed = AlphaBlend(bot, upt);
            
            var bytes = mixed.EncodeToPNG();
            //Destroy(tex);

            string directoryName = "H:\\UnityProjects\\ScreenShots\\Screenshots\\Mixed.png";
            File.WriteAllBytes(directoryName, bytes);
        }
        
        
        
        
        
        
        public static Texture2D scaled(Texture2D src, int width, int height, FilterMode mode = FilterMode.Trilinear)
        {
            Rect texR = new Rect(0,0,width,height);
            _gpu_scale(src,width,height,mode);
               
            //Get rendered data back to a new texture
            Texture2D result = new Texture2D(width, height, TextureFormat.ARGB32, true);
            result.Resize(width, height);
            result.ReadPixels(texR,0,0,true);
            return result;                 
        }
        public static void scale(Texture2D tex, int width, int height, FilterMode mode = FilterMode.Trilinear)
        {
            Rect texR = new Rect(0,0,width,height);
            _gpu_scale(tex,width,height,mode);
               
            // Update new texture
            tex.Resize(width, height);
            tex.ReadPixels(texR,0,0,true);
            tex.Apply(true);        //Remove this if you hate us applying textures for you :)
        }
        
        static void _gpu_scale(Texture2D src, int width, int height, FilterMode fmode)
        {
            //We need the source texture in VRAM because we render with it
            src.filterMode = fmode;
            src.Apply(true);       
                               
            //Using RTT for best quality and performance. Thanks, Unity 5
            RenderTexture rtt = new RenderTexture(width, height, 32);
               
            //Set the RTT in order to render to it
            Graphics.SetRenderTarget(rtt);
               
            //Setup 2D matrix in range 0..1, so nobody needs to care about sized
            GL.LoadPixelMatrix(0,1,1,0);
               
            //Then clear & draw the texture to fill the entire RTT.
            GL.Clear(true,true,new Color(0,0,0,0));
            Graphics.DrawTexture(new Rect(0,0,1,1),src);
        }
        
        
        
        
        
    }
    
    
    
}