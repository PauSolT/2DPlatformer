using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    CapsuleCollider2D collider2D;
    // Start is called before the first frame update

    [Header("Speed")]
    public float currentSpeed;
    float normalSpeed = 10f;

    [Header("Jump")]
    float buttonTime = 0.5f;
    float jumpHeight;
    float normalJumpHeight = 5f;
    float cancelRate = 100f;
    float jumpTime;
    float jumpForce;

    bool jumping;
    bool jumpCancelled;
    bool grounded = true;

    public static GameObject go;

    public ParticleManager particleManager;
    public CheckpointManager checkpointManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<CapsuleCollider2D>();
        currentSpeed = normalSpeed;
        jumpHeight = normalJumpHeight;
        go = gameObject;
    }

    public void Updating()
    {
        Jump();
        HorizontalMovement();
    }

    public void FixedUpdating()
    {
        CancelJump();
    }

    void HorizontalMovement()
    {
        float x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(x * currentSpeed, rb.velocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckGroundStatus();
            if (grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                grounded = false;
                jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
                rb.AddForce(new Vector2(rb.velocity.x *-1, jumpForce), ForceMode2D.Impulse);

                jumping = true;
                jumpCancelled = false;
                jumpTime = 0;
            }
        }

        if (jumping)
        {
            jumpTime += Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.Space)) { 
                jumpCancelled = true; 
            }

            if (jumpTime > buttonTime) { 
                jumping = false; }
        }
    }

    void CancelJump()
    {
        if (jumpCancelled && jumping && rb.velocity.y > 0)
        {
            rb.AddForce(Vector2.down * cancelRate);
        }
    }

    void CheckGroundStatus()
    {
        Vector2 origin = new Vector2(collider2D.bounds.center.x, collider2D.bounds.center.y - (collider2D.bounds.extents.y + 0.1f));
        RaycastHit2D hitGround = Physics2D.Raycast(origin, Vector2.down, 0.01f );

        if (hitGround.collider != null)
        {
            grounded = true;
        }
        else
            grounded = false;

    }

    public void KillPlayer()
    {
        go.SetActive(false);
        if (particleManager != null)
            particleManager.ShowDeathParticles();

        if (checkpointManager != null)
            checkpointManager.RespawnPlayer();
    }

}
