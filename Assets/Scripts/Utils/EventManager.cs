using System;
using System.Collections.Generic;
using UnityEngine;

namespace v_hero.Utils
{
    public class EventManager : MonoBehaviour
    {
        // Singleton instance
        private static EventManager instance;

        // Event dictionary to hold event types and corresponding delegates with data
        private Dictionary<string, Delegate> eventDictionaryWithData;

        // Event dictionary to hold event types and corresponding delegates without data
        private Dictionary<string, Action> eventDictionaryWithoutData;

        // Get the singleton instance
        public static EventManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<EventManager>();

                    if (instance == null)
                    {
                        GameObject container = new GameObject("EventManager");
                        instance = container.AddComponent<EventManager>();
                    }
                }

                return instance;
            }
        }

        // Subscribe to an event with data
        public static void SubscribeEvent<T>(string eventName, Action<T> eventHandler)
        {
            if (Instance.eventDictionaryWithData.ContainsKey(eventName))
            {
                Instance.eventDictionaryWithData[eventName] = Delegate.Combine(Instance.eventDictionaryWithData[eventName], eventHandler);
            }
            else
            {
                Instance.eventDictionaryWithData.Add(eventName, eventHandler);
            }
        }

        // Subscribe to an event without data
        public static void SubscribeEvent(string eventName, Action eventHandler)
        {
            if (Instance.eventDictionaryWithoutData.ContainsKey(eventName))
            {
                Instance.eventDictionaryWithoutData[eventName] += eventHandler;
            }
            else
            {
                Instance.eventDictionaryWithoutData.Add(eventName, eventHandler);
            }
        }

        // Unsubscribe from an event with data
        public static void UnsubscribeEvent<T>(string eventName, Action<T> eventHandler)
        {
            if (Instance.eventDictionaryWithData.ContainsKey(eventName))
            {
                Instance.eventDictionaryWithData[eventName] = Delegate.Remove(Instance.eventDictionaryWithData[eventName], eventHandler);
            }
        }

        // Unsubscribe from an event without data
        public static void UnsubscribeEvent(string eventName, Action eventHandler)
        {
            if (Instance.eventDictionaryWithoutData.ContainsKey(eventName))
            {
                Instance.eventDictionaryWithoutData[eventName] -= eventHandler;
            }
        }

        // Trigger an event with data
        public static void TriggerEvent<T>(string eventName, T eventData)
        {
            if (Instance.eventDictionaryWithData.ContainsKey(eventName))
            {
                Delegate[] delegates = Instance.eventDictionaryWithData[eventName].GetInvocationList();
                for (int i = 0; i < delegates.Length; i++)
                {
                    Action<T> eventHandler = delegates[i] as Action<T>;
                    eventHandler?.Invoke(eventData);
                }
            }
        }

        // Trigger an event without data
        public static void TriggerEvent(string eventName)
        {
            if (Instance.eventDictionaryWithoutData.ContainsKey(eventName))
            {
                Instance.eventDictionaryWithoutData[eventName]?.Invoke();
            }
        }

        // Initialize the event dictionaries
        private void Awake()
        {
            eventDictionaryWithData = new Dictionary<string, Delegate>();
            eventDictionaryWithoutData = new Dictionary<string, Action>();
        }
    }

}
