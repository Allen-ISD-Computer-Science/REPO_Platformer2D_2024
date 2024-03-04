using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask jumpableGround;
    private Rigidbody2D rbAva;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    private Animator anim;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 9f;    
    [SerializeField] private Transform attackBox;

    public float jumpStartTime;
    private float jumpTime;
    private bool isJumping;

    // Start is called before the first frame update
    private void Start()
    {
        rbAva = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rbAva.velocity = new Vector2(dirX * moveSpeed, rbAva.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            isJumping = true;
            jumpTime = jumpStartTime;
            rbAva.velocity = new Vector2(rbAva.velocity.x, jumpForce);
        }
        if (Input.GetButton("Jump") && isJumping == true)
        {
            if (jumpTime > 0)
            {
                rbAva.velocity = new Vector2(rbAva.velocity.x, jumpForce);
                jumpTime -= Time.deltaTime;
            }
        }
        else
        {
            isJumping = false;
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (dirX > 0f)
        {
            anim.SetBool("walking", true);
            sprite.flipX = false;
            attackBox.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (dirX < 0f)
        {
            anim.SetBool("walking", true);
            sprite.flipX = true;
            attackBox.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            anim.SetBool("walking", false);
        }
        if (rbAva.velocity.y > .1f)
        {
            anim.SetBool("jumping", true);
        }
        else if (rbAva.velocity.y < -.1f)
        {
            anim.SetBool("falling", true);
        }
        else
        {
            anim.SetBool("jumping", false);
            anim.SetBool("falling", false);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
