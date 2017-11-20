using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour {

    public Rigidbody rb;

    private IntVector2 origin;

    public Player other;

    private DetectDisplay g;

    private Vector3 otherpos;

    private float dist;

    private float detection;

    private bool track;


	// Use this for initialization
	void Start () {
        g = g.GetComponent<DetectDisplay>();
	}
	
	// Update is called once per frame
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
            detection = g.getDetection();
            if (Physics.Linecast(transform.position, otherpos))
            {
                dist = Vector3.Distance(transform.position, otherpos);
                if (dist < 5f && dist * Mathf.Cos((0.19444f + 0.27778f * detection / 100) * Mathf.PI) > 5f * Mathf.Cos((0.19444f + 0.27778f * detection / 100) * Mathf.PI))
                { //the number multiplied by detection will increase the original angle from 35 degrees to 75 degrees at approx 80% detection
                    g.Increment();
                }
            }
        }
	}

    public void setOrigin (IntVector2 coord)
    {
        origin.x = coord.x;
        origin.z = coord.z;
    }
}
