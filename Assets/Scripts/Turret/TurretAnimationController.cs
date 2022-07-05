using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAnimationController : MonoBehaviour
{
    //private moveTowerToPoint towerToPointScript;
    private Animator animator;
    private PlayerParameters playerParameters;
        // Start is called before the first frame update
    void Start()
    {
        //towerToPointScript = GetComponent<moveTowerToPoint>();
        animator = GetComponent<Animator>();
        playerParameters = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerParameters>();
    }

    // Update is called once per frame
    void Update()
    {
        animationConroller();
    }
    private void animationConroller()
    {
        if (!playerParameters.carrying)
        {
            animator.SetBool("CanWalk", true);
        }
        else
        {
            animator.SetBool("CanWalk", false);
        }
    }
}
