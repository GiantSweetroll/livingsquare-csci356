using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
	private GameObject button;
	public GameObject Bridge;
	public bool bridgeOpen;
	Animator BridgeAnimator;
	Animator ButtonAnimator;
	private AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
		audiosource = GetComponent<AudioSource>();
        button = this.gameObject;
		BridgeAnimator = Bridge.GetComponent<Animator>();
		ButtonAnimator = this.GetComponent<Animator>();
    }
	

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Input.GetMouseButtonDown(0))
		{
			if(Physics.Raycast(ray,out hit) && hit.collider.gameObject == gameObject)
			{
				ButtonAnimator.SetTrigger("Down");
				audiosource.Play(0);
				Invoke(nameof(up), 0.5f);
				if(bridgeOpen==false)
				{
					Invoke(nameof(open), 0f);
				} else {
					Invoke(nameof(close), 0f);
				}
			}
		}
    }
	
	void up()
	{
		ButtonAnimator.SetTrigger("Up");
		Invoke(nameof(idle),1f);
	}
	
	void idle()
	{
		ButtonAnimator.SetTrigger("Idle");
	}
	
	void open()
	{
		BridgeAnimator.SetTrigger("Open");
		bridgeOpen=true;
	}
	
	void close()
	{
		BridgeAnimator.SetTrigger("Close");
		bridgeOpen=false;
		Invoke(nameof(reset), 2f);
	}
	
	void reset()
	{
		BridgeAnimator.SetTrigger("Idle");
	}
}
