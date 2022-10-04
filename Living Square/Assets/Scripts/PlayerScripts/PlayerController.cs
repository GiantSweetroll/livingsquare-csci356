﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

/*==============================================================================
									VARIABLES
==============================================================================*/
	//player settings variables
	[Header("Settings")]
	public float SPEED = 5f;
	public float DURATION = 6f;
	//force in newtons 2.7 * mass in kg is average adult jump force
	public float JUMP_FORCE = 189f; //player currently 70kg
	// Size of sphere to check for ground collision
	private float GROUND_CHECK_RADIUS = 0.50001f;

	//player internal variables
	//movement
	private float mvX;
	private float mvZ;
	private Vector3 mvDir;
	//ethereal
	private float etherealTimer;
	//flags
	private bool isInstantiated = false;
	private bool isGrounded = true;

	//player Components
	private Rigidbody thisRBody;

	//Game Objects
	[Header("Game Object References")]
	public GameObject aMainCamera;
	public GameObject EtherealPrefab;
	private GameObject EtherealInstance;
	private PickUpController pickupController;
	private Transform groundCheck;
	//layer 9 is ground
	public LayerMask groundMask;


/*==============================================================================
									START
==============================================================================*/
    // Start is called before the first frame update ie. Constructor
    void Start(){
		//get the components needed
    	thisRBody = GetComponent<Rigidbody>(); 
		//get ground check sphere object transform
		groundCheck = transform.Find("GroundCheck");
    	// disable the mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
		// get reference to PickUpController script
		pickupController = aMainCamera.GetComponent<PickUpController>();
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

		// Player jump
		if (Input.GetButtonDown("Jump") && isGrounded && !isInstantiated)
        {
			thisRBody.AddForce(transform.up * JUMP_FORCE, ForceMode.Impulse);
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
			// Check if player is grounded
			isGrounded = Physics.CheckSphere(groundCheck.position, GROUND_CHECK_RADIUS, groundMask);

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

		// Drop any objects currently being picked up
		if (pickupController.heldObj != null)
			pickupController.DropObject();

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