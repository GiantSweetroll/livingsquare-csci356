using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
	private Animator BridgeAnimator;

	//linking id for which button id
	public int BridgeID;
	
    void Start(){
		BridgeAnimator = GetComponent<Animator>();
    }

	public void OnButtonPress(Component invoker, object arg){
		//check if it is the right object to trigger this
		if(invoker is Button && arg is bool){
			bool state = (bool)arg;
			//check if ids match
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