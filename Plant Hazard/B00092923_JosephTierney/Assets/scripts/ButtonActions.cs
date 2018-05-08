using UnityEngine;
using System.Collections;

public class ButtonActions : MonoBehaviour {

	public void BUTTON_LOAD_SCENE_WELCOME(){
		Application.LoadLevel("scene0_Welcome");
	}

	public void BUTTON_LOAD_SCENE_LEVEL1_PLAYING(){
		Application.LoadLevel("scene2_Level1Playing");
	}

	public void BUTTON_LOAD_SCENE_LEVEL2_PLAYING(){
		Application.LoadLevel ("scene3_Level2Playing");
	}

	public void BUTTON_LOAD_SCENE_INSTRUCTIONS(){
		Application.LoadLevel ("scene6_instructions");
	}
}