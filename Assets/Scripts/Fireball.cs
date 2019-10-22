using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
    Rigidbody2D RB2D;
    public int speed;
	// Use this for initialization
	void Awake () {
        RB2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        RB2D.velocity = new Vector3(speed, 0, 0);
	}
}
