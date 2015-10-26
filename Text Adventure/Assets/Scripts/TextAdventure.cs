using UnityEngine;
using System.Collections;

public class TextAdventure : MonoBehaviour {

	public string currentRoom = "entryway"; 
	public string 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (currentRoom == "entryway") 
		{
			GetComponent<TextMesh> ().text = "You are in the entryway.\n" +
				"There is a magic roomto the north";

			if (Input.GetKeyDown (KeyCode.N))
				currentRoom = "magicRoom";
			}
		} else if (currentRoom = "magicroom")
		{
			GetComponent<TextMesh>().text= "You are in the magic room.\n" +
			"there is an entryway to the south.";
			
			if (Input.GetKeyDown (KeyCode.s))
			{
				currentRoom = "entryway";
			}
		if(room_south !="")
		{
			textBuffer += "\nPress 'n' to go to the " +room_south + "."

	}
}

