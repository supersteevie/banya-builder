using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour {

	//If no saved files are found, load the new game level.
	//Display "Select Player"
	//Load and Display Array of Saved Characters
	//GUI displayed in IDs
	//	If SavedChar[i].race=race[0]
	//		SavedChar[i].GUITexture = idCard.texture[0];
	//	Else if SavedChar[i].race = race[1]
	//		SavedChar[i].GUITexture = idCard.texture[1];
	//	Else if SavedChar[i].race = race[2]
	//		SavedChar[i].GUITexture = idCard.texture[2];
	//	Else if SavedChar[i].race = race[3]
	//		SavedChar[i].GUITexture = idCard.texture[3];
	//	Else
	//		SavedChar[i].GUITexture = idCard.texture[4];
	//If SavedChar.Length.TextureHeight > screen.height
	//	Allow OnMouseDrag();
	//	Display down arrow texture to indicate more saved characters
	//
	//OnMouseDrag
	//	Move display of idCards
	//OnMouseClick
	//	Load saved character and run BanaySelect script
	//
	//Display "New Character Button"
	//	Load NewGame level
	//
	//Display "Back" button
	//
	//
	//SavedCharID ()
	//	Display string Name
	//	Display string Eyes
	//	Display "Level" + int Level
	//	Display DuxImage + int DuxAmount
}
