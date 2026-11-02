using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    [SerializeField] public KeyCode left = KeyCode.A, up=KeyCode.W, down=KeyCode.S, right=KeyCode.D, dash=KeyCode.Space;

    [SerializeField] float dashDistance;
    [SerializeField] float dashDuration;
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

        if (dashCooldown <= 0 && Input.GetKeyDown(dash))
        {
            StartCoroutine(Dash());
            dashCooldown = 1f; // Reset cooldown
        }
        else
        {
            dashCooldown -= Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        if (isDashing) return;

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
        if (!canWalk) return;
        else
        {
            Vector2 movement = new Vector2(direction * speed, rb.linearVelocity.y);
            rb.linearVelocity = movement;
            float absoluteSpeed = Mathf.Abs(direction * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isOnLadder = true;
            canWalk = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isOnLadder = false;
            canWalk = true;
            rb.gravityScale = 1;
        }
    }
    private void LaderClimb(float verticalDirection)
    {
        Vector2 movement = new Vector2(rb.linearVelocity.x, verticalDirection * speed);
        rb.linearVelocity = movement;
    }
    private IEnumerator Dash()
    {
        isDashing = true;
        canWalk = false;
        Vector2 dashDirection = moveInput.normalized;
        if (dashDirection == Vector2.zero)
        {
            dashDirection = new Vector2(transform.localScale.x, 0).normalized;
        }
        print(dashDirection + "" + dashDistance);

        rb.AddForce(dashDirection * dashDistance, ForceMode2D.Impulse);
        yield return new WaitForSeconds(dashDuration);
        canWalk = true;
        isDashing = false;
    }
}
