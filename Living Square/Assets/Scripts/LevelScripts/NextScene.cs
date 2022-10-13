using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
	public int NextSceneID;
	public string sceneName;

	public void OnButtonPress(Component invoker, object arg){
		if(invoker is Button && arg is bool){
			bool state = (bool)arg;
			if(((Button)invoker).ButtonID == NextSceneID){
				if(state){
					SceneManager.LoadScene(sceneName);
				}
			}
		}
	}
}
