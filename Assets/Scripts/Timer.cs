using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {
    GameManager GM;
    Text CounterText;
    float RoundedTime;
	// Use this for initialization
	void Start () {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        CounterText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        RoundedTime = GM.seconds - GM.Timer;
        RoundedTime = Mathf.Round(RoundedTime * 100f) / 100f;
        CounterText.text = (RoundedTime.ToString());
    }
}
