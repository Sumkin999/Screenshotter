using UnityEngine;

namespace DefaultNamespace.DrawingPart
{
    public class TextureInic:MonoBehaviour
    {
        public Texture aTexture;
        void OnGUI()
        {
            if (Event.current.type.Equals(EventType.Repaint))
            {
                Graphics.DrawTexture(new Rect(500, 200, 100, 100), aTexture);
            }
        }
    }
}