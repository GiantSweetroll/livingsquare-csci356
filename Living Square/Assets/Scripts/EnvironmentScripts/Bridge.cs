using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
	private Animator Animator;
	
    void Start(){
		Animator = this.GetComponent<Animator>();
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
		Animator.SetTrigger("Open");
	}
	
	void close()
	{
		Animator.SetTrigger("Close");
		Invoke(nameof(reset), 2f);
	}
	
	void reset()
	{
		Animator.SetTrigger("Idle");
	}

}