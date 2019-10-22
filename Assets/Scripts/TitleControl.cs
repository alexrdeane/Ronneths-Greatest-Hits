using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleControl : MonoBehaviour {
    public float counter;
    Text Prompt;
    // Use this for initialization
    void Awake () {
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Setup");
            }
        }
    }
}
