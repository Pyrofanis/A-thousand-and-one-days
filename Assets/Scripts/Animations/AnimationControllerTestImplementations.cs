using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class AnimationControllerTestImplementations : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sprite;
    public bool wineSurpaced;
    public Transform carryingTurretTransform;
    private PlayerParameters playerParameters;
    private Transform turretTransform;
    private int animatorParametersCount=0;
    public List<string> animationParametersNames;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        playerParameters = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerParameters>();
    }

    // Update is called once per frame
    void Update()
    {
        WalkingAnimationController();
        CarryTurretController();
        spriteController();
        checkIfAnimationIsPlayed();
        ShowParametersNamesAtInspector();
        wineDrunkActivate();
        cantMoveWhilePickingUpTurret();
        if (wineSurpaced)
        {
            animator.SetTrigger("WineDrinking");
        }
    }
    private void WalkingAnimationController() 
    {
        if (Input.GetAxisRaw("Horizontal")!=0 || Input.GetAxisRaw("Vertical")!=0)
        {
            animator.SetBool("PlayerWalking", true);
        }
        else
        {
            animator.SetBool("PlayerWalking", false);

        }
    }
    private void CarryTurretController()
    {
        if (Input.GetKey(KeyCode.Space) && playerParameters.canCarry )
        {
            
                animator.SetBool("Carrying", true);

            
        }
      
        else if(!playerParameters.carrying)
        {
            animator.SetBool("Carrying", false);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("collectible")&!playerParameters.carrying)
        {
            animator.Play("PickUpCollectibleAnim", 0);
            animator.SetBool("collidedWithCoin", true);

        }
    }
    private void checkIfAnimationIsPlayed()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("PickUpCollectibleAnim")&&animator.GetCurrentAnimatorClipInfo(0).Length<animator.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {
            animator.SetBool("collidedWithCoin", false);

        }
    }
    private void spriteController()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {  
            sprite.flipX=true;
        }
        else
        {
            sprite.flipX = false;

        }
    }
    private void wineDrunkActivate()
    {
        if (GetComponent<coinCollectorScript>().coinsGathered * GetComponent<coinCollectorScript>().coinMultiplier >= GetComponent<coinCollectorScript>().coinsToUpgrade)
        {
            animator.SetTrigger("WineDrinking");
        }
    }
    private void ShowParametersNamesAtInspector()
    {
        for (int i = 0; i < animatorParametersCount; i++)
        {
            animationParametersNames.Add(animator.GetParameter(i).name);
        }
    }
    private void cantMoveWhilePickingUpTurret()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("PickUpTurret"))
        {
            gameObject.GetComponent<PlayerMovement>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<PlayerMovement>().enabled = true;

        }
    }
}
