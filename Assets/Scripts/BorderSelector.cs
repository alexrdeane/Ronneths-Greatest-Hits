using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BorderSelector : MonoBehaviour {
    public Sprite Border0;
    public Sprite Border1;
    Image image;
    int rand;
    // Use this for initialization
    void Awake () {
        image = GetComponent<Image>();
        rand = Random.Range(0, 1);

        
        
	}
	
	// Update is called once per frame
	void Update () {
        switch (rand)
        {
            case 0:
                image.sprite = Border0;
                break;
            case 1:
                image.sprite = Border1;
                break;
        }
    }
}
