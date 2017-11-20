using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour {

    public Rigidbody rb;

    private Player other;

    private DetectDisplay display;

    private float dist;

    private float detection;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        detection = display.getDetection();
        if (Physics.Linecast(transform.position, other.getPos()))
        {
            dist = Vector3.Distance(transform.position, other.getPos());
            if (dist < 5f && dist * Mathf.Cos((0.19444f + 0.27778f * detection / 100) * Mathf.PI) > 5f * Mathf.Cos((0.19444f + 0.27778f * detection / 100) * Mathf.PI))
            { //the number multiplied by detection will increase the original angle from 35 degrees to 75 degrees at approx 80% detection
                display.Increment();
            }
        }
	}
}
