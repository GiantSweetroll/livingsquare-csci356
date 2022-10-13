using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CustomEvent : UnityEvent<Component, object>{} 

public class EventListener : MonoBehaviour
{
	public EventManager eventManager;
	public CustomEvent anEvent;

	private void OnEnable(){
		eventManager.AddListener(this);
	} 

	private void OnDisable(){
		eventManager.RemoveListener(this);
	} 

	//called when event is triggered
	public void OnRaisedEvent(Component invoker, object arg){
		anEvent.Invoke(invoker, arg);
	}
}
