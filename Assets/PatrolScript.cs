using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform ledgeDetector;
    public LayerMask groundLayer, obstacleLayer;

    public float raycastDistance, obstacleDistance;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(ledgeDetector.position, Vector2.down, raycastDistance, groundLayer);
        RaycastHit2D hitObstacle = Physics2D.Raycast(ledgeDetector.position, Vector2.right, obstacleDistance, obstacleLayer);
        if (hit.collider == null || hitObstacle.collider == true)
        {
            Rotate();
        }

   
            }


    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed * transform.forward.z, rb.velocity.y);
        Debug.Log(rb.transform.forward);
    }
   
    void Rotate()
    {
        transform.Rotate(0, 180, 0);
    }
}
