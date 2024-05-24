using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] protected GameObject movementPointA;
    [SerializeField] protected GameObject movementPointB;
    [SerializeField] protected float movementVelocity;

    protected Rigidbody2D _rigidBody = null;
    protected GameObject currentMovementDirectionPoint = null;
    
    protected void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        currentMovementDirectionPoint = movementPointA;
    }

    protected void FixedUpdate()
    {
        Move();
    }

    public abstract void Move();
}