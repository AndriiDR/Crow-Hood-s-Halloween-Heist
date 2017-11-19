using UnityEngine;
using System.Collections;

public class DetectDisplay : MonoBehaviour{

  private int count; //detection percentage

  private void Start(){
    count = 0;
  }

  private void OnGUI(){
    public string disField = GUI.TextField(new Rect(10, 10, 200, 20), count + "%"); 
                             //we can add another parameter for style of the text
    
  }
  
  public void Increment(){
    int count += 5;
    OnGUI();
  }
  
  public void Decrement(){
    int count -= 5;
    OnGUI();
  }

}

