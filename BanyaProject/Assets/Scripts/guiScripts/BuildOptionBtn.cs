using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildOptionBtn : MonoBehaviour {

	public int roomID;

	// Use this for initialization
	void Start () {
		gameObject.GetComponentInChildren<Text>().text = BuildingBase.Get(roomID).Name;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChooseRoom () {
		GameObject.FindGameObjectWithTag("MainCamera").GetComponent<BuildingHandler>().SetTransObject(BuildingBase.Get(roomID).Name);
		GameObject.FindGameObjectWithTag("MainCamera").GetComponent<BuildingHandler>().SetBaseObject(BuildingBase.Get(roomID).Name);
		GameObject.FindGameObjectWithTag("MainCamera").GetComponent<BuildingHandler>().TurnOnPlacing();

	}
}
