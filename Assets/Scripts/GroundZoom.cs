using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundZoom : MonoBehaviour {
    public float speed;
    float x, y;
    Transform Trans;
    // Use this for initialization
    void Awake () {
        Trans = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        x = Trans.localScale.x;
        y = Trans.localScale.y;
        x = x + speed;
        y = y + speed;
        Trans.localScale = new Vector3(x,y,0);
	}
}
