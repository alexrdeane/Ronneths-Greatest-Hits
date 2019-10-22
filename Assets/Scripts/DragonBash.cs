using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBash : MonoBehaviour {

    bool hit;
    public int hits = 0;
    Transform Tree;
    GameManager GM;
    public Sprite Hit1, Hit2;
    public SpriteRenderer SR;
    public int HitsNeeded;
    Transform Trans;

    // Use this for initialization
    void Awake()
    {
        Tree = GameObject.Find("Tree").GetComponent<Transform>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        Trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.completed == false)
        {
            if (Input.GetAxisRaw("A") == 1)
            {
                if (hit == false)
                {
                    Trans.position = new Vector3(0.5f, -0.04f, 0);
                    SR.sprite = Hit2;
                    hits++;
                }
                hit = true;
            }
            else
            {
                hit = false;
            }
        }
        if (hits == HitsNeeded)
        {
            GM.completed = true;
            Tree.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            Tree.position = new Vector3(1.49f, -1f, 0);
        }
        if (hit == true)
        {
            Trans.position = new Vector3(0.5f, -0.04f, 0);
            SR.sprite = Hit2;
        }
        else
        {
            Trans.position = new Vector3(1.06f, -0.04f, 0);
            SR.sprite = Hit1;
        }
    }
}
