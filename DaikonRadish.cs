using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaikonRadish : MonoBehaviour {

    public DetectDisplay display;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Guard")) {
            display.Decrement();
            other.gameObject.SetActive(false);
        }
    }
}
