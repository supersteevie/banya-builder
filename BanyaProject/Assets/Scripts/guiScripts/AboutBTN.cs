using UnityEngine;
using System.Collections;

public class AboutBTN : MonoBehaviour {
	public Texture2D btnHover;
	public Texture2D btnStatic;

	private bool showWindow = false;

	void OnGui () {
		//Window all about Byte Club
		if (showWindow == true) {
			GUI.BeginGroup(new Rect (0, 0, Screen.width * 0.33f, Screen.height * 0.33f), " ");
			GUI.Box (new Rect (0, 0, Screen.width * 1/3, Screen.height * 1/3), "About Byte Club");
			GUI.EndGroup();
		}
	}


	// Button returns to static texture when not hovered over
	void OnMouseExit () {
		GetComponent<GUITexture>().texture = btnStatic;
		
	}
	
	// Hover texture applied to button
	void OnMouseEnter () {
		GetComponent<GUITexture>().texture = btnHover;
		
	}

	// About window shown when button is clickec
	void OnMouseDown () {
		showWindow = true;
	}
}
