using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    public class EventHandler: MonoBehaviour
    {
        static private EventHandler _Current;
        static public EventHandler Current
        {
            get
            {
                if (_Current == null)
                {
                    _Current = GameObject.FindObjectOfType<EventHandler>();
                }

                return _Current;
            }
        }

        public delegate void EventListener(Event eventI);
        Dictionary<System.Type, List<EventListener>> eventListeners;

        public void RegisterListener(System.Type type, EventListener listener)
        {
            if (eventListeners == null)
            {
                eventListeners = new Dictionary<System.Type, List<EventListener>>();
            }

            if (eventListeners.ContainsKey(type) == false || eventListeners[type] == null)
            {
                eventListeners[type] = new List<EventListener>();
            }

            eventListeners[type].Add(listener);
        }

        public void UnregisterListener(System.Type type, EventListener listener)
        {
            eventListeners[type].Remove(listener);
        }

        public void FireEvent(Event eventI)
        {
            System.Type trueEvent = eventI.GetType();
            if (eventListeners == null || eventListeners[trueEvent] == null)
            {
                return;
            }

            foreach (EventListener eventListener in eventListeners[trueEvent])
            {
                eventListener(eventI);
            }

        }
    }
}
