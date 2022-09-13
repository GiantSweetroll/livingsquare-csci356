using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtherealController : MonoBehaviour{

/*==============================================================================
								VARIABLES
==============================================================================*/
	//player settings variables
    public float SENS_HOR = 3f;
    public float SENS_VER = 2f;
    public float SPEED = 5f;

	//player internal variables
	private float mvX;
	private float mvZ;
	private Vector3 mvDir;
	private float mouseX;
	private float mouseY;

	//player Components
	private Rigidbody thisRBody;

	//Game Objects Components
	private Transform cameraTf;


/*==============================================================================
									START
==============================================================================*/
    // Start is called before the first frame update ie. Constructor
    void Start(){
		//get the components needed
    	thisRBody = GetComponent<Rigidbody>(); 
		cameraTf = GameObject.Find("Camera").GetComponent<Transform>();

    	// disable the mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
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
        mouseX = Input.GetAxisRaw("Mouse X") * SENS_HOR;
		mouseY = Input.GetAxisRaw("Mouse Y") * SENS_VER;

		//rotate around y axis for body
	    transform.Rotate(0, mouseX, 0);
		//rotate camera according to mouse
        cameraTf.Rotate(-mouseY, 0, 0);

        // enable the mouse cursor if Esc pressed
        if(Input.GetKeyDown("escape")){
            Cursor.lockState = CursorLockMode.None;
		}
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
