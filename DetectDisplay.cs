using UnityEngine;
using System.Collections;

public class DetectDisplay : MonoBehaviour{

  public int val; //how much the percentage increases or decreases per detection
  public Color col; //color of text
  public int txtSize = 30; //size of text
  
  private int count; //detection percentage
  private string disfield; //textbox
  private GUIstyle myStyle = new GUIStyle();

  private void Start(){
    count = 0;
	myStyle.fontSize = txtSize;
	myStyle.normal.textColor = col;
  }

  private void OnGUI(){
    disField = GUI.TextField(new Rect(10, 10, 200, 20), count + "%", myStyle); 
                             //we can add another parameter for style of the text
    
  }
  
  public void Increment(){
    count += val;
    OnGUI();
  }
  
  public void Decrement(){
    count -= val;
    OnGUI();
  }
    
     public float getDetection()
    {
        return count;
    }

}
   
