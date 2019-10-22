using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterText : MonoBehaviour {
    GameManager GM;
    Text ChapText;
    bool Updated = false;
	// Use this for initialization
	void Start () {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        ChapText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Updated == false)
        {
            ChapText.text = ("Chapter " + GM.Level);
            Updated = true;
        }
	}
}
