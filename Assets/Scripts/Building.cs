using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Building : MonoBehaviour {

	//Setting up Varibles
	private float distance = 0;
	private bool placing = false;
	private bool isPlace = true;
	public GameObject flagPole;
	private GameObject transBuilding;
	private GameObject baseBuilding;
	public List<GameObject> listOfPlacedBuildings = new List<GameObject>();
	public Vector3 orgin = Vector3.zero;
	public int stage = 0;
	public float x;
	public float z;

	private GameObject flagOne;

	void Update () 
	{
		//If placing is enabled
		if (placing) {
			//Set up distance to match the floor WIP
			distance = (Input.mousePosition.y / Screen.height) * 25;
			//Code to detect mouse in relationship of the screen
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit))
				transBuilding.transform.position = hit.point;

			var currentPos = transBuilding.transform.position;	
			//Snap to a grid
			transBuilding.transform.position = new Vector3 (Mathf.Round (currentPos.x), 0.5F, Mathf.Round (currentPos.z));

			if(flagOne != null)
			{
				x = orgin.x - transBuilding.transform.position.x;
				z = orgin.z - transBuilding.transform.position.z;
				flagOne.GetComponent<LineRenderer> ().SetPosition (0, orgin);
				flagOne.GetComponent<LineRenderer> ().SetPosition (1, new Vector3(orgin.x - x, orgin.y, orgin.z));
				flagOne.GetComponent<LineRenderer> ().SetPosition (2, new Vector3(orgin.x - x, orgin.y, orgin.z - z));
				flagOne.GetComponent<LineRenderer> ().SetPosition (3, new Vector3(orgin.x, orgin.y, orgin.z - z));
				flagOne.GetComponent<LineRenderer> ().SetPosition (4, orgin);
			}

		} else
			stage = 0;
		//If player clicks to place....
		if (Input.GetMouseButtonDown (0) && baseBuilding != null) 
		{			
			PlaceBuilding (flagPole);
		}

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
			if(stage == 0)
			{
				orgin = clone.transform.position;
				clone.AddComponent<LineRenderer>();
				clone.GetComponent<LineRenderer>().SetVertexCount(5);
				flagOne = clone;
			}

			isPlace = true;
			if(stage == 1)
			{
				GameObject[] listOfFlags = GameObject.FindGameObjectsWithTag("Flag");
				foreach(GameObject go in listOfFlags)
					Destroy(go);

				for(int i = 0; i < Mathf.Abs(x); i++)
					for(int j = 0; j < Mathf.Abs(z); j++)
						{
							clone = (GameObject)Instantiate(baseBuilding, new Vector3(orgin.x - i * Mathf.Sign(x) , orgin.y, orgin.z + j * Mathf.Sign(x)), transBuilding.transform.rotation);					
							listOfPlacedBuildings.Add(clone);
						}
				//Add to list
				
				//Reset variables
				isPlace = true;
				placing = false;
				transBuilding = null;
				baseBuilding = null;
			}
		}
		else
			isPlace = true;

		stage++;
	}

	//These methods are for the other programs to use
	public void TurnOnPlacing()
	{
		placing = true;
		transBuilding = (GameObject)Instantiate(flagPole, transBuilding.transform.position, transBuilding.transform.rotation);
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

