using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTouch : MonoBehaviour {
    GameManager GM;
    public Sprite B2;
    SpriteRenderer SR;
	// Use this for initialization
	void Awake () {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        SR = GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
		if (GM.completed == true)
        {
            SR.sprite = B2;
        }
	}
}
