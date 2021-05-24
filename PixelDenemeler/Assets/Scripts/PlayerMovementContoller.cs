using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementContoller : MonoBehaviour
{

    public enum PlayerStates
    {
        Idle,
        Walking,
        Jumping
    }

    public enum FacingDirection
    {
        Right,
        Left
    }

    public PlayerStates playerStates;
    public FacingDirection facingDirection;

    [Header("Ground Check Attributes")]
    public Transform playerGroundCheck;
    public LayerMask groundLayer;
    public bool isGrounded;


    PlayerAnimationController animController;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;

    [Header("Player Attributes")]
    public int Speed;
    public int jumpSpeed;

    private void Awake()
    {
        animController = GetComponent<PlayerAnimationController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();
        SetFacingDirection();
        CheckIfPlayerIsOnTheGround();
    }



    /// <summary>
    /// This method is for player movement controls
    /// </summary>
    void MovePlayer()
    {
        if (Input.anyKey) 
        {
            float verticalMovement = Input.GetAxis("Vertical");
            float horizontalMovement = Input.GetAxis("Horizontal");
            if (Input.GetButton("Horizontal"))
            {
                transform.position += new Vector3(horizontalMovement, 0,0) * Time.deltaTime * Speed;
                playerStates = PlayerStates.Walking;
                if (horizontalMovement < 0)
                    facingDirection = FacingDirection.Left;
                else if (horizontalMovement >= 0)
                    facingDirection = FacingDirection.Right;
            }
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.velocity = Vector2.up * Time.fixedDeltaTime * jumpSpeed;
                playerStates = PlayerStates.Jumping;
            }
        }
        else
        {
            playerStates = PlayerStates.Idle;
        }
    }

    void SetFacingDirection()
    {
        switch (facingDirection)
        {
            case FacingDirection.Right:
                spriteRenderer.flipX = false;
                break;
            case FacingDirection.Left:
                spriteRenderer.flipX = true;
                break;
            default:
                break;
        }
    }

    void CheckIfPlayerIsOnTheGround()
    {
        isGrounded = Physics2D.OverlapCircle(playerGroundCheck.position, 0.15f, groundLayer);
    }

}
