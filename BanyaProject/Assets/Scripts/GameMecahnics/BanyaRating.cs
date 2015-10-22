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
	public static List<KimanRecord> visitedKimansRecords = KimanHandler.listofKimanRecords;

	// Use this for initialization
	void Start () {
		starYes = "Congratulations! Your banya has gained a star!\r\n";
		starNo = "Your banya did not gain any stars.\r\n";

		weeklyReport = starIncrease +
			"Here's how your banya is doing...\r\n" +
				banyaStars + " Star Banya\r\n" +
				"Total Kiman Guests: " + visitedKimansRecords.Count + "\r\n" +
				"Satisfaction rating: " + satisfaction + "%\r\n";
		
	}

	public static string WeeklyReport(string si, int bs, int kc, float sf){

		weeklyReport = si +
			"Here's how your banya is doing...\r\n" +
				bs + " Star Banya\r\n" +
				"Total Kiman Guests: " + kc + "\r\n" +
				"Satisfaction rating: " + (int)sf + "%\r\n";
		return weeklyReport;

	}
	
	// Update is called once per frame
	void Update () {

	}

	//calculates number of happy kiman and percentage of satisfied kiman
	public static void HappyKimans (){
		happyKimans = 0;
		foreach (KimanRecord kimanRecord in visitedKimansRecords){
			if (kimanRecord.joy >= 5){
				happyKimans++;
			}
		}
		satisfaction = (float)happyKimans / (float)visitedKimansRecords.Count * 100f;
	}

	//calculates banya star rating
	public static void CalculateRating (){
		HappyKimans (); 

		if (happyKimans >= visitedKimansRecords.Count * .8) {
			if (banyaStars < 5){
				if (banyaStars <4){
					banyaStars++;
					starIncrease = starYes;
				}
				else if (visitedKimansRecords.Count >= 500){
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
