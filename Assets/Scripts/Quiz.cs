using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour {
    GameManager GM;
    public int CorrectAnswer;
    int CurrentSelection = 2;
    int rand;
    public int Sdir;
    int Cooldown;
    bool inputdisabled = false;
    Text A1, A2, A3;
    public Sprite Tick, Cross;
    Image FeedBack;
	// Use this for initialization

    void Awake () {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        GM.completed = false;
        CorrectAnswer = Random.Range(0, 3);
        A1 = GameObject.Find("A1").GetComponent<Text>();
        A2 = GameObject.Find("A2").GetComponent<Text>();
        A3 = GameObject.Find("A3").GetComponent<Text>();
        FeedBack = GameObject.Find("FeedBack").GetComponent<Image>();
        switch (CorrectAnswer)
        {
            case 2:
                A1.text = ("> a) Ronneth");
                A2.text = ("b) Ronald");
                A3.text = ("c) Steve");
                break;
            case 1:
                A1.text = ("> a) Ronald");
                A2.text = ("b) Ronneth");
                A3.text = ("c) Runnith");
                break;
            case 0:
                A1.text = ("> a) Rinnuth");
                A2.text = ("b) Ronald");
                A3.text = ("c) Ronneth");
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (inputdisabled == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (CurrentSelection == CorrectAnswer)
                {
                    GM.completed = true;
                    inputdisabled = true;
                    FeedBack.sprite = Tick;
                }
                else
                {
                    GM.completed = false;
                    inputdisabled = true;
                    FeedBack.sprite = Cross;
                }
            }
            if (Cooldown > 0)
            {
                Cooldown--;
            }
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                Sdir = 1;
            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                Sdir = -1;
            }
            else
            {
                Sdir = 0;
            }
            if (CurrentSelection + Sdir == 3 || CurrentSelection + Sdir == -1 || Cooldown > 0)
            {
                Debug.Log("cant move");
            }
            else
            {
                CurrentSelection = CurrentSelection + Sdir;
                Cooldown = 10;

                switch (CurrentSelection)
                {
                    case 2:
                        switch (CorrectAnswer)
                        {
                            case 2:
                                A1.text = ("> a) Ronneth");
                                A2.text = ("b) Ronald");
                                A3.text = ("c) Steve");
                                break;
                            case 1:
                                A1.text = ("> a) Ronald");
                                A2.text = ("b) Ronneth");
                                A3.text = ("c) Runnith");
                                break;
                            case 0:
                                A1.text = ("> a) Rinnuth");
                                A2.text = ("b) Ronald");
                                A3.text = ("c) Ronneth");
                                break;
                        }
                        break;
                    case 1:
                        switch (CorrectAnswer)
                        {
                            case 2:
                                A1.text = ("a) Ronneth");
                                A2.text = ("> b) Ronald");
                                A3.text = ("c) Steve");
                                break;
                            case 1:
                                A1.text = ("a) Ronald");
                                A2.text = ("> b) Ronneth");
                                A3.text = ("c) Runnith");
                                break;
                            case 0:
                                A1.text = ("a) Rinnuth");
                                A2.text = ("> b) Ronald");
                                A3.text = ("c) Ronneth");
                                break;
                        }
                        break;
                    case 0:
                        switch (CorrectAnswer)
                        {
                            case 2:
                                A1.text = ("a) Ronneth");
                                A2.text = ("b) Ronald");
                                A3.text = ("> c) Steve");
                                break;
                            case 1:
                                A1.text = ("a) Ronald");
                                A2.text = ("b) Ronneth");
                                A3.text = ("> c) Runnith");
                                break;
                            case 0:
                                A1.text = ("a) Rinnuth");
                                A2.text = ("b) Ronald");
                                A3.text = ("> c) Ronneth");
                                break;
                        }
                        break;
                }
            }
        }
	}
}
