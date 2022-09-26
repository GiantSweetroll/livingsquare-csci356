using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl1NextScene : MonoBehaviour
{
	private GameObject button;
	Animator ButtonAnimator;
	private AudioSource audiosource;
	
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        button = this.gameObject;
		ButtonAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Input.GetMouseButtonDown(0))
		{
			if(Physics.Raycast(ray,out hit) && hit.collider.gameObject == gameObject)
			{
				ButtonAnimator.SetTrigger("Down");
				audiosource.Play(0);
				Invoke(nameof(up), 0.5f);
				SceneManager.LoadScene("Scene_lv2");
			}
		}
    }
    
	void up()
	{
		ButtonAnimator.SetTrigger("Up");
		Invoke(nameof(idle),1f);
	}
	
	void idle()
	{
		ButtonAnimator.SetTrigger("Idle");
	}
}
