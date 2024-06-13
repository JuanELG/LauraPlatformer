using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    protected GameObject movementPointA = null;
    protected GameObject movementPointB = null;
    protected CharacterVisualController visualController = null;
    protected CharacterData characterData = null;
    protected float movementVelocity = 0f;
    protected Rigidbody2D _rigidBody = null;
    protected GameObject currentMovementDirectionPoint = null;
    
    protected void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    protected void FixedUpdate()
    {
        if(characterData != null)
            Move();
    }

    public abstract void Move();

    public void SetCharacterData(CharacterData characterDataParam, CharacterVisualController visualControllerParam, GameObject waypointA, GameObject waypointB)
    {
        characterData = characterDataParam;
        visualController = visualControllerParam;
        movementPointA = waypointA; 
        movementPointB = waypointB; 
        currentMovementDirectionPoint = movementPointA;
        movementVelocity = characterData.GetCharacterBaseVelocity;
    }

    protected void FlipSprite(Vector2 movementDirection)
    {
        visualController.FlipSprite(movementDirection.x < 0);
    }

    protected void ChangeRunAnimationState(bool state)
    {
        visualController.SetBoolAnimation("IsRunning", state);
    }
}