using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class GameCycle : MonoBehaviour {

	public float dayLength;
	public int weekLength;
	public GameObject dailyReport;
	private float banyaTime;
	private float days;
	public Text popUp;

	// Use this for initialization
	void Start () {
		banyaTime = Time.deltaTime;
		dailyReport.SetActive(false);
		days = 0;

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
		if (days < weekLength) {
			DailyReport ();
			Debug.Log (banyaTime);
			banyaTime = Time.deltaTime;
			days++;
			Debug.Log (days);
		} else {
			BanyaRating.RatingReport();
			days = 0;
			banyaTime = Time.deltaTime;

		}
	}

	void DailyReport () {
		dailyReport.SetActive(true);
		string report = @"Great work! Here's the report for the day!
	Number of Kiman: 	" + KimanHandler.listOfTotalKimans.Count;
		popUp.text = report;
	}
}