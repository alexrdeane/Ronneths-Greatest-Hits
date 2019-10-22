using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboTxtDrag : MonoBehaviour {
    DragonBash DC;
    Text TXT;
    // Use this for initialization
    void Awake()
    {
        DC = GameObject.Find("Controller").GetComponent<DragonBash>();
        TXT = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        TXT.text = ("Combo X " + DC.hits.ToString());
    }
}
