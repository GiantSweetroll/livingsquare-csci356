using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
	private Animator BridgeAnimator;

	public int BridgeID;
	
    void Start(){
		BridgeAnimator = GetComponent<Animator>();
    }

	public void OnButtonPress(Component invoker, object arg){
		if(invoker is Button && arg is bool){
			bool state = (bool)arg;
			if(((Button)invoker).ButtonID == BridgeID){
				if(state){
					open();
				}
				else{
					close();
				}
			}
		}
	}

	void open()
	{
		BridgeAnimator.SetTrigger("Open");
	}
	
	void close()
	{
		BridgeAnimator.SetTrigger("Close");
		Invoke(nameof(reset), 2f);
	}
	
	void reset()
	{
		BridgeAnimator.SetTrigger("Idle");
	}

}