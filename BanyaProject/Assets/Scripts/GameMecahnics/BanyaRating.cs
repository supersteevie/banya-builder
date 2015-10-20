using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class BanyaRating : MonoBehaviour {

	public static string weeklyReport;
	public static int happyKimans;
	public static int banyaStars;
	public static float satisfaction;
	public static string starIncrease;
	public static string starNo;
	public static string starYes;
	public static List<GameObject> visitedKimans = KimanHandler.listOfVisitedKimans;

	// Use this for initialization
	void Start () {
		starYes = "Congratulations! Your banya has gained a star!\r\n";
		starNo = "Your banya did not gain any stars.\r\n";

		weeklyReport = starIncrease +
			"Here's how your banya is doing...\r\n" +
				banyaStars + " Star Banya\r\n" +
				"Total Kiman Guests: " + visitedKimans.Count + "\r\n" +
				"Satisfaction rating: " + satisfaction + "%\r\n";
		
	}

	public static string WeeklyReport(string si, int bs, int kc, float sf){
		weeklyReport = si +
			"Here's how your banya is doing...\r\n" +
				bs + " Star Banya\r\n" +
				"Total Kiman Guests: " + kc + "\r\n" +
				"Satisfaction rating: " + sf + "%\r\n";
		return weeklyReport;

	}
	
	// Update is called once per frame
	void Update () {

	}

	//calculates number of happy kiman and percentage of satisfied kiman
	public static void HappyKimans (){
		foreach (GameObject basePrefab in visitedKimans){
			if (basePrefab.GetComponent<KimanAI>().joy >= 9){
				happyKimans++;
			}
			Debug.Log (happyKimans);
		}
		satisfaction = happyKimans / visitedKimans.Count * 100;
	}

	//calculates banya star rating
	public static void CalculateRating (){
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
				Debug.Log(banyaStars);
			}
		}
	}
}
