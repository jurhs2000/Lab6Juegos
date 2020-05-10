using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 https://www.raywenderlich.com/2427-unity-4-3-2d-tutorial-physics-and-screen-sizes
 */
public class EnemyAnimation : MonoBehaviour
{
    [SerializeField]
    private PolygonCollider2D[] colliders;
    private int currentColliderIndex = 0;
    public Animator enemyAnimation;
    // Start is called before the first frame update
    void Start()
    {
        enemyAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColliderForSprite(int spriteNum)
    {
        colliders[currentColliderIndex].enabled = false;
        currentColliderIndex = spriteNum;
        colliders[currentColliderIndex].enabled = true;
    }

    public void AttackAnimation()
    {
        enemyAnimation.Play("AttackAnim");
    }

}
