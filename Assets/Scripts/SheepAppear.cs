using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAppear : MonoBehaviour {
    GameManager GM;
    public Sprite Sheep;
    public SpriteRenderer SR;
	// Use this for initialization
	void Awake () {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
		if (GM.completed == true)
        {
            SR.sprite = Sheep;
        }
	}
}
