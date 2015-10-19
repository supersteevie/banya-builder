using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KimanAI : MonoBehaviour {


	public float tempSpeed = .01f;
	public GameObject targetBuilding;
	public GameObject lastBuilding;
	private Vector3 targetLocation;
	private Vector3 rotationLook;
	private float proxy;
	private bool inTransit = false;
	private bool usingBuilding = false;
	private bool isLeaving = false;
	private bool visitedABuilding = false;
	private float actionTimer;

	public int Id;	
	public string Name;
	public string Race;
	private int roomVisited;

	// Ache is Body
	private int ach;
	// Thought is mind
	private int tgh;
	// Awe is Spirit
	private int awe;

	//Moods
	public int mMood = 1;
	public int sMood = 1;
	public int bMood = 1;

	private bool mMoodVisited;
	private bool sMoodVisited;
	private bool bMoodVisited;

	//Joy
	public int joy;

	// Use this for initialization
	void Start () {
		KimanGenerator kiman = new KimanGenerator ();
		Id = kiman.Id;
		Name = kiman.Name;
		Race = kiman.Race;
		ach = kiman.ach;
		tgh = kiman.tgh;
		awe = kiman.awe;
	}
	
	// Update is called once per frame
	void Update () {
		joy = mMood + sMood + bMood;
		Object[] listOfPlacedBuildings;
		listOfPlacedBuildings = GameObject.FindGameObjectsWithTag("Building");		
		
		if(listOfPlacedBuildings.Length != 0 && !inTransit && !usingBuilding && !isLeaving)
		{
			if(roomVisited >= 3 && visitedABuilding)
			{
				isLeaving = true;
				KimanLeave();
			}
			else
			{
				targetBuilding = nextRoom();
				targetLocation = targetBuilding.transform.position;
				inTransit = true;
			}
		}
		if(!isLeaving)
			proxy = Vector3.Distance(transform.position, targetLocation);

		if(proxy > 1f && inTransit && !isLeaving)
		{
			targetLocation.y = 1;
			transform.LookAt(targetLocation);
			transform.Translate(new Vector3(0,0,tempSpeed));
		}
		else if(!usingBuilding && !isLeaving)
		{
			inTransit = false;
			usingBuilding = true;
			actionTimer = RandomBehavior(10) + 1;
			GetComponent<Renderer>().enabled = false;
		}

		if(usingBuilding)
		{
			actionTimer -= Time.deltaTime;
			visitedABuilding = true;
			if(actionTimer <= 0)
			{
				usingBuilding = false;
				GetComponent<Renderer>().enabled = true;				
				lastBuilding = targetBuilding;
				if(lastBuilding.GetComponent<BuildingAI>().buildingType == BuildingTypes.Body)
				{
					if(ach > lastBuilding.GetComponent<BuildingAI>().auraACH)
						bMood--;
					else if (ach < lastBuilding.GetComponent<BuildingAI>().auraACH)
						bMood++;
				}
				else if(lastBuilding.GetComponent<BuildingAI>().buildingType == BuildingTypes.Spirit)
				{
					if(awe > lastBuilding.GetComponent<BuildingAI>().auraAWE)
						sMood--;
					else if (awe < lastBuilding.GetComponent<BuildingAI>().auraAWE)
						sMood++;
				}
				else if(lastBuilding.GetComponent<BuildingAI>().buildingType == BuildingTypes.Mind)
				{
					if(tgh > lastBuilding.GetComponent<BuildingAI>().auraTHG)
						mMood--;
					else if (tgh < lastBuilding.GetComponent<BuildingAI>().auraTHG)
						mMood++;
				}
				roomVisited ++;
			}
		}

		if(isLeaving && inTransit)
		{
			transform.Translate(new Vector3(0,0,tempSpeed));
			if(transform.position.x > 20 || transform.position.z > 20 || transform.position.x < -20 || transform.position.z < -20)
			{
				GameObject.FindGameObjectWithTag("MainCamera").GetComponent<KimanHandler>().RemoveKiman(this.gameObject);
				Destroy(this.gameObject);
			}
		}

	}

	private void KimanLeave()
	{
		transform.LookAt(new Vector3((float)Random.Range(0, 360), 1, (float)Random.Range(0, 360)));
		inTransit = true;
	}

	public int RandomBehavior(int range)
	{
		return Random.Range(0, range);
	}

	public GameObject nextRoom()
	{
		Object[] listOfPlacedBuildings;
		listOfPlacedBuildings = GameObject.FindGameObjectsWithTag("Building");
		foreach (GameObject go in listOfPlacedBuildings)
		{
			if(!mMoodVisited)
				if(go.GetComponent<BuildingAI>().buildingType == BuildingTypes.Mind)
					{
							mMoodVisited = true;
							return go;
					}
			if(!bMoodVisited)
				if(go.GetComponent<BuildingAI>().buildingType == BuildingTypes.Body)
					{
							bMoodVisited = true;
							return go;
					}
			if(!sMoodVisited)
				if(go.GetComponent<BuildingAI>().buildingType == BuildingTypes.Spirit)
					{
							sMoodVisited = true;
							return go;
					}
		}
		return null;
	}
}
