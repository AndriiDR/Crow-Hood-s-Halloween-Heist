/** Attach this to the GameManager object
	When you're picking the color of variable "col", make sure that the "A" bar at the bottom is set to 255!
	All the candies should have a "candy" tag.
	The samurai should be a trigger; it's not necessary for the candies to be.**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyTracker : MonoBehaviour {
	
	public Color col; //color of text
	public int txtSize = 30; //size of text
	
	private int count; //candy collected
	private string display;
	private GUIStyle myStyle = new GUIStyle();
	
	
	// Use this for initialization
	void Start () {
		count = 0;
		myStyle.fontSize = txtSize;
		myStyle.normal.textColor = col;

	}
	
	private void OnGUI(){
		display = GUI.TextField(new Rect(750, 10, 50, 20), count.ToString(), myStyle); 
    
  }
  
	public void addCandy(){
		count++;
		OnGUI();
	}
	
	public void subtractCandy(){
		count--;
		OnGUI();
	}
}