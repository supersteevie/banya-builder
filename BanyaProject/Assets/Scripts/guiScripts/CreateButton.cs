using UnityEngine;
using System.Collections;

public class CreateButton : MonoBehaviour {
	public GameObject screenNewPlyr;
	public GameObject screenBanya;

	public Texture2D btnHover;
	public Texture2D btnStatic;

	void OnMouseExit () {
		GetComponent<GUITexture>().texture = btnStatic;
		
	}
	
	void OnMouseEnter () {
		GetComponent<GUITexture>().texture = btnHover;
		
	}


	//creates a new character and goes to Banya select screen
	void OnMouseDown () {
		screenNewPlyr.transform.Translate(Vector3.left, Space.World);
		screenBanya.transform.Translate(Vector3.right, Space.World);
	}
}
