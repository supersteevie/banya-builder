using UnityEngine;
using System.Collections;

public class BanyaIcon : MonoBehaviour {

	public Material iconHover;
	public Material iconStatic;
	//target is camera
	public Transform target;


	//ensures that icon is always looking at the camera
void Update (){
		transform.LookAt(target);
	}

void OnMouseHover () {
		GetComponent<Renderer>().material = iconHover;
		//transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
	}

void OnMouseExit () {
		GetComponent<Renderer>().material = iconStatic;
		//transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
	}


	//loads demo level
void OnMouseDown () {
		Application.LoadLevel("World");
	}
}
