using UnityEngine;
using System.Collections;

public class DetectDisplay : MonoBehaviour
{

    public float val; //how much the percentage increases or decreases per detection
    private float count; //detection percentage
    private string disField; //textbox

    private void Start()
    {
        count = 0;
    }

    private void OnGUI()
    {
        disField = GUI.TextField(new Rect(10, 10, 200, 20), count + "%");
        //we can add another parameter for style of the text

    }

    public void Increment()
    {
        count += val;
        OnGUI();
    }

    public void Decrement()
    {
        count -= val;
        OnGUI();
    }

    public float getDetection()
    {
        return count;
    }
}
