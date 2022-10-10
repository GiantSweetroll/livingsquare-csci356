using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
	private Animator BridgeAnimator;
	
    void Start(){
		BridgeAnimator = GetComponent<Animator>();
    }

	public void OnButtonPress(bool state){
		if(state){
			open();
		}
		else{
			close();
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