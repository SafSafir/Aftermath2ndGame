using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator animator;
    PlayerMovementContoller movement;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovementContoller>();
    }

    private void Update()
    {
        SetPlayerMovementAnimations();
    }

    void SetPlayerMovementAnimations()
    {
        switch (movement.playerStates)
        {
            case PlayerMovementContoller.PlayerStates.Idle:
                animator.SetBool("isWalking", false);
                animator.SetBool("isJumping", false);
                break;
            case PlayerMovementContoller.PlayerStates.Walking:
                animator.SetBool("isWalking", true);
                animator.SetBool("isJumping", false);
                break;
            case PlayerMovementContoller.PlayerStates.Jumping:
                animator.SetBool("isJumping", true);
                break;
            default:
                break;
        }
    }


}
