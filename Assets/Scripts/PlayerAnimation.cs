using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator playerAnimator;
    private bool isInAnimation;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    public void AnimationWalk()
    {
        if (!isInAnimation)
            playerAnimator.Play("RunAnim");
    }

    public void StayAnimation()
    {
        if (!isInAnimation)
            playerAnimator.Play("PrincipalAnimation");
    }

    public void jumpAnimation()
    {
        playerAnimator.Play("JumpAnim");
        isInAnimation = true;
    }

    public void JumpFAnimation()
    {
        playerAnimator.Play("JumpFAnim");
        isInAnimation = true;
    }

    public void ActivateGunAnimation()
    {
        playerAnimator.Play("ActivateGun");
        isInAnimation = true;
    }

    public void NoChargeAnim()
    {
        playerAnimator.Play("NoChargeAnim");
        isInAnimation = true;
    }

    public void ShootAnimation()
    {
        playerAnimator.Play("ShootAnim");
        isInAnimation = true;
    }

    public void HurtAnimation()
    {
        playerAnimator.Play("HurtAnim");
        isInAnimation = true;
    }

    public void DieAnimation()
    {
        playerAnimator.Play("DieAnim");
        isInAnimation = true;
    }

    public void setIsInAnimationFalse()
    {
        isInAnimation = false;
    }

}
