using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private Vector2 mousePosition;
    public Vector2 lastPost;

    //Animation and states

    Animator animator;
    string currentAnimState;
    const string PLAYER_IDLE = "Player_Idle";
    const string PLAYER_WALK_LEFT = "Player_Walk_Left";
    const string PLAYER_WALK_RIGHT = "Player_Walk_Right";
    const string PLAYER_WALK_UP = "Player_Walk_Up";
    const string PLAYER_WALK_DOWN = "Player_Walk_Down";

    [SerializeField] private AudioSource playerWalk;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");


        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            lastPost = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        }
        else
        {
            ChangeAnimationState(PLAYER_IDLE);
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            ChangeAnimationState(PLAYER_WALK_UP);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            ChangeAnimationState(PLAYER_WALK_UP);
        }
         else if (Input.GetAxisRaw("Vertical") > 0)
        {
            ChangeAnimationState(PLAYER_WALK_UP);
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            ChangeAnimationState(PLAYER_WALK_UP);
        }

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            playerWalk.Play();
        }

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    void ChangeAnimationState(string newState)
    {
        //stop animation from interrupting itself
        if (currentAnimState == newState)
        {
            return;
        }

            //Play new anitmation
            animator.Play(newState);

            currentAnimState = newState;
        
    }
}
