using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
	public int num;
	private string name;
	private GameObject Barrier;
	private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Pickable")
		{
			name = "Barrier" + num;
			Barrier = GameObject.Find(name);
			rend = Barrier.GetComponent<MeshRenderer>();
			rend.enabled = false;
			Barrier.GetComponent<Collider>().enabled = false;
		}
		
		if(num==5){
			if(col.gameObject.tag=="Player")
			{
				GameObject door1 = GameObject.Find("door1");
				GameObject door2 = GameObject.Find("door2");
				
			}
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.tag == "Pickable")
		{
			name = "Barrier" + num;
			Barrier = GameObject.Find(name);
			rend = Barrier.GetComponent<MeshRenderer>();
			rend.enabled = true;
			Barrier.GetComponent<Collider>().enabled = true;
		}
	}
}
