using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    Rigidbody2D RB2D;
    float Horizontal = 0;
    GameManager GM;
    public Animator animator;
    public float speed;
    // Use this for initialization
    void Start () {
        RB2D = GetComponent<Rigidbody2D>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        Horizontal = Input.GetAxisRaw("Horizontal") * speed;
        RB2D.velocity = new Vector3(Horizontal * 1.5f, -10, 0);
        int dir = (int) Horizontal * 2;
        animator.SetInteger("Direction",dir);
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Kill")
        {
            Debug.Log("Killed");
            DestroyObject(GameObject.Find("Bird"));
            GM.completed = false;
            GM.Timer = GM.seconds;
        }
    }
}
