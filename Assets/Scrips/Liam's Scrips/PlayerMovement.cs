using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    [SerializeField] public KeyCode left = KeyCode.A, up=KeyCode.W, down=KeyCode.S, right=KeyCode.D, dash=KeyCode.Space;

    [SerializeField] float dashDistance;
    [SerializeField] float dashCooldown;

    [SerializeField] float speed = 6f;

    [SerializeField] bool isOnLadder;
    [SerializeField] bool isDashing;
    [SerializeField] bool canWalk;

    Rigidbody2D rb;
    Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        moveInput = Vector2.zero;
        if (Input.GetKey(left)) moveInput.x -= 1;
        if (Input.GetKey(right)) moveInput.x += 1;
        moveInput = moveInput.normalized;
    }
    void FixedUpdate()
    {
        if (dashCooldown <= 0 && Input.GetKeyDown(dash))
        {
            Dash();
            dashCooldown = 1f; // Reset cooldown
        }
        else
        {
            dashCooldown -= Time.fixedDeltaTime;
        }

        if (isOnLadder)
        {
            float verticalDirection = 0;
            if (Input.GetKey(up)) verticalDirection += 1;
            if (Input.GetKey(down)) verticalDirection -= 1;
            LaderClimb(verticalDirection);
            rb.gravityScale = 0;
        }
        float moveDirection = Input.GetAxis("Horizontal");
        Move(moveDirection);
    }
    private void Move(float direction)
    {
        Vector2 movement = new Vector2(direction * speed, rb.linearVelocity.y);
        rb.linearVelocity = movement;
        float absoluteSpeed = Mathf.Abs(direction * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isOnLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isOnLadder = false;
            rb.gravityScale = 1;
        }
    }
    private void LaderClimb(float verticalDirection)
    {
        Vector2 movement = new Vector2(rb.linearVelocity.x, verticalDirection * speed);
        rb.linearVelocity = movement;
    }
    private void Dash()
    {
        Vector2 dashDirection = moveInput.normalized;
        rb.AddForce(dashDirection * dashDistance, ForceMode2D.Impulse);
    }
}
