using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {
	public Texture2D btnHover;
	public Texture2D btnStatic;

	public GameObject titleScreen;
	public GameObject plyrScreen;

	//loads player selection screen
	void OnMouseDown () {
		titleScreen.transform.Translate(Vector3.left, Space.World);
		plyrScreen.transform.Translate(Vector3.right, Space.World);

	}
	
	void OnMouseExit () {
		GetComponent<GUITexture>().texture = btnStatic;
	
	}

	void OnMouseEnter () {
		GetComponent<GUITexture>().texture = btnHover;
	
	}
}
