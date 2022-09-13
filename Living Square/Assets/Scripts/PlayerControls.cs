using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float SPEED = 5f;
	private Rigidbody thisRBody;

    // Start is called before the first frame update
    void Start()
    {
		//Rigidbody collision removes bouncing when transfom move inside objects
		thisRBody = GetComponent<Rigidbody>(); //changed to rigidbody collisions
    }

	//rigidbody is physics related thus in FixedUpdate
    void FixedUpdate()
    {
        float mvX = Input.GetAxis("Horizontal");
        float mvZ = Input.GetAxis("Vertical");
		//Vector3 mvDir = (transform.forward * mvZ + transform.right * mvX).normalized;
		Vector3 mvDir = transform.forward * mvZ + transform.right * mvX;

		//rigidbody can use gravity for jumps if needed
		thisRBody.MovePosition(transform.position + mvDir * Time.fixedDeltaTime * SPEED);
    }
}
