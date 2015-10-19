using UnityEngine;
using System.Collections;

public class NewPlayerButton : MonoBehaviour {

	public Texture2D btnHover;
	public Texture2D btnStatic;
	
	public GameObject screenPlyr;
	public GameObject screenNewPlyr;
	
	
	void OnMouseExit () {
		GetComponent<GUITexture>().texture = btnStatic;
		
	}
	
	// Update is called once per frame
	void OnMouseEnter () {
		GetComponent<GUITexture>().texture = btnHover;
		
	}

	//Opens new player screen
	void OnMouseDown () {
		screenPlyr.transform.Translate(Vector3.left, Space.World);
		screenNewPlyr.transform.Translate(Vector3.right, Space.World);

	}
}
