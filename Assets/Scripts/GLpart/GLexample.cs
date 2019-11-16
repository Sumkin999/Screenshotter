using UnityEngine;

namespace DefaultNamespace.GLpart
{
    public class GLexample:MonoBehaviour
    {
        public Material mat;
        void OnPostRender() 
        {
            if (!mat) 
            {
                Debug.LogError("Please Assign a material on the inspector");
                return;
            }
            GL.PushMatrix();
            mat.SetPass(0);
            GL.LoadOrtho();
            GL.Begin(GL.QUADS);
            GL.TexCoord2(0, 0);
            GL.Vertex3(0.25F, 0.25F, 0);
            GL.TexCoord2(0, 1);
            GL.Vertex3(0.25F, 0.75F, 0);
            GL.TexCoord2(1, 1);
            GL.Vertex3(0.75F, 0.75F, 0);
            GL.TexCoord2(1, 0);
            GL.Vertex3(0.75F, 0.25F, 0);
            GL.End();
            GL.PopMatrix();
        }
    }
}