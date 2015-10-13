using UnityEngine;
using System.Collections;


///
///
/// 
/// 
///
/// 						DRIVER GUI
/// 
/// 
/// 
/// 
/// 
/// 
/// 
public class testGUI : MonoBehaviour {

	private Texture2D butIcon;
	// Use this for initialization
	void OnGUI()
	{
			butIcon = BuildingBase.Get(1).Icon;
			if(GUI.Button(new Rect(Screen.width*.1f, Screen.height*.75f, Screen.width*.10f, Screen.height*.10f), butIcon))
			{
				if(gameObject != null)
				{
					
					GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Building>().SetTransObject(BuildingBase.Get (1).Name);
					GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Building>().SetBaseObject(BuildingBase.Get (1).Name);
					GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Building>().TurnOnPlacing();
				}
			}
			butIcon = BuildingBase.Get(2).Icon;
			if(GUI.Button(new Rect(Screen.width*.35f, Screen.height*.75f, Screen.width*.10f, Screen.height*.10f), butIcon))
			{
				if(gameObject != null)
				{
					
					GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Building>().SetTransObject(BuildingBase.Get (2).Name);
					GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Building>().SetBaseObject(BuildingBase.Get (2).Name);
					GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Building>().TurnOnPlacing();
				}
			}
			butIcon = BuildingBase.Get(3).Icon;
			if(GUI.Button(new Rect(Screen.width*.60f, Screen.height*.75f, Screen.width*.10f, Screen.height*.10f), butIcon))
			{
				if(gameObject != null)
				{
					
					GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Building>().SetTransObject(BuildingBase.Get (3).Name);
					GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Building>().SetBaseObject(BuildingBase.Get (3).Name);
					GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Building>().TurnOnPlacing();
				}
			}

			if(GUI.Button(new Rect(10,10,200,50), "Quit to Menu"))
				Application.LoadLevel("StartMenu");
	}
}
