using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class GameCycle : MonoBehaviour {

	public float dayLength;
	public GameObject dailyReport;
	private float banyaTime;
	//private int totalGuests;
	public Text popUp;
	//private Button closeReportBtn;
	//private UnityEvent closeReport;

	/*
	public float BanyaTime
	{
		get
		{
			banyaTime += Time.deltaTime;
			return banyaTime;
		}
	}
	*/

	// Use this for initialization
	void Start () {
		banyaTime = Time.deltaTime;
		//popUp = GameObject.FindGameObjectWithTag("report");
		//popUp = dailyReport.GetComponentInChildren<Text>();
		dailyReport.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		CycleTime();

		if (banyaTime >= dayLength) {
			CycleEnd();
		}

	}

	void CycleTime () {
		if (!dailyReport.activeInHierarchy)
			banyaTime += Time.deltaTime;
	}

	void CycleEnd () {
		DailyReport();
		Debug.Log (banyaTime);
		banyaTime = Time.deltaTime;

	}

	void DailyReport () {
		//totalGuests = KimanSpawner.listOfPlacedKimans.GetRange();
		dailyReport.SetActive(true);
		string report = @"Great work! Here's the report for the day!
	Number of Kiman: 	" + KimanSpawner.listOfPlacedKimans.Count;
		popUp.text = report;
	}
}

/*
 * If cylce time >= 180 seconds
 * Then {
 * 		Pop up GUI reporting numbers
 * 		On GUI close

	*/
