using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Building : MonoBehaviour {

	//Setting up Varibles
	private float distance = 0;
	private bool placing = false;
	private bool isPlace = true;
	private GameObject transBuilding;
	private GameObject baseBuilding;
	public List<GameObject> listOfPlacedBuildings = new List<GameObject>();

	void Update () 
	{
		//If placing is enabled
		if(placing)
		{
			//Set up distance to match the floor WIP
			distance = (Input.mousePosition.y / Screen.height) * 25;
			//Code to detect mouse in relationship of the screen
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if(Physics.Raycast(ray, out hit))
				transBuilding.transform.position = hit.point;

			var currentPos = transBuilding.transform.position;	
			//Snap to a grid
			transBuilding.transform.position = new Vector3(Mathf.Round(currentPos.x), 0.5F, Mathf.Round(currentPos.z));

		}
		//If player clicks to place....
		if(Input.GetMouseButtonDown(0) && baseBuilding != null)
			PlaceBuilding(baseBuilding);
	}

	void PlaceBuilding(GameObject o)
	{
		//Catch Null Exception
		if(o != null)
		{
			foreach(GameObject go in listOfPlacedBuildings)
			{
			//Check if building is already there
			if(go.transform.position == transBuilding.transform.position)
					isPlace = false;
			}
		}

		if(isPlace)
		{
			//If space is avaliable
			GameObject clone = o;
			//Place building
			clone = (GameObject)Instantiate(o, transBuilding.transform.position, transBuilding.transform.rotation);
			//Add to list
			listOfPlacedBuildings.Add(clone);
			//Reset variables
			isPlace = true;
			placing = false;
			Destroy(transBuilding);
			transBuilding = null;
			baseBuilding = null;
		}
		else
			isPlace = true;
	}

	//These methods are for the other programs to use
	public void TurnOnPlacing()
	{
		placing = true;
		transBuilding = (GameObject)Instantiate(transBuilding, transBuilding.transform.position, transBuilding.transform.rotation);
	}

	public void SetTransObject(string go)
	{
		transBuilding = BuildingBase.Get (go).TransPrefab;
	}
	public void SetBaseObject(string go)
	{
		baseBuilding = BuildingBase.Get (go).BasePrefab;
		baseBuilding.GetComponent<BuildingAI> ().SetStats (go);

	}
}

