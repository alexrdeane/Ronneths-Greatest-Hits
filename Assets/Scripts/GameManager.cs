using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    GameObject GMSelf;
    public static GameManager instance = null;
    public int Level = 0;
    public float Timer = 0;
    public string ProtagName, occupation, elixar, Villain;
    int rand = 0;
    public bool completed = true;
    public float seconds = 1;
    int lives = 3;
    public bool exitfailure = true, firstFail = true;
    void Awake () {
        //if statement to prevent several instances of the Game manager running at the same time
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
            //Then destroy this so there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        //Make the game manager survive between scenes
        DontDestroyOnLoad(gameObject);
        rand = Random.Range(0, 3);

    }
	
	// Update is called once per frame
	void Update () {
        Timer += Time.deltaTime;
        if (Timer >= seconds)
        {
            if (completed != true)
            {
                lives = lives - 1;
                if (exitfailure == true)
                {
                    if (firstFail == true)
                    {
                        SceneManager.LoadScene("Failure");
                        firstFail = false;
                    }
                } else
                {
                    firstFail = true;
                    exitfailure = true;
                    LevelLoader();
                }
                
            } else {
                Level++;
                LevelLoader();
            }
            
        }
        
    }
    void LevelLoader()
    {
        Timer = 0;
        switch (Level)
        {
            case 1:
                seconds = 10f;
                completed = true;
                SceneManager.LoadScene("Stolen Sheep");
                break;
            case 2:
                seconds = 7f;
                completed = false;
                SceneManager.LoadScene("Level 1");
                break;
            case 3:
                seconds = 7f;
                completed = false;
                SceneManager.LoadScene("EnterCave");
                break;
            case 4:
                seconds = 6f;
                completed = false;
                SceneManager.LoadScene("AxeGet");
                break;
            case 5:
                seconds = 6f;
                completed = false;
                SceneManager.LoadScene("TreeCut");
                break;
            case 6:
                seconds = 6f;
                completed = false;
                SceneManager.LoadScene("Quiz");
                break;
            case 7:
                seconds = 6f;
                completed = true;
                SceneManager.LoadScene("Battle1");
                break;
            case 8:
                seconds = 6f;
                completed = false;
                SceneManager.LoadScene("Battle3");
                break;
            case 9:
                seconds = 20f;
                completed = true;
                SceneManager.LoadScene("BirdBattle");
                break;
            case 10:
                seconds = 5f;
                completed = false;
                SceneManager.LoadScene("DragonBash1");
                break;

            case 11:
                seconds = 5f;
                completed = false;
                SceneManager.LoadScene("SkyDave");
                break;
            case 12:
                seconds = 20f;
                completed = true;
                SceneManager.LoadScene("BirdBattle2");
                break;
            case 13:
                seconds = 5f;
                completed = false;
                SceneManager.LoadScene("DragonBash2");
                break;
            case 14:
                seconds = 7f;
                completed = false;
                SceneManager.LoadScene("Landed");
                break;
            case 15:
                seconds = 5f;
                completed = false;
                SceneManager.LoadScene("Reward");
                break;
            case 16:
                seconds = 5f;
                completed = false;
                SceneManager.LoadScene("Escape");
                break;
            case 17:
                seconds = 8f;
                completed = false;
                SceneManager.LoadScene("Home again");
                break;
            case 18:
                seconds = 5f;
                completed = true;
                SceneManager.LoadScene("TheEnd");
                break;
            case 19:
                seconds = 1f;
                Level = 0;
                completed = true;
                SceneManager.LoadScene("Title");
                DestroyObject(GameObject.Find("GameManager"));
                break;
        }
    }
}
