using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KimanAI : MonoBehaviour {


	public float tempSpeed = .01f;
	public GameObject targetBuilding;
	public GameObject lastBuilding;
	public Vector3 targetLocation;
	public Vector3 rotationLook;
	public float proxy;
	public bool inTransit = false;
	public bool usingBuilding = false;
	public bool isLeaving = false;
	public bool visitedABuilding = false;
	public float actionTimer;

	public int Id;	
	public string Name;
	public string Race;
	public bool isMale;
	public int age;
	public int hgr;
	public int ach;
	public int trf;
	public int awe;
	public int fun;
	public int wallet;
	public string wealthLevel;	
	public int moodLevel;

	// Use this for initialization
	void Start () {
		KimanGenerator kiman = new KimanGenerator ();
		Id = kiman.Id;
		Name = kiman.Name;
		Race = kiman.Race;
		isMale = kiman.IsMale;
		age = kiman.Age;
		hgr = kiman.hgr;
		ach = kiman.ach;
		trf = kiman.trf;
		awe = kiman.awe;
		fun = kiman.fun;
		wallet = kiman.wallet;
		wealthLevel = kiman.wealthLevel;
		moodLevel = kiman.MoodLevel;
	}
	
	// Update is called once per frame
	void Update () {
		Object[] listOfPlacedBuildings;
		listOfPlacedBuildings = GameObject.FindGameObjectsWithTag("Building");


		if(listOfPlacedBuildings.Length != 0 && !inTransit && !usingBuilding && !isLeaving)
		{
			if(moodLevel <= 20 && visitedABuilding)
			{
				isLeaving = true;
				KimanLeave();
			}
			else{
				do{targetBuilding = listOfPlacedBuildings[RandomBehavior(listOfPlacedBuildings.Length)] as GameObject;}
					while(targetBuilding == lastBuilding);

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
				ach += lastBuilding.GetComponent<BuildingAI>().GetIncreaseACH();
				hgr += lastBuilding.GetComponent<BuildingAI>().GetIncreaseHGR();
				trf += lastBuilding.GetComponent<BuildingAI>().GetIncreaseTRF();
				awe += lastBuilding.GetComponent<BuildingAI>().GetIncreaseAWE();
				fun += lastBuilding.GetComponent<BuildingAI>().GetIncreaseFUN();
			}
		}

		if(isLeaving && inTransit)
		{
			transform.Translate(new Vector3(0,0,tempSpeed));
			if(transform.position.x > 20 || transform.position.z > 20 || transform.position.x < -20 || transform.position.z < -20)
			{
				GameObject.FindGameObjectWithTag("MainCamera").GetComponent<KimanSpawner>().RemoveKiman(this.gameObject);
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
}
