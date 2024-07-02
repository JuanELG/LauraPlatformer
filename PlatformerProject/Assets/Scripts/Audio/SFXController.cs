using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXController : MonoBehaviour
{
    public static SFXController Instance;

    [SerializeField] private AudioClip jumpSFX;
    [SerializeField] private AudioClip attackSFX;
    
    private AudioSource sfxSource = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        sfxSource = GetComponent<AudioSource>();
    }

    public void PlayJumpSFX()
    {
        sfxSource.PlayOneShot(jumpSFX);
    }
    
    public void PlayAttackSFX()
    {
        sfxSource.PlayOneShot(attackSFX);
    }
}
