using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {

	public GameObject plyrSelect;
	public GameObject banyaSelect;
	public GameObject newPlyrScreen;


	//public Vector of origin position of GUI
	//public static Vector3 guiOriginiPos = new Vector3(-5.104331f, 3.212008f, -12.86632f);

	// Use this for initialization
	void Start () {
		//Set transform transalte for three GUI gameobjects/ selection screens
		plyrSelect.transform.Translate(Vector3.left, Space.World);
		banyaSelect.transform.Translate(Vector3.left, Space.World);
		newPlyrScreen.transform.Translate(Vector3.left, Space.World);

		//If PlayBTN.OnMouseDown == true
		//	PlayerSelect.transform.translate(in front of camera)
		//If BackBTN1.OnMouseDown == true
		//	TitleScreen.transform.translate(in front of camera)
		//If BackBTN2.OnMouseDown == true
		//	PlayerSelect.transform.translate(in front of camera)

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
