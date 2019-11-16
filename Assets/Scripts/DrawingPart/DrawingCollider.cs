﻿using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace.DrawingPart
{
    [RequireComponent(typeof(EventTrigger))]
    public class DrawingCollider:MonoBehaviour
    {
        public static bool BlockedByUI;
        private EventTrigger eventTrigger;
 
        
        private void Start()
        {
            eventTrigger = GetComponent<EventTrigger>();
            if(eventTrigger != null)
            {
                EventTrigger.Entry enterUIEntry = new EventTrigger.Entry();
                // Pointer Enter
                enterUIEntry.eventID = EventTriggerType.PointerEnter;
                enterUIEntry.callback.AddListener((eventData) => { EnterUI(); });
                eventTrigger.triggers.Add(enterUIEntry);
 
                //Pointer Exit
                EventTrigger.Entry exitUIEntry = new EventTrigger.Entry();
                exitUIEntry.eventID = EventTriggerType.PointerExit;
                exitUIEntry.callback.AddListener((eventData) => { ExitUI(); });
                eventTrigger.triggers.Add(exitUIEntry);
            }
        }
 
        public void EnterUI()
        {
            BlockedByUI = true;
        }
        public void ExitUI()
        {
            BlockedByUI = false;
        }
    }
}