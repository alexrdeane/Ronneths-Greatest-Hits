using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour {
    GameManager GM;
    public Sprite B2;
    SpriteRenderer SR;
    // Use this for initialization
    void Start () {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        SR = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GM.Timer > 1f)
        {
            SR.sprite = B2;
        }
    }
}
