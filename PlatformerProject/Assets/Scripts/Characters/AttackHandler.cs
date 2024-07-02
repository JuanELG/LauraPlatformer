using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    [SerializeField] private CircleCollider2D rightAttackCollider;
    [SerializeField] private CircleCollider2D leftAttackCollider;

    private void Start()
    {
        gameObject.SetActive(false);
        rightAttackCollider.enabled = false;
        leftAttackCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable damageReceiver) && other.transform != transform.parent)
        {
            damageReceiver.Damage();
        }
    }

    public void FlipAttackCollider(bool flipState)
    {
        if (flipState == false)
        {
            rightAttackCollider.enabled = true;
            leftAttackCollider.enabled = false;
        }
        else
        {
            rightAttackCollider.enabled = false;
            leftAttackCollider.enabled = true;
        }
    }

    public void Attack()
    {
        gameObject.SetActive(true);
    }

    public void DisableAttack()
    {
        gameObject.SetActive(false);
    }
}