using UnityEngine;

public class FlyerEnemy : EnemyBase
{
    public override void Move()
    {
        Vector2 movementDirection = (currentMovementDirectionPoint.transform.position - transform.position).normalized;
        FlipSprite(movementDirection);
        float distanceToWaypoint = Vector2.Distance(gameObject.transform.position, currentMovementDirectionPoint.transform.position);
        if (distanceToWaypoint <= 0.5f)
        {
            currentMovementDirectionPoint = currentMovementDirectionPoint == movementPointA ? movementPointB : movementPointA;
        }
        else
        {
            ChangeRunAnimationState(true);
        }
        
        _rigidBody.velocity = new Vector2( movementDirection.x * movementVelocity * Time.fixedDeltaTime,  _rigidBody.velocity.y);
    }
}
