using System;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IDamageable
{
    [SerializeField] protected AttackHandler attackHandler;
    [SerializeField] protected DetectionHandler detectionHandler;
    
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

    private void OnEnable()
    {
        detectionHandler.OnDamageableDetected += HandleDamageableDetected;
    }

    private void OnDisable()
    {
        visualController.OnAttackAnimationFinished -= DisableAttackHandler;
        detectionHandler.OnDamageableDetected -= HandleDamageableDetected;
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
        
        visualController.OnAttackAnimationFinished += DisableAttackHandler;
    }

    protected void FlipSprite(Vector2 movementDirection)
    {
        bool flipState = movementDirection.x < 0;
        visualController.FlipSprite(flipState);
        attackHandler.FlipAttackCollider(flipState);
    }

    protected void ChangeRunAnimationState(bool state)
    {
        visualController.SetBoolAnimation("IsRunning", state);
    }

    public void Damage()
    {
        gameObject.SetActive(false);
    }

    private void DisableAttackHandler()
    {
        attackHandler.DisableAttack();
    }

    private void HandleDamageableDetected()
    {
        attackHandler.Attack();
        visualController.SetTriggerAnimation("Attack");
    }
}