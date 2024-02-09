using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask jumpableGround;
    private Rigidbody2D rbAva;
    private BoxCollider2D coll;
    private Animator anim;


    // Start is called before the first frame update
    private void Start()
    {
        rbAva = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rbAva.velocity = new Vector2(dirX * 7f, rbAva.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rbAva.velocity = new Vector2(rbAva.velocity.x, 9f);
            }


        if (dirX > 0f)
        {
            anim.SetBool("walking", true);
        }
        else if (dirX < 0f)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
