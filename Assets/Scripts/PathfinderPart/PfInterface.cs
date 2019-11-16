using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace.PathfinderPart
{
    public class PfInterface:MonoBehaviour
    {
        public void Clicked()
        {
            Debug.Log("Clicked!!! "+SceneManager.GetActiveScene().name);
        }
    }
}