using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace GameLokal.Toolkit
{
	[ExecuteAlways]
	public static class EventManager 
	{
	    private static Dictionary<Type, List<IEventListenerBase>> subscribersList;

		static EventManager()
	    {
	        subscribersList = new Dictionary<Type, List<IEventListenerBase>>();
	    }

	    public static void AddListener<T>(IEventListener<T> listener) where T : struct
	    {
	        var eventType = typeof(T);

	        if( !subscribersList.ContainsKey(eventType))
	            subscribersList[eventType] = new List<IEventListenerBase>();

	        if( !SubscriptionExists(eventType, listener))
	            subscribersList[eventType].Add(listener);
	    }
	    
	    public static void RemoveListener<T>(IEventListener<T> listener) where T : struct
	    {
	        var eventType = typeof(T);

	        if(!subscribersList.ContainsKey(eventType))
	        {
		        return;
	        }

			List<IEventListenerBase> subscriberList = subscribersList[eventType];

			for (int i = 0; i < subscriberList.Count; i++)
			{
				if(subscriberList[i] == listener)
				{
					subscriberList.Remove(subscriberList[i]);

					if(subscriberList.Count == 0)
						subscribersList.Remove(eventType);

					return;
				}
			}
	    }
	    
	    public static void TriggerEvent<T>(T newEvent) where T : struct
	    {
		    if(!subscribersList.TryGetValue(typeof(T), out var listeners))
		        return;

	        foreach (var listener in listeners)
	        {
		        (listener as IEventListener<T>)?.OnEvent(newEvent);
	        }
	    }
	    
	    private static bool SubscriptionExists(Type type, IEventListenerBase receiver)
	    {
		    return subscribersList.TryGetValue(type, out var receivers) && receivers.Any(currentReceiver => currentReceiver == receiver);
	    }
	}
}