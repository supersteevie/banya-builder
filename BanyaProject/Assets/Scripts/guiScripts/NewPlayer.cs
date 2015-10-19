using UnityEngine;
using System.Collections;

public class NewPlayer : MonoBehaviour {


	public Texture2D[] countyFlags;
	public Vector2 flagScroll = Vector2.zero;
	public GameObject screenBanya;
	public GameObject screenPlyr;

	public Rect newPlyrGroup = new Rect(Screen.width * 0.075f, Screen.height * 0.075f, Screen.width / 1.15f, Screen.height / 1.15f);

	void OnGui (){
	//Have player enter name
		GUI.BeginGroup (newPlyrGroup);

		GUI.Label (new Rect(newPlyrGroup.width * 0.5f, 0.0f, 0.0f, 0.0f), "New Player");
		GUI.TextArea(new Rect(newPlyrGroup.width * 0.33f, newPlyrGroup.height * 0.25f, 0.0f, 0.0f), "Enter Name");

		//Have player choose where they are from
		GUI.Label (new Rect (newPlyrGroup.width * 0.33f, newPlyrGroup.height * 0.375f, 0.0f, 0.0f), "Where you from?");
		flagScroll = GUI.BeginScrollView (new Rect (0.0f, newPlyrGroup.height * 0.4375f, 0.0f, 0.0f), flagScroll, new Rect (newPlyrGroup.width * 0.33f, newPlyrGroup.height * 0.4375f, 0.0f, 0.0f)); 
		GUI.DrawTexture (new Rect (0.0f, newPlyrGroup.height * 0.4375f, 0.0f, 0.0f), countyFlags[0], ScaleMode.ScaleToFit);
		GUI.DrawTexture (new Rect (0.0f, newPlyrGroup.height * 0.4375f, 0.0f, 0.0f), countyFlags[1], ScaleMode.ScaleToFit);
		GUI.DrawTexture (new Rect (0.0f, newPlyrGroup.height * 0.4375f, 0.0f, 0.0f), countyFlags[2], ScaleMode.ScaleToFit);
		GUI.DrawTexture (new Rect (0.0f, newPlyrGroup.height * 0.4375f, 0.0f, 0.0f), countyFlags[3], ScaleMode.ScaleToFit);
		GUI.EndScrollView();

		//Have player confirm
		if(GUI.Button(new Rect(newPlyrGroup.width * 0.66f, newPlyrGroup.height * 0.75f, 0.0f, 0.0f), "Create")){
			transform.Translate(Vector3.left, Space.World);
			screenBanya.transform.Translate(Vector3.right, Space.World);
		}

		GUI.EndGroup();




	}
}
