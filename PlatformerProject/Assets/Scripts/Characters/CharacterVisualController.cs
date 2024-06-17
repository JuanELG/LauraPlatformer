using System;
using UnityEngine;

public class CharacterVisualController : MonoBehaviour
{
    public event Action OnAttackAnimationFinished;
    
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FlipSprite(bool flipState)
    {
        if(spriteRenderer.flipX != flipState)
            spriteRenderer.flipX = flipState;
    }

    public void SetBoolAnimation(string animationParamName, bool parameterState)
    {
        if(animator.GetBool(animationParamName) != parameterState)
            animator.SetBool(animationParamName, parameterState);
    }

    public void SetTriggerAnimation(string animationParamName)
    {
        animator.SetTrigger(animationParamName);
    }

    public void RaiseFinishAttackAnimation()
    {
        OnAttackAnimationFinished?.Invoke();
    }
}
