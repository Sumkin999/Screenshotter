using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.DrawingPart
{
    public class BoundsColliderGet:MonoBehaviour
    {
        private Collider2D _collider2D;


        public Image Image;

        public Image ImageDraw;

        private void Start()
        {
           
        }

        void Update()
        {
            if (_collider2D == null)
            {
                _collider2D = GetComponent<Collider2D>();
            }
            if(_collider2D==null)
                return;
            Bounds bounds = _collider2D.bounds;
            Debug.Log(bounds.ToString());
            
            Vector3 origin = Camera.main.WorldToScreenPoint(new Vector3(bounds.min.x, bounds.max.y, 0f));
            Vector3 extent = Camera.main.WorldToScreenPoint(new Vector3(bounds.max.x, bounds.min.y, 0f));
            
            
            
            Debug.Log(origin+"    "+extent);
            
            Image.rectTransform.sizeDelta=new Vector2(Mathf.Abs(extent.x-origin.x),
                Mathf.Abs(origin.y-extent.y));
            
            ImageDraw.rectTransform.sizeDelta=new Vector2(Mathf.Abs(extent.x-origin.x),
                Mathf.Abs(origin.y-extent.y));
            /*foreach (var VARIABLE in bounds.ToString())
            {
                Debug.Log(VARIABLE);
            }*/
        }
    }
}