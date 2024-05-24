using UnityEngine;

public class FlyerEnemy : EnemyBase
{
    public override void Move()
    {
        float movementDirection = 0;
        if (gameObject.transform.position.x < currentMovementDirectionPoint.transform.position.x)
            movementDirection = 1;
        else if (gameObject.transform.position.x > currentMovementDirectionPoint.transform.position.x)
            movementDirection = -1;
        else
        {
            if (currentMovementDirectionPoint == movementPointA)
                currentMovementDirectionPoint = movementPointB;
            else
                currentMovementDirectionPoint = movementPointA;
        }
        
        _rigidBody.velocity = new Vector2( movementDirection * movementVelocity * Time.fixedDeltaTime, 0f);
    }
}
