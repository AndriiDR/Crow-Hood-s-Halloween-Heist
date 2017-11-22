using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour {

    public Rigidbody rb;
    public Player other;
    public int speed = 1;
    private IntVector2 pos1;
    private IntVector2 pos2;
	
    private Vector3 transf1;
    private Vector3 transf2;
	
    private int sizex;
    private int sizez;
    private int phase = 1;
    private GameObject m; // will contain the maze object
    private IntVector2 origin; 
    private GameObject g;
    private Vector3 otherpos;
    private float dist;
    private float detection;
    private bool track;



	void Start () {
        g = GameObject.Find("Game Manager");
        m = GameObject.Find("Maze(Clone)");
		sizex = m.GetComponent<Maze>().size.x;
		sizez = m.GetComponent<Maze>().size.z;
		transf1 = toTransform(pos1);
		transf2 = toTransform(pos2);
    }
	
	public void setFirst(IntVector2 pt){ //sets first point
    	pos1 = pt;
	}
	
	public void setSecond(IntVector2 pt){
		pos2 = pt;
	}

	public Vector3 toTransform(IntVector2 iv){ //converts intvector2 to vector3
		return new Vector3(iv.x - sizex * 0.5f + 0.5f, 0f, iv.z - sizez * 0.5f + 0.5f);
	}
	
	void Update () {
       otherpos = other.transform.position;
        if (track)
        {
            while (Physics.Linecast(transform.position, otherpos)) {
                Vector3 localPosition = otherpos - transform.position;
                localPosition = localPosition.normalized; // The normalized direction in LOCAL space
                transform.Translate(localPosition.x * Time.deltaTime * 3f, 0f, localPosition.z * Time.deltaTime * 3f);
            }
            if (!(Physics.Linecast(transform.position, otherpos)))
            {

            }
        }
        else
        {
            detection = g.GetComponent<DetectDisplay>().getDetection();
            if (Physics.Linecast(transform.position, otherpos))
            {
                dist = Vector3.Distance(transform.position, otherpos);
                if (dist < 5f && dist * Mathf.Cos((0.19444f + 0.27778f * detection / 100) * Mathf.PI) > 5f * Mathf.Cos((0.19444f + 0.27778f * detection / 100) * Mathf.PI))
                { //the number multiplied by detection will increase the original angle from 35 degrees to 75 degrees at approx 80% detection
                    g.GetComponent<DetectDisplay>().Increment();
                }
            }
        }
		
		if(phase == 1){
			transform.position = Vector3.MoveTowards(transform.position, transf2, speed * Time.deltaTime);
			if(transform.position == transf2){
				phase = 2;
			}
			Quaternion rotation = Quaternion.LookRotation(transf2);
			transform.rotation = rotation;
		}
		else{
			transform.position = Vector3.MoveTowards(transform.position, transf1, speed * Time.deltaTime);
			if(transform.position == transf1){
				phase = 1;
			}
			Quaternion rotation = Quaternion.LookRotation(transf1);
			transform.rotation = rotation;
		}
	}

    public void setOrigin (IntVector2 coord)
    {
        origin.x = coord.x;
        origin.z = coord.z;
    }
}
