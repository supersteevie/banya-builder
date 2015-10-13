using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {
	public Texture2D btnHover;
	public Texture2D btnStatic;
	

	void OnMouseExit () {
		GetComponent<GUITexture>().texture = btnStatic;
		
	}

	void OnMouseEnter () {
		GetComponent<GUITexture>().texture = btnHover;
		
	}

	//quits game when clicked
	void OnMouseDown () {
		Application.Quit();
	}
}
