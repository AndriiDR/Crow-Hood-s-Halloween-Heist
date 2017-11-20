using UnityEngine;
using System.Collections;

public class DetectDisplay : MonoBehaviour
{

    public float up; //how much the percentage increases or decreases per detection
    public float down;
    public Color col; //color of text
    public int txtSize = 30; //size of text

    private float count; //detection percentage
    private string disField; //textbox
    private GUIStyle myStyle = new GUIStyle();

    private void Start()
    {
        count = 0;
        myStyle.fontSize = txtSize;
        myStyle.normal.textColor = col;
    }

    private void OnGUI()
    {
        disField = GUI.TextField(new Rect(10, 10, 200, 20), count + "%", myStyle);
        //we can add another parameter for style of the text

    }

    public void Increment()
    {
        count += up;
        OnGUI();
    }

    public void Decrement()
    {
        count -= down;
        OnGUI();
    }

    public float getDetection()
    {
        return count;
    }

}

   
