using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtherealController : MonoBehaviour{

/*==============================================================================
								VARIABLES
==============================================================================*/
	//player settings variables
    public float SPEED = 5f;

	//player internal variables
	private float mvX;
	private float mvZ;
	private Vector3 mvDir;

	//player Components
	private Rigidbody thisRBody;


/*==============================================================================
									START
==============================================================================*/
	// Start is called before the first frame update ie. Constructor
	void Start(){
		//get the components needed
		thisRBody = GetComponent<Rigidbody>(); 
	}


/*==============================================================================
									UPDATE
==============================================================================*/
    // Update is called once per frame
	//should only be used to get input and non physics related code
    void Update(){
		//get inputs
        mvX = Input.GetAxis("Horizontal");
        mvZ = Input.GetAxis("Vertical");
	}


/*==============================================================================
								FIXED_UPDATE
==============================================================================*/
	// May update many times between frames follows fixed physics timestep
	void FixedUpdate(){
		//calculate direction vector
		mvDir = transform.forward * mvZ + transform.right * mvX;
		//move body
		thisRBody.MovePosition(transform.position + mvDir * Time.fixedDeltaTime * SPEED);
	}
}
