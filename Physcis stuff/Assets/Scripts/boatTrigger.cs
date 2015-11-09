using UnityEngine;
using System.Collections;

public class boatTrigger : MonoBehaviour {

	public boatMove myboat;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}
	void OnTriggerEnter(Collider other) {
		myboat.move = true;
	}
}
