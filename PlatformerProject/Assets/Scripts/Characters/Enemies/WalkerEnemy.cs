using UnityEngine;

public class WalkerEnemy : EnemyBase, IDamageable
{
    public override void Move()
    {
        Vector2 movementDirection = (currentMovementDirectionPoint.transform.position - transform.position).normalized;
        FlipSprite(movementDirection);
        float distanceBetweenObjects = Vector2.Distance(gameObject.transform.position, currentMovementDirectionPoint.transform.position);
        if (distanceBetweenObjects <= 0.5f)
        {
            currentMovementDirectionPoint = currentMovementDirectionPoint == movementPointA ? movementPointB : movementPointA;
        }
        else
        {
            ChangeRunAnimationState(true);
        }
        
        _rigidBody.velocity = new Vector2( movementDirection.x * movementVelocity * Time.fixedDeltaTime, _rigidBody.velocity.y);
    }

    public void Damage()
    {
        throw new System.NotImplementedException();
    }
}