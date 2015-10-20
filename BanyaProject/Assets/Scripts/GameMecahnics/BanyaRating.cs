using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class BanyaRating : MonoBehaviour {

	public GameObject inputReport;
	public Text inputText; 

	public static GameObject ratingReport;
	public static Text ratingText; 

	private int happyKimans;
	private int banyaStars;
	private float satisfaction;
	private static string weeklyReport;
	private string starIncrease;
	private string starNo;
	private string starYes;
	private List<GameObject> visitedKimans = KimanHandler.listOfVisitedKimans;

	// Use this for initialization
	void Start () {
		starYes = "Congratulations! Your banya has gained a star!";
		starNo = "Your banya did not gain any stars.";

		weeklyReport = "Here is how your banya is doing." +
			"Customer Satisfaction: " + satisfaction + "%" +
				starIncrease +
				"Your banya has " + banyaStars + " stars.";

		ratingReport = inputReport;
		ratingText = inputText;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//
	public static void RatingReport (){
		ratingText.text = weeklyReport;
		ratingReport.SetActive(true);

	}

	//calculates number of happy kiman and percentage of satisfied kiman
	void HappyKimans (){
		foreach (GameObject basePrefab in visitedKimans){
			if (basePrefab.GetComponent<KimanAI>().joy >= 9){
				happyKimans++;
			}
		}
		satisfaction = happyKimans / visitedKimans.Count * 100;
	}

	//calculates banya star rating
	void CalculateRating (){
		HappyKimans ();

		if (happyKimans >= visitedKimans.Count * .8) {
			if (banyaStars < 5){
				if (banyaStars <4){
					banyaStars++;
					starIncrease = starYes;
				}
				else if (visitedKimans.Count >= 500){
					banyaStars++;
					starIncrease = starYes;
				}
				else {
					starIncrease = starNo;
				}
			}
		}
	}
}
