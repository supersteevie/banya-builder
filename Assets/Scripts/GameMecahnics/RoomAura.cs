using UnityEngine;
using System.Collections;

public class RoomAura : MonoBehaviour {

	public static int auraTotal;
	public GameObject[] roomSpace;

	public void AuraTotal() {
		//auraTotal = IncreaseAWE + IncreaseACH + IncreaseFUN + IncreaseHGR + IncreaseTRF + IncreaseTHG;
		roomSpace = GameObject.FindGameObjectsWithTag("BasePrefab");
		auraTotal *= roomSpace.Length;

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
