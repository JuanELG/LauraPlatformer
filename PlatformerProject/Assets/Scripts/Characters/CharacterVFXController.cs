using UnityEngine;

public class CharacterVFXController : MonoBehaviour
{
    [SerializeField] private ParticleSystem jumpVFX;
    [SerializeField] private ParticleSystem attackVFX;
    
    public void PlayJumpVFX()
    {
        jumpVFX.Play(true);
    }

    public void PlayAttackVFX()
    {
        attackVFX.Play();
    }
}