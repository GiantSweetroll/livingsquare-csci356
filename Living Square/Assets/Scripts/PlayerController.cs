using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

Please Note that this script is a concept for alternative method
should Includes:
- camera rotation
- player movement
- spawns ethereal
- pass camera to ethereal
- despawn ethereal
- pass camera back to main body

*/

public class PlayerController : MonoBehaviour{

	/*==============================================================================
									VARIABLES
	==============================================================================*/
	//player settings variables
	public float SPEED = 5f;
	public float DURATION = 6f;

	//player internal variables
	private float mvX;
	private float mvZ;
	private Vector3 mvDir;
	private bool isInstantiated = false;
    private float etherealTimer;

	//player Components
	private Rigidbody thisRBody;

	//Game Objects
	public GameObject aMainCamera;
	public GameObject EtherealPrefab;
	private GameObject EtherealInstance;


/*==============================================================================
									START
==============================================================================*/
    // Start is called before the first frame update ie. Constructor
    void Start(){
		//get the components needed
    	thisRBody = GetComponent<Rigidbody>(); 

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

		//switch to ethereal
		if (Input.GetKeyDown(KeyCode.Z))
		{
			SwitchEtherealMode(!isInstantiated);
		}

		// If ethereal form object is instantiated
		if (isInstantiated){

			// If the ethereal mode timer ran out, return to physical body
			if (etherealTimer <= 0)
			{
				SwitchEtherealMode(false);
			}
			// Otherwise, reduce the timer every second
			else
			{
				etherealTimer -= Time.deltaTime;
			}
		}
    }


/*==============================================================================
								FIXED_UPDATE
==============================================================================*/
	// May update many times between frames follows fixed physics timestep
	void FixedUpdate(){
		if(!isInstantiated){
			//calculate direction vector
			mvDir = transform.forward * mvZ + transform.right * mvX;
			//move body
			thisRBody.MovePosition(transform.position + mvDir * Time.fixedDeltaTime * SPEED);
		}
	}


/*==============================================================================
								SWITCH_ETHEREAL_MODE
==============================================================================*/
	private void SwitchEtherealMode(bool isEthereal)
    {
		isInstantiated = isEthereal;

		// Enable ethereal mode
		if (isEthereal)
        {
			// Create Ethereal form object
			EtherealInstance = Instantiate(EtherealPrefab, transform.position, transform.rotation);
			aMainCamera.transform.parent = EtherealInstance.transform;
		}
		// Disable ethereal mode
		else
        {
			//reset to original body
			aMainCamera.transform.parent = this.transform;
			aMainCamera.transform.rotation = this.transform.rotation;
			aMainCamera.transform.position = this.transform.position;

			//destroy the instance
			Destroy(EtherealInstance);
		}

		// Reset timer
		etherealTimer = DURATION;
	}
}
