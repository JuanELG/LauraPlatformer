using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementVelocity = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private bool canJump = true;
    [SerializeField] private PlayerVisualController playerVisualController;
    
    private Rigidbody2D _rigidBody = null;
    private float normalizedHorizontalMovement = 0f;

    private void Awake()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();
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
            }
            else if (normalizedHorizontalMovement == -1f)
            {
                playerVisualController.FlipSprite(true);
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
}
