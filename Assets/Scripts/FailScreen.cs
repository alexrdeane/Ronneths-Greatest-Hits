using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailScreen : MonoBehaviour {
    public GameManager GM;
    public float counter;
    Text Prompt;
	// Use this for initialization
	void Awake () {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        Prompt = GameObject.Find("Prompt").GetComponent<Text>();
        counter = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (counter < 1)
        {
            counter += Time.deltaTime;
        }
        else if (counter >= 1)
        {
            Prompt.text = ("Press Space to retry");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("dfsf");
                GM.exitfailure = false;
            }
        }
    }
}
