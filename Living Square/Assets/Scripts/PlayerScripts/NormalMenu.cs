﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NormalMenu : MonoBehaviour
{
	private bool menuActive = false;
	private string message = "MENU";

	//working area
	private int halfWidthStart;
	private int halfHeightStart;
	private int workingAreaWidth = 360;
	private int workingAreaHeight = 400;

	//title settings
	public Font titleFont;
	private Color titleColour = new Color(1,1,1,1);
	//menu settings
	public Font menuFont;
	private Color menuColour = new Color(1,1,1,1);
	private Color menuHoverColour = new Color(0.9f,0.5f,0,1);


	//title style
	private GUIStyle titleStyle = new GUIStyle();
	//menu style
	private GUIStyle menuStyle = new GUIStyle();
	private Texture2D aTex;
	//title and menu box
	private Rect mainBox;
	private Rect menuBox;
	private Rect titleBox;
	private Rect buttonBox1;
	private Rect buttonBox2;

    void Start(){      
		//centered box on screen
		halfWidthStart = (int)((Screen.width - workingAreaWidth) * 0.5);
		halfHeightStart = (int)((Screen.height - workingAreaHeight) * 0.5);
		mainBox = new Rect(halfWidthStart, halfHeightStart, workingAreaWidth, workingAreaHeight);
		menuBox = new Rect(0, 0, workingAreaWidth, workingAreaHeight);

		//setting the style for title
		titleStyle.font = titleFont;
		titleStyle.fontSize = 48;
		titleStyle.normal.textColor = titleColour;
		titleStyle.alignment = TextAnchor.UpperCenter;

		//setting the style for menu buttons
		menuStyle.font = menuFont;
		menuStyle.fontSize = 16;
		menuStyle.alignment = TextAnchor.UpperCenter;
		menuStyle.normal.textColor = menuColour;
		menuStyle.normal.background = Texture2D.blackTexture;
		//hover does not work unless there is a texture underneath
		menuStyle.hover.textColor = menuHoverColour; 
		//change colour of basic gray texture
		aTex = Texture2D.grayTexture;
		Color[] texColours = new Color[16];
		for(int i = 0; i < 16; ++i){
			texColours[i].r = 0.1f;
			texColours[i].g = 0.1f;
			texColours[i].b = 0.1f;
			texColours[i].a = 1;
		}
		aTex.SetPixels(texColours);
		aTex.Apply(false);
		//menuStyle.hover.background = aTex;
		menuStyle.hover.background = Texture2D.whiteTexture;

		//create title and menu box area
		titleBox = new Rect(0, 20, workingAreaWidth, 200);
		buttonBox1 = new Rect(0, 250, workingAreaWidth, 25);
		buttonBox2 = new Rect(0, 300, workingAreaWidth, 25);
    }

	void Update(){
        if(Input.GetKeyDown("escape")){
			menuActive = true;	
            Cursor.lockState = CursorLockMode.None;
		}
	}

    void OnGUI(){
       if(menuActive){
			//working area of the title and menu buttons
			GUI.BeginGroup(mainBox);
			GUI.Box(menuBox, "");

			//Title label
			GUI.Label(titleBox, message, titleStyle);

			if(GUI.Button(buttonBox1, "RESTART", menuStyle)){
				//lighting may not generate in editor debug mode when loading scene
				//to fix (important go to "Scene_lvl1" first):  
				//Windows > Rendering > lighting settings > tick Auto Generate
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}

			if(GUI.Button(buttonBox2, "QUIT", menuStyle)){
				//this function is ignored by the debug editor and works only when
				// as a standalone application
				Application.Quit();
			}

			GUI.EndGroup();
	   } 
    }

	public void openNormalMenu(bool state){menuActive = state;}
	public void openDeathMenu(bool state){
		message = "YOU\nFAILED";
		menuActive = state;
	}
}