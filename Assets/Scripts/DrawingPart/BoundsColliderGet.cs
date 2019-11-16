using System;
using UnityEngine;

namespace DefaultNamespace.DrawingPart
{
    public class BoundsColliderGet:MonoBehaviour
    {
        private Collider2D _collider2D;

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
            /*foreach (var VARIABLE in bounds.ToString())
            {
                Debug.Log(VARIABLE);
            }*/
        }
    }
}