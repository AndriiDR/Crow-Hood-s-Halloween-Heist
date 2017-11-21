using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour {

    public Rigidbody rb;
    public Player other;
    public int speed = 1;
    private IntVector2 pos1;
    private IntVector2 pos2;
    private IntVector2 pos3;
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



	void Start () { //we already have a Start method so this is a replacement
        g = GameObject.Find("Game Manager");
        m = GameObject.Find("Maze(Clone)");
		sizex = m.GetComponent<Maze>().size.x;
		sizez = m.GetComponent<Maze>().size.z;
		setSecond();
		setThird();
    }
	
	public void setFirst(IntVector2 pt){ //sets first point
    		pos1 = pt;
	}
	
	private int newDistance(int old){ //for example if -3 doesn't work then this gives you -2
    if(old<0){
        return old+1;
    }
    else{
        return old-1;
    }
}

public Vector3 toTransform(IntVector2 iv){ //converts intvector2 to vector3
	return new Vector3(iv.x - sizex * 0.5f + 0.5f, 0f, iv.z - sizez * 0.5f + 0.5f);
}

private void setSecond(){ //sets the second point
    int dist; //how far the second point can be from first
    if(Random.value<0.5f){
        dist = -3;
    }
    else{
        dist = -2;
    }
    bool determined = false; //is the second point okay?
    while(!determined){
        pos2 = pos1 + new IntVector2(0, dist);
        if(!m.GetComponent<Maze>().ContainsCoordinates(pos2)){ //is the second point in the maze?
            dist = newDistance(dist);
            if(dist == 0){ //we can't travel vertically in this direction
                pos2 = pos1;
                determined = true;
            }
        }
        else if(Physics.Linecast(toTransform(pos1), toTransform(pos2))){ //the first and second points are separated
			dist = newDistance(dist);
            if(dist == 0){ //we can't travel vertically in this direction
                pos2 = pos1;
                determined = true;
            }
		}
		else{
			determined = true;
		}
    }    
}

private void setThird(){
    int dist;
    if(Random.value<0.5f){
        dist = -3;
    }
    else{
        dist = -2;
    }
    bool determined = false;
    while(!determined){
        pos3 = pos1 + new IntVector2(dist, 0);
        if(!m.GetComponent<Maze>().ContainsCoordinates(pos3)){ //is the third point in the maze?
            dist = newDistance(dist);
            if(dist == 0){ //we can't travel horizontally in this direction
                pos3 = pos1;
                determined = true;
            }
        }
        else if(Physics.Linecast(toTransform(pos1), toTransform(pos3))){ //the first and second points are separated
			dist = newDistance(dist);
            if(dist == 0){ //we can't travel horizontally in this direction
                pos3 = pos1;
                determined = true;
            }
		}
		else{
			determined = true;
		}
    }	
}
	
	void Update () {
        otherpos = other.getPos();
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
                    g.Increment();
                }
            }
        }
		
		if(phase == 1){
			transform.position = Vector3.MoveTowards(pos2, speed * Time.deltaTime);
			if(transform.position == pos2){
				phase = 2;
			}
		}
		else if(phase == 2){
			transform.position = Vector3.MoveTowards(pos3, speed * Time.deltaTime);
			if(transform.position == pos3){
				phase = 3;
			}
		}
		else{
			transform.position = Vector3.MoveTowards(pos1, speed*Time.deltaTime);
			if(transform.position == pos1){
				phase = 1;
			}
		}
	}

    public void setOrigin (IntVector2 coord)
    {
        origin.x = coord.x;
        origin.z = coord.z;
    }
}
