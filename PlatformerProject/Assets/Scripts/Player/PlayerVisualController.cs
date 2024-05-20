using UnityEngine;

public class PlayerVisualController : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FlipSprite(bool flipState)
    {
        spriteRenderer.flipX = flipState;
    }

    public void SetBoolAnimation(string animationParamName, bool parameterState)
    {
        animator.SetBool(animationParamName, parameterState);
    }

    public void SetTriggerAnimation(string animationParamName)
    {
        animator.SetTrigger(animationParamName);
    }
}
