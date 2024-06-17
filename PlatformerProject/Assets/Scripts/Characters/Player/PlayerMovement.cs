using UnityEngine;

public class PlayerMovement : MonoBehaviour, IDamageable
{
    [SerializeField] private CharacterData characterData;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private bool canJump = true;
    [SerializeField] private CharacterVisualController playerVisualController;
    [SerializeField] private AttackHandler attackHandler;

    private Rigidbody2D _rigidBody = null;
    private float normalizedHorizontalMovement = 0f;
    private Vector3 playerInitialPosition = Vector3.zero;
    private float movementVelocity = 0f;

    private void Awake()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();
        movementVelocity = characterData.GetCharacterBaseVelocity;
        playerInitialPosition = transform.position;
    }

    private void OnEnable()
    {
        playerVisualController.OnAttackAnimationFinished += DisableAttackHandler;
        /*playerVisualController.OnAttackAnimationFinished += () =>
        {
            attackHandler.DisableAttack();
            attackValue += attackValue;
            Debug.Log("Se acabó la animación de ataque");
        };*/
    }

    private void OnDisable()
    {
        playerVisualController.OnAttackAnimationFinished -= DisableAttackHandler;
        /*playerVisualController.OnAttackAnimationFinished -= () =>
        {
            attackHandler.DisableAttack();
            attackValue += attackValue;
            Debug.Log("Se acabó la animación de ataque");
        };*/
    }

    private void Update()
    {
        normalizedHorizontalMovement = Input.GetAxisRaw("Horizontal"); //1 if right movement and -1 if left movement
        
        if (normalizedHorizontalMovement != 0f)
        {
            playerVisualController.SetBoolAnimation("IsRunning", true);
            if (normalizedHorizontalMovement == 1f)
            {
                playerVisualController.FlipSprite(false);
                attackHandler.FlipAttackCollider(false);
            }
            else if (normalizedHorizontalMovement == -1f)
            {
                playerVisualController.FlipSprite(true);
                attackHandler.FlipAttackCollider(true);
            }
        }
        else
        {
            playerVisualController.SetBoolAnimation("IsRunning", false);
        }
        
        if (canJump & Input.GetButtonDown("Jump"))
        {
            Jump();
            playerVisualController.SetTriggerAnimation("Jump");
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    private void FixedUpdate()
    {
        //PHYSICS MOVEMENT
        _rigidBody.velocity = new Vector2(normalizedHorizontalMovement * movementVelocity * Time.fixedDeltaTime, _rigidBody.velocity.y);
    }

    private void Jump()
    {
        _rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            canJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = false;
        }
    }

    public void RespawnPlayer()
    {
        transform.position = playerInitialPosition;
    }

    private void Attack()
    {
        attackHandler.Attack();
        playerVisualController.SetTriggerAnimation("Attack");
    }

    public void Damage()
    {
        GameManager.Instance.PlayerDeath(this);
    }

    private void DisableAttackHandler()
    {
        attackHandler.DisableAttack();
    }
}
