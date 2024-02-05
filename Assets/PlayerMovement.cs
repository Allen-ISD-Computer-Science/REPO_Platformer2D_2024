using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rbAva;

    // Start is called before the first frame update
    private void Start()
    {
        rbAva = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rbAva.velocity = new Vector2(dirX * 7f, rbAva.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rbAva.velocity = new Vector2(rbAva.velocity.x, 14f);
        }
    }
}
