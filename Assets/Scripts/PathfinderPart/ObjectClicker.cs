using UnityEngine;

namespace DefaultNamespace.PathfinderPart
{
    public class ObjectClicker:MonoBehaviour
    {
        public void Update()
        {
            if(!Input.GetMouseButtonDown(0))
                return;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit =new RaycastHit();
            
            if(Physics.Raycast(ray,out hit,Mathf.Infinity))
            {
                Debug.Log(hit.collider.name);
                {
                    //hit.collider.gameObject now refers to the 
                    //cube under the mouse cursor if present
                }
            }
        }
    }
}