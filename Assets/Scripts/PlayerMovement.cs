using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 startPosition;
    Rigidbody2D rb2d;
    public float maxVelocity;
    public float jumpForce;
    public bool isFalling;
    private int lives;
    private int power;
    private bool isSuper;
    private PlayerAnimation playerAnimation;
    // Start is called before the first frame update
    void Start()
    {
        maxVelocity = 7;
        jumpForce = 10;
        rb2d = GetComponent<Rigidbody2D>();
        playerAnimation = FindObjectOfType(typeof(PlayerAnimation)) as PlayerAnimation;
        lives = 3;
        power = 50;
        isSuper = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isFalling)
        {
            Jump();
            isFalling = true;
        }
        float move = Input.GetAxis("Horizontal");
        if (move != 0)
        {
            if (move > 0)
            {
                gameObject.transform.localScale = new Vector2(5, 5);
            } else if (move < 0)
            {
                gameObject.transform.localScale = new Vector2(-5, 5);
            }
            playerAnimation.AnimationWalk();
            rb2d.velocity = new Vector2(move * maxVelocity, rb2d.velocity.y);
        } else
        {
            playerAnimation.StayAnimation();
        }
    }

    void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, 18f);
        if (rb2d.velocity.x < 4.5f && rb2d.velocity.x > -4.5f)
        {
            playerAnimation.jumpAnimation();
        } else
        {
            playerAnimation.JumpFAnimation();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isFalling = false;
            playerAnimation.setIsInAnimationFalse();
        }
    }

}
