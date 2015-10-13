using UnityEngine;
using System.Collections;

public class NewBanyaButton : MonoBehaviour {

	public Texture2D btnHover;
	public Texture2D btnStatic;

	
	
	void OnMouseExit () {
		GetComponent<GUITexture>().texture = btnStatic;
		
	}

	void OnMouseEnter () {
		GetComponent<GUITexture>().texture = btnHover;
		
	}

	//Loads demo level
	void OnMouseDown () {
		Application.LoadLevel("World");
	}
}
