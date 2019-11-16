using System;
using DefaultNamespace.ScreenShotPart;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.DrawingPart
{
    public class TextureInic:MonoBehaviour
    {
        public Image ImageScreenshot;

        public void Start()
        {
            if(GameObject.Find("PathfinderSphere"))
                Debug.Log("PF FINDED!");
        }


    }
}