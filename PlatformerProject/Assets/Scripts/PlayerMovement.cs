using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementVelocity = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundRaycastDistance;
    //[SerializeField] private float smoothMovement = 0;
    [SerializeField] private bool canJump = true;
    [SerializeField] private bool jump = false;
    private Rigidbody2D _rigidBody = null;
    //private float horizontalMovement = 0f;
    private float normalizedHorizontalMovement = 0f;
    //private Vector3 refVelocity = Vector2.one;

    private void Awake()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //horizontalMovement = Input.GetAxis("Horizontal");
        normalizedHorizontalMovement = Input.GetAxisRaw("Horizontal");
        jump = Input.GetButtonDown("Jump");
        //MOVEMENT WITHOUT PHYSICS
        //OPTION 1
        //transform.position += new Vector3(normalizedHorizontalMovement, 0f) * Time.deltaTime * movementVelocity;
        //OPTION 2
        //transform.Translate(new Vector2(normalizedHorizontalMovement, 0f) * Time.deltaTime * movementVelocity);

        /*if (Input.GetKeyDown("Jump") && canJump)
        {
            canJump = false;
            //_rigidBody.AddForce(new Vector2(0, 8f), ForceMode2D.Impulse);
        }*/

        //ManageJump();
    }

    private void FixedUpdate()
    {
        //COLLISION WITHOUT RIGIDBODY
        //CheckGroundColision();

        //PHYSICS MOVEMENT
        //OPTION 1
        _rigidBody.velocity = new Vector2(normalizedHorizontalMovement * movementVelocity * Time.fixedDeltaTime, _rigidBody.velocity.y);
        //OPTION 2
        //Vector2 targetVelocity = new Vector2(horizontalMovement * Time.fixedDeltaTime, _rigidBody.velocity.y);
        //_rigidBody.velocity = Vector3.SmoothDamp(_rigidBody.velocity, targetVelocity, ref refVelocity, smoothMovement);
        //OPTION 3
        //_rigidBody.MovePosition(_rigidBody.position + new Vector2(normalizedHorizontalMovement, _rigidBody.velocity.y) * movementVelocity * Time.fixedDeltaTime);
        //OPTION 4
        //_rigidBody.AddForce(new Vector2 (normalizedHorizontalMovement, _rigidBody.velocity.y) * movementVelocity * Time.fixedDeltaTime, ForceMode2D.Force);
        
        JumpWithPhysics();
    }

    //JUMP WITHOUT PHYSICS
    private void ManageJump()
    {
        if (Input.GetButtonDown("Jump") && canJump && transform.position.y < 10)
        {
            transform.Translate(0, 1f * Time.deltaTime * jumpForce, 0);
        }
        else
        {
            if(transform.position.y > -4)
            {
                transform.Translate(0,-1f * Time.deltaTime * jumpForce, 0);
            }
        }
    }

    private void JumpWithPhysics()
    {
        if (canJump & jump)
        {
            _rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canJump = false;
        }
    }
    
    //COLLISION WITHOUT RIGIDBODY
    /*private void CheckGroundColision()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundRaycastDistance, groundLayer);
        if (hit.collider != null)
        {
            Debug.Log("Collisioning with ground: " + hit.collider.name);
            canJump = true;
        }
        else
        {
            Debug.Log("Not Collisioning with ground");
            canJump = false;
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "suelo")
        {
            Debug.Log("Collision with ground");
            canJump = true;
        }
    }

    /*private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "suelo")
        {
            canJump = false;
        }
    }*/
}
