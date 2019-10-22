using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimplePlatformerNew : MonoBehaviour
{
    public float jumpSpeed = 3;
    public float moveSpeed = 3;
    public int moveDir = 1;

    private float hSpeed;
    private float vSpeed;
    private bool isGrounded;
    private bool isJumping;
    private float grav;
    bool RightPrevious;
    public bool sheepstart;
    

    public float rayDistance = 1;

    public Rigidbody2D rigid;
    public Camera mainCam;

    public float counter = 0;

    public Animator animator;
    GameManager GM;


    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        mainCam = Camera.main;
        grav = rigid.gravityScale;
        animator = GetComponent<Animator>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator.SetBool("RPrevious", RightPrevious);
    }

    // Update is called once per frame
    void Update()
    {
        if (sheepstart == true)
        {
            animator.SetBool("Sheep", true);
        }
        Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveDir = (int)move.x;
        animator.SetInteger("Move", moveDir);
        if (moveDir == 1)
        {
            RightPrevious = true;
        } else if (moveDir == -1)
        {
            RightPrevious = false;
        }
        animator.SetBool("RPrevious", RightPrevious);
        hSpeed = move.x;
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
        } else if(isGrounded == false)
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
            DestroyObject(GameObject.Find("PlayerPlatform"));
            GM.completed = false;
            GM.Timer = GM.seconds;
        }
        if (collision.collider.tag == "Collectable")
        {
            DestroyObject(GameObject.Find("InteractableObject"));
            GM.completed = true;
        }
        if (collision.collider.tag == "SheepPickup")
        {
            Debug.Log("SheepGet");
            DestroyObject(GameObject.Find("InteractableObject"));
            animator.SetBool("Sheep", true);
            if (sheepstart == true)
            {
                animator.SetBool("Sheep", false);
                sheepstart = false;
            }
            GM.completed = true;
        }
        if (collision.collider.tag == "Bird")
        {
            Debug.Log("BirdGet");
            DestroyObject(GameObject.Find("PlayerPlatform"));
            GM.completed = true;
        }

    }

}
