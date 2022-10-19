using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
	//linking id
	public int NextSceneID;
	//transition to next scene name
	public string sceneName;

	public void OnButtonPress(Component invoker, object arg){
		//check if right object that triggered this
		if(invoker is Button && arg is bool){
			bool state = (bool)arg;
			//check if ids match
			if(((Button)invoker).ButtonID == NextSceneID){
				if(state){
					//load next scene
					if(sceneName=="CreditScene"){
						Cursor.lockState = CursorLockMode.None;
					}
					SceneManager.LoadScene(sceneName);
				}
			}
		}
	}
}
