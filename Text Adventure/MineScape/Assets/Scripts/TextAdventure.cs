using UnityEngine;
using System.Collections;

public class TextAdventure : MonoBehaviour {

	public string currentRoom = "zenith";
	public Camera myCamera;

	[Header("Audio stuff")]



	public AudioSource bgm;
	public AudioClip scaryMusic;

	public AudioSource sfx;
	public AudioClip sfx_keyGet;
	public AudioClip sfx_partyHorn;
	public AudioClip sfx_bgmWin;


	[Header("rooms")]
	public string room_newsPaper;
	public string room_entrance; 
	public string room_north;
	public string room_south;
	public string room_east;
	public string room_west;

//	private int currentExperience = 0;
//	private int expToLevel = 10;
//	private int level = 0;

	private bool hasKey = false;

	private bool hasNote = false;
	
	private bool roomEntered = false;

	private bool won = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		string textBuffer = "";
		room_north = "";
		room_south = "";
		room_west = "";
		room_east = "";

		switch (currentRoom)
		{
		
		case "mineshaft":
			textBuffer = "The wall structure collapses behind you.\n"+
				"You are trapped in the mine.\n"+
				"You are in the main mine shaft.\n"+
				"It's dark, but you take out a torch.\n"+
				"There is a sub shaft on the left and the right.\n"+
				"You can also go deeper in the main mine shaft.";
			room_west = "blocked off shaft";
			room_east = "subshaft left";
			room_north = "deep shaft"; 
			break;

		case "subshaft left":
			textBuffer = "This shaft leads you to the workers quarters\n"+
				"There's a couch in the centers\n" +
				"that's been disentergrated\n"+
				"you find a note\n"+
				"to read it press 'n'";

			room_west = "mineshaft";

					if (Input.GetKeyDown(KeyCode.N))
				{
					currentRoom = "note";
				}
			
			room_east = "deep shaft";
			break;

		case "note":
			textBuffer = "if you find this note\n"+
				"get out of the shaft now!\n"+
				"there was no arson that set the fire\n"+
				"we dug into an indian burial ground\n"+
				"people started getting sick...\n"+
				"they turned agressive and started killing\n" +
				"each other\n"+
				"LEAVE NOW";

			if (!hasNote)
			{
				hasNote = true;
				sfx.clip = sfx_keyGet;
				sfx.Play();
			}

			room_south = "subshaft left";
			break;

		case "deep shaft":
			textBuffer = "You are deeper down the shaft\n"+
				"You see embers in a fire pit.\n"+
				"After closer examination, it seems as if\n"+
				"the fire was put out a few hours ago\n"+
					"...'is someone living here?'...";

			room_east = "equipment room";
			room_south = "mineshaft";
			break;

		case "equipment room":
			textBuffer = "You find a locker with a broken lock.\n"+
				"To break it open press 'M'.";


			if (Input.GetKeyDown(KeyCode.M))
			{
				currentRoom = "got pickaxe";
			}

			room_east = "deep shaft";

			break; 
		case "newsPaper":
			textBuffer = "67 MINERS DIE IN MINE FIRE\n"+
				"Date October 21st 1952\n"+
				"Workers inside Zenith Coal Mine were\n"+
				"burned alive when the mine was set a blaze\n"+
				"by an arson\n"+
				"Local authorities could not\n"+
				"identify a suspect...";

				room_south = "entrance";

			break;
		case "entryway":
			textBuffer = "Welcome to Zenith Coal Mines.\n"+
				"Date: October 21st 2015 Time: 2:00 AM\n"+
					"you are a journalist trying to uncover the truth"; 
				
			room_north = "entrance";

			roomEntered = true;

			break;
		case "entrance":

			textBuffer = "You are at the entrance.\n"+
				"There's a warning sign that reads\n"+
				"ABANDONED:DO NOT ENTER\n"+
				"You find a newspaper snippet on the floor\n"+
				"press 'n' to read the newspaper\n"+
				"or 'm' to enter the mine";
		
			if (Input.GetKeyDown(KeyCode.N))
			{
				currentRoom = "newsPaper";
			}

			if(Input.GetKeyDown(KeyCode.M))
			{
				currentRoom = "mineshaft";
			}
			break;

		case "got pickaxe":
			textBuffer = "You find a pickaxe! \n" +
				"Looks like this might come in handy.\n" +
					"To leave. (press any key)";

			if (!hasKey)
			{
				hasKey = true;
				sfx.clip = sfx_keyGet;
				sfx.Play();
			}

			if (Input.anyKeyDown)
			{
				currentRoom = "equipment room";
			}
					
			break;

		case "blocked off shaft":
			if (hasKey && hasNote)
			{
				textBuffer = "You use the pickaxe to break\n" +
					"through the debris.";

				room_south = "Exit";
			} else {

				textBuffer = "This way is blocked by debris,\n"+
					"you need a pick axe to get through\n"+
						"press any key to go back";

				if (Input.anyKeyDown)
				{
					currentRoom = "mineshaft";
				}

			}

			break;
		case "Exit":
			textBuffer = "You made it out alive!\n" +
				"You have the note, and the truth\n" +
					"You won!";
	

			if (!won)
			{
				sfx.clip = sfx_bgmWin;
				sfx.Play();
				won = true;
			}

			bgm.clip = scaryMusic;
			if(!bgm.isPlaying)
			{
				bgm.Play ();
			}


			break;
		default:
			break;

		}

		if (room_north != "")
		{
			textBuffer += "\nPress 'n' to go to the " + room_north + ".";

			if(Input.GetKeyDown(KeyCode.N))
			{
				currentRoom = room_north;
				roomEntered = false;
			}

		}
		if (room_south != "")
		{
			textBuffer += "\nPress 's' to go to the " + room_south + ".";
			
			if(Input.GetKeyDown(KeyCode.S))
			{
				currentRoom = room_south;
				roomEntered = false;
			}
		}
		if (room_east != "")
		{
			textBuffer += "\nPress 'e' to go to the " + room_east + ".";
			
			if(Input.GetKeyDown(KeyCode.E))
			{
				currentRoom = room_east;
				roomEntered = false;
			}
		}
		if (room_west != "")
		{
			textBuffer += "\nPress 'w' to go to the " + room_west + ".";
			
			if(Input.GetKeyDown(KeyCode.W))
			{
				currentRoom = room_west;
				roomEntered = false;
			}
		}


		GetComponent<TextMesh>().text = textBuffer;

	}
}
