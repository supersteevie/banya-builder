using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KimanHandler : MonoBehaviour {

	public static List<GameObject> listOfTotalKimans = new List<GameObject>();
	public static List<KimanRecord> listofKimanRecords = new List<KimanRecord>();
	public float coolDown;
	public GameObject basePrefab;
	public bool isMind;
	public bool isBody;
	public bool isSpirit;
	public bool canSpawn = false;

	void Start()
	{
		coolDown = RandomBehavior(5);
		basePrefab = Resources.Load("Kimans", typeof(GameObject)) as GameObject;
	}

	void Update () {
		Object[] listOfPlacedBuildings;
		listOfPlacedBuildings = GameObject.FindGameObjectsWithTag("Building");



		if(listOfPlacedBuildings.Length != 0)
		{
			foreach (GameObject go in listOfPlacedBuildings)
			{
				if(go.GetComponent<BuildingAI>().buildingType == BuildingTypes.Mind)
				{
					isMind = true;
				}
				if(go.GetComponent<BuildingAI>().buildingType == BuildingTypes.Body)
				{
					isBody = true;
				}
				if(go.GetComponent<BuildingAI>().buildingType == BuildingTypes.Spirit)
				{
					isSpirit = true;
				}
			}

			coolDown -= Time.deltaTime;
			if(coolDown <= 0 && listOfTotalKimans.Count < 5 && isMind && isBody && isSpirit)
			{
				var clone = (GameObject)Instantiate(basePrefab, new Vector3(RandomSpawnLocation(20), 1, RandomSpawnLocation(20)), basePrefab.transform.rotation);
				listOfTotalKimans.Add(clone);
				coolDown = RandomBehavior(5);
			}
		}
	}

	public int RandomBehavior(int range)
	{
		range += 5;
		return Random.Range(5, range);
	}

	public float RandomSpawnLocation(int range)
	{
		return (float)Random.Range (-range, range);
	}

	public void RemoveKiman(GameObject go)
	{
		listOfTotalKimans.Remove(go);
		listofKimanRecords.Add(new KimanRecord
		{
			Id = go.GetComponent<KimanAI>().Id,
			Name = go.GetComponent<KimanAI>().name,
			ach = go.GetComponent<KimanAI>().ach,
			tgh = go.GetComponent<KimanAI>().tgh,
			awe = go.GetComponent<KimanAI>().awe,
			wallet = go.GetComponent<KimanAI>().wallet,
			Race = go.GetComponent<KimanAI>().Race,
			joy = go.GetComponent<KimanAI>().joy,
			mMood = go.GetComponent<KimanAI>().mMood,
			sMood = go.GetComponent<KimanAI>().sMood,
			bMood = go.GetComponent<KimanAI>().bMood,
		});
	}
}
