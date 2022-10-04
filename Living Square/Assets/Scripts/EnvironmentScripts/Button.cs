using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
/*==============================================================================
									VARIABLES
==============================================================================*/
	//flags
	private bool isTriggered = false;

	//objects
	public GameObject anInteractObj;
	private Animator anInteractObjAnimator;
	private Animator ButtonAnimator;
	private AudioSource audiosource;

	//internal variables
	private Ray ray;
	private RaycastHit hit;

/*==============================================================================
									START
==============================================================================*/
    void Start()
    {
		audiosource = GetComponent<AudioSource>();
		anInteractObjAnimator = anInteractObj.GetComponent<Animator>();
		ButtonAnimator = GetComponent<Animator>();
    }
	

/*==============================================================================
									UPDATE
==============================================================================*/
    // Update is called once per frame
	//should only be used to get input and non physics related code
    void Update()
    {
		//get ray for where camera is pointing
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if(Input.GetMouseButtonDown(0))
		{
			//check if hit an interactive area ie. button
			if(Physics.Raycast(ray,out hit) && hit.collider.gameObject.tag == "InteractiveArea")
			{
				//animate and sound audio
				ButtonAnimator.SetTrigger("Down");
				audiosource.Play(0);

				//trigger button action (function "up") after 0.5 seconds
				Invoke(nameof(up), 0.5f);

				//toggle button
				if(isTriggered == false)
				{
					//open action object
					isTriggered = true;
					Invoke(nameof(open), 0f);
				} else {
					//close action object
					isTriggered = false;
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
		anInteractObjAnimator.SetTrigger("Open");
	}
	
	void close()
	{
		anInteractObjAnimator.SetTrigger("Close");
		Invoke(nameof(reset), 2f);
	}
	
	void reset()
	{
		anInteractObjAnimator.SetTrigger("Idle");
	}
}