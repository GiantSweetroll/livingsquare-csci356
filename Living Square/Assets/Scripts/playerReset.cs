using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerReset : MonoBehaviour
{
	GameObject player;
	
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
	
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			Invoke(nameof(reset), 1.5f);
		}
	}
	
	void reset()
	{
		player.transform.position = new Vector3(0,2,0);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
