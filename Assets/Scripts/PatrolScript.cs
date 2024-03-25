using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform ledgeDetector; 
    public LayerMask groundLayer, obstacleLayer, playerLayer;

    public float raycastDistance, obstacleDistance, playerDetectDistance;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
       CheckForObstacles();
            }


    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed * transform.forward.z, rb.velocity.y);
        Debug.Log(rb.transform.forward);
    }
   

    void CheckForObstacles()
    {
        RaycastHit2D hit = Physics2D.Raycast(ledgeDetector.position, Vector2.down, raycastDistance, groundLayer);
        RaycastHit2D hitObstacle = Physics2D.Raycast(ledgeDetector.position, Vector2.right, obstacleDistance, obstacleLayer);
        if (hit.collider == null || hitObstacle.collider == true)
        {
            Rotate();
        }
    }    

    void CheckForPlayer()
    {
        RaycastHit2D hitPlayer = Physics2D.Raycast(ledgeDetector.position, Vector2.right, playerDetectDistance, playerLayer);
        if (hitPlayer.collider == true)
            StartCoroutine(PlayerDetected());
        }

    IEnumerator PlayerDetected()
    {
        Debug.Log("Player Detected!");
        yield return new WaitForSeconds(1);
    }
    
    void Rotate()
    {
        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(ledgeDetector.position, (facingRight ? Vector2.right : Vector2.left) * playerDetectDistance);
    }
}
