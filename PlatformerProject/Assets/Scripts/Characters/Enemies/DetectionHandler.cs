
using System;
using UnityEngine;

public class DetectionHandler : MonoBehaviour
{
    public event Action OnDamageableDetected;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IDamageable damageable))
        {
            OnDamageableDetected?.Invoke();
        }
    }
}
