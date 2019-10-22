using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour {
    Rigidbody2D RB2D;
    public float rayDistance = 1;
    // Use this for initialization
    void Awake () {
        RB2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetAxis("A") == 1)
        {
            RB2D.AddForce(new Vector3(0, 10, 0), ForceMode2D.Impulse);
        }
    }
}
