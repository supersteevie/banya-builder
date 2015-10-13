using UnityEngine;
using System.Collections;

public class BackButton1 : MonoBehaviour {
	
	public Texture2D btnHover;
	public Texture2D btnStatic;

	public GameObject screenPlyr;
	public GameObject screenTitle;

	// Button returns to static texture when not hovered over
	void OnMouseExit () {
		GetComponent<GUITexture>().texture = btnStatic;
		
	}
	
	// Hover texture applied to button
	void OnMouseEnter () {
		GetComponent<GUITexture>().texture = btnHover;
		
	}

	// Takes user back to previous screen
	void OnMouseDown () {
		screenPlyr.transform.Translate(Vector3.left, Space.World);
		screenTitle.transform.Translate(Vector3.right, Space.World);
	}
}
