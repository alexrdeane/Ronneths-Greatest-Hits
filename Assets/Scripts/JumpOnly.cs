using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpOnly: MonoBehaviour
{
    public float jumpSpeed = 60;
    public float moveSpeed = 0;
    public int moveDir = 1;

    private float hSpeed;
    private float vSpeed;
    private bool isGrounded;
    private bool isJumping;
    private float grav;
    bool RightPrevious;


    public float rayDistance = 1;

    public Rigidbody2D rigid;
    public Camera mainCam;
    GameManager GM;

    public float counter = 0;

    public Animator animator;


    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        mainCam = Camera.main;
        grav = rigid.gravityScale;
        animator = GetComponent<Animator>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
            RightPrevious = true;
        animator.SetBool("RPrevious", RightPrevious);
        isGrounded = CheckForGround();
        if (isGrounded == true)
        {
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rigid.velocity += jumpSpeed * Vector2.up;
                }
            }
            animator.SetBool("Jumping", false);
        }
        else if (isGrounded == false)
        {
            animator.SetBool("Jumping", true);
        }


        if (rigid.velocity.y >= 0 && rigid.velocity.y < jumpSpeed * 4 / 5)
        {
            if (!Input.GetKey(KeyCode.Space))
            {
                rigid.velocity = rigid.velocity.x * Vector2.right;
            }
        }
        rigid.velocity += new Vector2(moveSpeed * moveDir * 0.1f, vSpeed);
    }

    void LateUpdate()
    {
        rigid.velocity = new Vector2(Mathf.Clamp(rigid.velocity.x, -moveSpeed, moveSpeed), Mathf.Clamp(rigid.velocity.y, -90, 90));
    }

    bool CheckForGround()
    {
        RaycastHit2D[] rays = Physics2D.RaycastAll(transform.position, Vector2.down, GetComponent<BoxCollider2D>().bounds.size.y + rayDistance);
        foreach (RaycastHit2D ray in rays)
        {
            if (!ray.collider.isTrigger && ray.collider.name != gameObject.name)
            {
                return true;
            }
        }
        return false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Kill")
        {
            Debug.Log("Killed");
            DestroyObject(GameObject.Find("PlayerJump"));
            GM.completed = false;
        }
        if (collision.collider.tag == "Collectable")
        {
            Debug.Log("Hmm");
        }
    }

}
