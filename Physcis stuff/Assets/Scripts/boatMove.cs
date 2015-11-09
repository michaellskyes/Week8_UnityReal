using UnityEngine;
using System.Collections;

public class boatMove : MonoBehaviour {

	public bool move;

	// Use this for initialization
	void Start () {
	
		move = false;
	}
	
	// Update is called once per frame
	void Update () {
	

		if(move)
		{
			transform.position +=transform.forward;
		}
	}
}
