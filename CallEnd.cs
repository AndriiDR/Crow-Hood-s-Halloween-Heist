using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEnd : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		if (winCondition () == true) {
			Application.LoadLevel ("EndGame");
		}
	}

	public bool winCondition(){
		if(){
			return true;
	}
}
