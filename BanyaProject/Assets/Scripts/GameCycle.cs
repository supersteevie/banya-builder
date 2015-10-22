using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class GameCycle : MonoBehaviour {

	public float dayLength;
	public int weekLength;
	private float banyaTime;
	private float days;
	public string report;

	public GameObject dailyReport;
	public Text dailyText;
	public GameObject ratingReport;
	public Text ratingText;

	// Use this for initialization
	void Start () {
		banyaTime = Time.deltaTime;
		dailyReport.SetActive(false);
		ratingReport.SetActive(false);
		days = 1;

	}
	
	// Update is called once per frame
	void Update () {
		CycleTime();

		if (banyaTime >= dayLength) {
			CycleEnd();
		}

	}

	void CycleTime () {
		if (!dailyReport.activeInHierarchy && !ratingReport.activeInHierarchy) {
			banyaTime += Time.deltaTime;
		}
	}

	void CycleEnd () {
		if (days < weekLength) {
			DailyReport ();
			Debug.Log (banyaTime);
			banyaTime = Time.deltaTime;
			days++;
			Debug.Log (days);
		} else {
			RatingReport();
			days = 1;
			banyaTime = Time.deltaTime;

		}
	}

	//The daily report of the banya's stats
	void DailyReport () {
		dailyReport.SetActive(true);
		report = "Great work! Here's the report for the day!\r\n" +	"Number of Kiman: " + KimanHandler.listofKimanRecords.Count;
		dailyText.text = report;
	}

	//Report showing star rating of bathhouse
	void RatingReport (){
		ratingReport.SetActive(true);
		BanyaRating.CalculateRating ();
		ratingText.text = BanyaRating.WeeklyReport(BanyaRating.starIncrease, BanyaRating.banyaStars, KimanHandler.listofKimanRecords.Count, BanyaRating.satisfaction);

		
	}
}