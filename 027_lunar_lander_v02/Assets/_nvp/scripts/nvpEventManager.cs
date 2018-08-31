﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace newvisionsproject.managers.events
{

    public enum GameEvents
    {
        OnPlayerDestroyed,
        OnSaveLanding
    }

    public class nvpEventManager : MonoBehaviour
    {

        // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public static nvpEventManager INSTANCE;

        private Dictionary<GameEvents, List<Action<object, object>>> eventCallbacks;




        // +++ unity callbacks ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        void Awake()
        {
            if (nvpEventManager.INSTANCE != null)
            {
                Destroy(this.gameObject);
            }
            else
            {
                nvpEventManager.INSTANCE = this;
                eventCallbacks = new Dictionary<GameEvents, List<Action<object, object>>>();
            }
        }




        // +++ class methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        public void Subscribe(GameEvents e, Action<object, object> callback)
        {
            if (!eventCallbacks.ContainsKey(e))
            {
                eventCallbacks[e] = new List<Action<object, object>>();
            }

            eventCallbacks[e].Add(callback);
        }


        public void Unsubscribe(GameEvents e, Action<object, object> observer)
        {
            if (!eventCallbacks.ContainsKey(e)) return;

            if (!eventCallbacks[e].Contains(observer)) return;

            eventCallbacks[e].Remove(observer);
        }

        public void InvokeEvent(GameEvents e, object sender, object eventArgs)
        {
            if (!eventCallbacks.ContainsKey(e)) return;

            foreach (var observer in eventCallbacks[e])
                observer(sender, eventArgs);
        }
        public void Reset()
        {
            eventCallbacks = new Dictionary<GameEvents, List<Action<object, object>>>();
        }

    }
}