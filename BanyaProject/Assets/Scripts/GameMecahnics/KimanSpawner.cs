using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KimanSpawner : MonoBehaviour {

	public static List<GameObject> listOfPlacedKimans = new List<GameObject>();
	public float coolDown;
	public GameObject basePrefab;

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
			coolDown -= Time.deltaTime;
			if(coolDown <= 0 && listOfPlacedKimans.Count < 5)
			{
				var clone = (GameObject)Instantiate(basePrefab, new Vector3(RandomSpawnLocation(20), 1, RandomSpawnLocation(20)), basePrefab.transform.rotation);
				listOfPlacedKimans.Add(clone);
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
		listOfPlacedKimans.Remove(go);
	}
}
