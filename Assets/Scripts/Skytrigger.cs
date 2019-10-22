using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skytrigger : MonoBehaviour
{
    GameManager GM;
    private void Awake()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        GM.completed = true;
        Debug.Log("dsa");
    }
    void OnTriggerStay2D(Collider2D other)
    {
        GM.completed = true;
        Debug.Log("dsa");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GM.completed = false;
    }
}