using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayAnimationThenDestroy : MonoBehaviour
{
    private Animator animator;
    private int animatorParametersCount;
    public int accordingToInspectorListTriggerIndex;
    public string ObjectInContactTag;
        public List<String> animationParametersNames;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animatorParametersCount = animator.parameterCount;
        ShowParametersNamesAtInspector();
     
    }

    // Update is called once per frame
    void Update()
    {
        DestroyAfterAnimationEnds();
        
    }
   public void DestroyAfterAnimationEnds()
    {
        int lastLayerindex = animator.layerCount - 1;
        if (animator.GetCurrentAnimatorStateInfo(lastLayerindex).normalizedTime> animator.GetCurrentAnimatorStateInfo(lastLayerindex).length  )
        {
            if (!animator.GetCurrentAnimatorStateInfo(lastLayerindex).loop)
            {
                Destroy(this.gameObject);
            }
            
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectInContactTag))
        {
            animator.SetTrigger(animationParametersNames[accordingToInspectorListTriggerIndex]);
            DestroyAfterAnimationEnds();
        }
    }
    private void ShowParametersNamesAtInspector()
    {
        for (int i = 0; i < animatorParametersCount; i++)
        {
            animationParametersNames.Add(animator.GetParameter(i).name);
        }
    }
    public void useThenKill()
    {
        animator.SetTrigger(animationParametersNames[accordingToInspectorListTriggerIndex]);
        DestroyAfterAnimationEnds();
    }

}
