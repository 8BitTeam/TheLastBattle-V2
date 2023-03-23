using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class EventDispatcher : MonoBehaviour
{
	Dictionary<EventID, Action<object>> _listeners = new Dictionary<EventID, Action<object>>();
	static EventDispatcher s_instance;
	public static EventDispatcher Instance
	{
		get
		{
			// instance not exist, then create new one
			if (s_instance == null)
			{
				// create new Gameobject, and add EventDispatcher component
				GameObject singletonObject = new GameObject();
				s_instance = singletonObject.AddComponent<EventDispatcher>();
				//singletonObject.name = "Singleton - EventDispatcher";
				//Debug.Log("Create singleton : " + singletonObject.name);
			}
			return s_instance;
		}
	}
	//consturctor truyen vao
	public void RegisterListener(EventID eventID, Action<object> callback)
	{
		// checking params
		//Common.Assert(callback != null, "AddListener, event {0}, callback = null !!", eventID.ToString());
		//Common.Assert(eventID != EventID.None, "RegisterListener, event = None !!");

		// check if listener exist in distionary
		if (_listeners.ContainsKey(eventID))
		{
			// add callback to our collection
			_listeners[eventID] += callback;
		}
		else
		{
			// add new key-value pair
			_listeners.Add(eventID, null);
			_listeners[eventID] += callback;
		}
	}

	public void PostEvent(EventID eventID, object param = null)
	{
		if (!_listeners.ContainsKey(eventID))
		{
			//Common.Log("No listeners for this event : {0}", eventID);
			return;
		}

		// posting event
		var callbacks = _listeners[eventID];
		// if there's no listener remain, then do nothing
		if (callbacks != null)
		{
			callbacks(param);
		}
		else
		{
			//Common.Log("PostEvent {0}, but no listener remain, Remove this key", eventID);
			_listeners.Remove(eventID);
		}
	}
	public void RemoveListener(EventID eventID, Action<object> callback)
	{
		// checking params
		//Common.Assert(callback != null, "RemoveListener, event {0}, callback = null !!", eventID.ToString());
		//Common.Assert(eventID != EventID.None, "AddListener, event = None !!");

		if (_listeners.ContainsKey(eventID))
		{
			_listeners[eventID] -= callback;
		}
		else
		{
			//Common.Warning(false, "RemoveListener, not found key : " + eventID);
			Debug.Log("RemoveListener, not found key : " + eventID);
		}
	}

}
public static class EventDispatcherExtension
{
	/// Use for registering with EventsManager
	public static void RegisterListener(this MonoBehaviour listener, EventID eventID, Action<object> callback)
	{
		EventDispatcher.Instance.RegisterListener(eventID, callback);
	}

	/// Post event with param
	public static void PostEvent(this MonoBehaviour listener, EventID eventID, object param)
	{
		EventDispatcher.Instance.PostEvent(eventID, param);
	}

	/// Post event with no param (param = null)
	public static void PostEvent(this MonoBehaviour sender, EventID eventID)
	{
		EventDispatcher.Instance.PostEvent(eventID, null);
	}
}

