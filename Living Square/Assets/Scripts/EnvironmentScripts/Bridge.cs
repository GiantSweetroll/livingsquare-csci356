using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
	Animator BridgeAnimator;
	bool bridgeOpen;
	
    // Start is called before the first frame update
    void Start()
    {
        bridgeOpen = false;
		BridgeAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) )
		{
			bridgeOpen=true;
			BridgeAnimator.SetTrigger("Open");
		}
    }
	
	void reset()
	{
		if(bridgeOpen==true){
				bridgeOpen=false;
				BridgeAnimator.SetTrigger("Close");
		}
	}
}