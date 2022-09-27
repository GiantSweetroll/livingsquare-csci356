using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReset : MonoBehaviour
{
	private Vector3 resetPos = new Vector3(0,2,0);
	private Transform playerTF;

    void Start()
    {
		//get player tranform
		playerTF = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Transform>();
		//no collision with world, ground and walls
		Physics.IgnoreLayerCollision(4, 0);
		Physics.IgnoreLayerCollision(4, 9);
		Physics.IgnoreLayerCollision(4, 10);
    }
	
	//trigged when player collides
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			//resets after 1.5 seconds
			Invoke(nameof(reset), 1.5f);
		}
	}
	
	void reset()
	{
		playerTF.position = resetPos;
	}
}
