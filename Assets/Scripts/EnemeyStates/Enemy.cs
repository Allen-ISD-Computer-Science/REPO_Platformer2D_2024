using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Variables
    public EnemyBaseState currentState;

    public PatrolState patrolState;
    public PlayerDetectedState playerDetectedState;
    public ChargeState chargeState;

    public Rigidbody2D rb;
    public Transform ledgeDetector; 
    public LayerMask groundLayer, obstacleLayer, playerLayer;

    public float raycastDistance, obstacleDistance, playerDetectDistance;
    public float speed;
    public float detectionPauseTime;
    public float stateTime;         //Keep track of time when we enter a new state
    public float playerDetectedWaitTime = 1;
    public float chargeTime;
    public float chargeSpeed;

    public GameObject alert;

    public int facingRight = 1;
    
    #endregion



    #region UnityCallbacks
    private void Awake()
    {
        patrolState = new PatrolState(this, "patrol");
        playerDetectedState = new PlayerDetectedState(this, "playerDetected");
        chargeState = new ChargeState(this, "charge");

        currentState = patrolState;
        currentState.Enter();

    }
    private void Update()
    {
        currentState.LogicUpdate();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        currentState.PhysicsUpdate();
    }
    #endregion
    #region Checks
    public bool CheckForObstacles()
    {
        RaycastHit2D hit = Physics2D.Raycast(ledgeDetector.position, Vector2.down, raycastDistance, groundLayer);
        RaycastHit2D hitObstacle = Physics2D.Raycast(ledgeDetector.position, Vector2.right, obstacleDistance, obstacleLayer);
        if (hit.collider == null || hitObstacle.collider == true)
            return true;
        else
            return false;
    }    

   public bool CheckForPlayer()
    {
        RaycastHit2D hitPlayer = Physics2D.Raycast(ledgeDetector.position, facingRight == 1? Vector2.right : Vector2.left, playerDetectDistance, playerLayer);
        if (hitPlayer.collider == true)
            return true;
        else
            return false;
        }

 
    
 
    #endregion
    #region 

    public void SwitchState(EnemyBaseState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
        stateTime = Time.time;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(ledgeDetector.position, (facingRight == 1? Vector2.right : Vector2.left) * playerDetectDistance);
    }
    #endregion
}
