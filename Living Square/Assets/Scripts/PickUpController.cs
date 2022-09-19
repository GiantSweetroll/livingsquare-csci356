using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
/*==============================================================================
								VARIABLES
==============================================================================*/
    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    private GameObject heldObj;
    private Rigidbody heldObjRb;

    [Header("Physics Parameters")]
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;

/*==============================================================================
									UPDATE
==============================================================================*/
    private void Update()
    {
        // TODO: Don't know what's the best key for holding/release yet
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {
                    // Pick up object from raycast
                    PickupObject(hit.transform.gameObject);
                }
            }
            else
            {
                // Drop object
                DropObject();
            }
        }

        if (heldObj != null)
        {
            // Move object
            MoveObject();
        }
    }
/*==============================================================================
                                PICK UP METHODS
==============================================================================*/
    void PickupObject(GameObject pickedObj)
    {
        if (pickedObj.GetComponent<Rigidbody>())
        {
            heldObjRb = pickedObj.GetComponent<Rigidbody>();
            heldObjRb.useGravity = false;
            heldObjRb.drag = 10;
            heldObjRb.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjRb.transform.parent = holdArea;
            heldObj = pickedObj;
        }
    }
    void DropObject()
    {
        heldObjRb.useGravity = true;
        heldObjRb.drag = 1;
        heldObjRb.constraints = RigidbodyConstraints.None;

        heldObjRb.transform.parent = null;
        heldObj = null;
    }

    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRb.AddForce(moveDirection * pickupForce);
        }
    }
}
