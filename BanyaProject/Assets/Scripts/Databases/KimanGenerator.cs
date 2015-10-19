using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using UnityEditor;
using UnityEngine;

public class KimanGenerator
{
	
	public int idCounter = 0;
	
	public int NameIndex = 0;
	public int RaceOffset = 0;
	public int MaleNameOffset = 0;
	
	public int Id = 0;
	public int Age = 0;
	public int hgr = 0;
	public int ach = 0;
	public int trf = 0;
	public int tgh = 0;
	public int awe = 0;
	public int fun = 0;
	public int wallet = 0;
	public string Name = "";
	public string Race = "";
	public bool IsMale = false;
	public string wealthLevel = "";
	public int MoodLevel = 100;

	static string[] nameDB = { 
// Neo Columbian Men
		"Aaron", "Adam", "Alexander", "Andrew", "Anthony", "Austin",
		"Benjamin", "Brandon", "Brian",
		"Cameron", "Charles", "Christian", "Christopher", "Cody",
		"Daniel", "David", "Dylan", "Eric", "Hudson",
		"Jacob", "James", "Jason", "Jeremy", "John", "Jonathan",
		"Jordan", "Jose", "Joseph", "Joshua", "Justin",
		"Kevin", "Kyle",
		"Mark", "Matthew", "McKay", "Michael",
		"Nathan", "Nicholas", "Patrick",
		"Richard", "Robert", "Ryan",
		"Samuel", "Sean", "Stephen",
		"Thomas", "Timothy", "Tyler",
		"William", "Zack",
// Neo Columbian Women		
		"Abigail", "Alexandra", "Alexis", "Alice", "Allison",
		"Alyssa", "Amanda", "Amber", "Anna", "Ashley",
		"Brianna", "Brittany", "Chelsea", "Christina", "Clara", "Courtney",
		"Danielle", "Elizabeth", "Emily", "Haley", "Hannah", "Heather",
		"Jasmine", "Jennifer", "Jessica",
		"Kaitlyn", "Katherine", "Kayla", "Kelsey", "Kimberly",
		"Lindsay", "Madison", "Maria", "Mary", "Megan", "Melissa", 
		"Michelle", "Morgan", "Nicole", "Olivia",
		"Rachel", "Rebecca",
		"Samantha", "Sara", "Sarah", "Shelby", "Stephanie",
		"Taylor", "Tiffany", "Victoria",
// Bulvanian Men		
		"Abram", "Adam", "Albert", "Aleckis", "Aleksei",
		"Benedikt", "Borislav", "David", "Demyan", "Dmitriy",
		"Evgeny", "Faddey", "Feliks", "Feodor", "Fima",
		"Gennadi", "Georgiy", "Gerasim", "Grigory",
		"Isidor", "Klim", "Kolya", "Kostya",
		"Lazar", "Leonid", "Luka",
		"Maks", "Marlen", "Maxim", "Melor", "Misha",
		"Nazar", "Nika", "Nikom",
		"Oleg", "Pasha", "Radimir", "Rodion", "Rudolf",
		"Sasha", "Sergei", "Sevastian", "Stepan",
		"Tikhon", "Viktor", "Vlad", "Yasha", "Yuli",
		"Yuri", "Zakhar",
// Bulvanian Women		
		"Agnessa", "Alisa", "Anastasia", "Angelina", "Ania", "Arina",
		"Boleslava", "Darya", "Diana", "Dominika",
		"Elena", "Eva", "Fedora", "Gala",
		"Inga", "Inna", "Irina", "Isidora", "Ivanna",
		"Karina", "Katerina", "Kira",
		"Lana", "Larisa", "Lidiya", "Lilia", "Luba",
		"Manya", "Marina", "Masha", "Milena",
		"Nadya", "Natalya", "Natasha", "Nina",
		"Olga", "Petia", "Roza",
		"Sabina", "Sasha", "Selena", "Sofiya", "Syuzanna",
		"Tanya", "Tatiyana", "Uliana","Valentina",
		"Yana", "Yulianna", "Zhana",
// Henponese Men
		"Akio", "Akira", "Ayumu", "Chao",
		"Daiki", "Dong", "Gorou", "Haru", "Hiroto",
		"Ichiro", "Jing", "Jiro", 
		"Kaito", "Katashi", "Katsu", "Kazuki",
		"Kenji", "Kenshi", "Kichiro", "Kuro", "Kyo",
		"Li", "Makoto", "Noboru", "Nori", "Osama",
		"Riku", "Rokoro", "Ryo",
		"Sa-Do", "Saburo", "Shi", "Shin", "Shiori", "Sho", "Shota",
		"Tai", "Taiki", "Takashi", "Taro", "Toshiro", "Tsubasa",
		"Xiang", "Yi", "Yong", "Yori", "Yoshi", "Yuu", "Zheng", "Zhi",
// Henposese Women
		"Aiko", "Aimi", "Akemi", "Asuka", "Ayano",
		"Chika", "Chiyo", "Cho", "Chun-Li",
		"Emi", "Etsuko",
		"Hana", "Haru", "Haruka", "Hina", "Honoka", "Hoshi",
		"Izumi", "Junko",
		"Kanon", "Kasumi", "Kazuko", "Kiku", "Kiyoku", "Kokoro", "Kyo",
		"Mai", "Mami", "Masuyo", "Mayu", "Michiko",
		"Mika", "Miki", "Minako", "Naomi",
		"Ran","Riko", "Rio",
		"Sakura", "Shinju", "Shizuka", "Sora", "Suzu",
		"Takara", "Tomiko", "Wakana",
		"Yoko", "Yoshiko", "Yui", "Yuzuki",
// Nordic Men
		"Adolf", "Albert", "Alf", "Alvis",
		"Balder", "Bernhard", "Bjorn", "Christofer", "Dagfinn", 
		"Edvard", "Edvin", "Elias", "Emil", "Enok", "Erling",
		"Felix", "Floki", "Fredrik",
		"Gandalf", "Georg", "Gunnar", "Gustav",
		"Halldor", "Hugo", "Johan", "Jorg",
		"Kasper", "Klaus", "Konrad", "Kristian", "Kristoff",
		"Lars", "Linus", "Loke", "Lorens",
		"Matteus", "Maximilian", "Mikael", "Morten",
		"Njord", "Oden", "Olaf", "Orvar", "Per",
		"Samuel", "Sigurd", "Sindri",
		"Thor", "Vidar", "Viggo",
// Nordic Women
		"Agatha", "Agnes", "Anna", "Asa",
		"Beata", "Birgitta", "Brita", "Brynja",
		"Camilla", "Carina", "Caroline", "Cecilie", "Charlotte", "Corrie",
		"Dagmara", "Dorothea", "Edith", "Eli", "Ella",
		"Ellinor", "Elsa", "Emilia", "Frida",
		"Gerda", "Gerta", "Gina", "Gunda",
		"Hanna", "Heidi", "Helena", "Helga",
		"Ingrid", "Isabella", "Johanna", "Julia",
		"Karen", "Laila", "Lena", "Linda",
		"Margrethe", "Marianne", "Mathilde", "Monika", "Nora", 
		"Rosa", "Ruth", "Teresa", "Ursula", "Vera", "Viola"
	};

	public KimanGenerator()
	{
		string[] race = { "Neo Columbian", "Bulvanian", "Hanponese", "Nordic" };

		Id = idCounter++;
		Race = race[RandomNumber(0, 4)];
		IsMale = (RandomNumber(0, 1)) > 0 ? false : true;
		Age = RandomNumber(13, 91);
		hgr = RandomNumber(1, 6);
		ach = RandomNumber(1, 6);
		trf = RandomNumber(1, 6);
		tgh = RandomNumber(1, 6);
		awe = RandomNumber(1, 6);
		fun = RandomNumber(1, 6);
		wallet = RandomNumber(100, 2001);
		if (wallet <= 500)
			wealthLevel = "Poor";
		else if (wallet <= 1000)
			wealthLevel = "Middle Class";
		else if (wallet <= 1500)
			wealthLevel = "Well Off";
		else
			wealthLevel = "High Roller";
		NameIndex = RandomNumber(0, 50);
//		if (Race == "Neo Columbian")
//		{
//			RaceOffset = 0;
//			hgr -= 5;
//			ach += 10;
//			trf -= 10;
//		 	awe += 10;
//			fun -= 10;
//		}
//
//		else if (Race == "Bulvanian")
//		{
//			RaceOffset = 100;
//			hgr += 10;
//			ach -= 5;
//			trf -= 5;
//			tgh += 10;
//			awe -= 5;
//			fun -= 5;
//		}
//
//		else if (Race == "Hanponese")
//		{
//			RaceOffset = 200;
//			hgr += 5;
//			trf -= 5;
//			tgh += 10;
//			awe -= 20;
//			fun += 5;
//		}
//
//		else 
//		{
//			RaceOffset = 300;
//			hgr -= 10;
//			tgh += 10;
//			fun -= 5;
//		}

		if (!IsMale)
			MaleNameOffset = 1;

		Name = nameDB[NameIndex + RaceOffset + MaleNameOffset * 50];

	}

	static private int RandomNumber(int min, int max)
	{
		System.Random random = new System.Random();
		return random.Next(min, max); 
	}
}