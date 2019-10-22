using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboTxt : MonoBehaviour {
    TreeCutter TC;
    Text TXT;
	// Use this for initialization
	void Awake () {
        TC = GameObject.Find("Controller").GetComponent<TreeCutter>();
        TXT = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        TXT.text = ("Combo X " + TC.hits.ToString());
	}
}
