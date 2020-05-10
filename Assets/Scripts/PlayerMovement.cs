using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 startPosition;
    Rigidbody2D rb2d;
    public float maxVelocity;
    public float jumpForce;
    public bool isFalling;
    private int lives;
    private int power;
    public bool isSuper;
    private PlayerAnimation playerAnimation;
    private CameraMovement cameraMovement;
    private bool isWaiting;
    // Start is called before the first frame update
    void Start()
    {
        maxVelocity = 7;
        jumpForce = 15;
        rb2d = GetComponent<Rigidbody2D>();
        playerAnimation = FindObjectOfType(typeof(PlayerAnimation)) as PlayerAnimation;
        cameraMovement = FindObjectOfType(typeof(CameraMovement)) as CameraMovement;
        lives = 3;
        startPosition = transform.position;
        power = 50;
        isSuper = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isFalling && !isWaiting)
        {
            Jump();
            isFalling = true;
        }
        float move = Input.GetAxis("Horizontal");
        if (move != 0 && !isWaiting)
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
        if (Input.GetKey(KeyCode.Q))
        {
            if (isSuper)
            {
                playerAnimation.ShootAnimation();
                isWaiting = true;
            } else
            {
                playerAnimation.NoChargeAnim();
                if (!letsGo)
                {
                    isWaiting = true;
                    if (!CoRunning)
                    {
                        StartCoroutine(waiter_not_that_waiter_just_waiter(.5f));
                    }
                    return;
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            if (isSuper)
            {
                isWaiting = false;
                playerAnimation.StayAnimation();
            }
        }
        if (lives == 0)
        {
            playerAnimation.DieAnimation();
            if (!letsGo)
            {
                isWaiting = true;
                if (!CoRunning)
                {
                    StartCoroutine(dieWaiter(3f));
                }
                return;
            }
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
        if (collision.gameObject.CompareTag("Ground") && !isWaiting)
        {
            isFalling = false;
            playerAnimation.setIsInAnimationFalse();
        }
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            playerAnimation.ActivateGunAnimation();
            Destroy(collision.gameObject);
            isSuper = true;
            if (!letsGo)
            {
                isWaiting = true;
                if (!CoRunning)
                {
                    StartCoroutine(waiter_not_that_waiter_just_waiter(3f));
                }
                return;
            }
        }
    }

    //codigo de jandd661
    //https://answers.unity.com/questions/1386291/how-to-wait-a-certain-amount-of-seconds-in-c.html
    private bool CoRunning;
    private bool letsGo;
    IEnumerator waiter_not_that_waiter_just_waiter(float seconds)
    {
        CoRunning = true;
        //Do some stuff here while we wait
        yield return new WaitForSeconds(seconds);
        isWaiting = false;
        letsGo = true;
        CoRunning = false;
        letsGo = false;
    }

    IEnumerator dieWaiter(float seconds)
    {
        CoRunning = true;
        //Do some stuff here while we wait
        yield return new WaitForSeconds(seconds);
        isWaiting = false;
        transform.position = startPosition;
        lives = 3;
        cameraMovement.restoreCameraPosition();
        letsGo = true;
        CoRunning = false;
        letsGo = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && lives > 0)
        {
            playerAnimation.HurtAnimation();
            if (!letsGo)
            {
                isWaiting = true;
                if (!CoRunning)
                {
                    lives--;
                    StartCoroutine(waiter_not_that_waiter_just_waiter(.5f));
                }
                return;
            }
        }
    }

}
