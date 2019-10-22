using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyDivePlayer : MonoBehaviour {
    Rigidbody2D RB2D;
    float H, V;
    // Use this for initialization
    void Awake () {
        RB2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        H = Input.GetAxis("Horizontal");
        V = Input.GetAxis("Vertical");
        RB2D.velocity = new Vector3(H * 2, V * 2, 0);
    }
}
