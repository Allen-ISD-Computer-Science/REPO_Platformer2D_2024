using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeState : EnemyBaseState
{
    public ChargeState(Enemy enemy, string animationName) : base(enemy, animationName)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (Time.time >= enemy.stateTime + enemy.chargeTime)
        {
            if (enemy.CheckForPlayer())
                enemy.SwitchState(enemy.playerDetectedState);
            else
                enemy.SwitchState(enemy.patrolState);
        }
        else
        {
            Charge();
        }
    }


    void Charge()
    {
        enemy.rb.velocity = new Vector2(enemy.chargeSpeed * enemy.facingRight, enemy.rb.velocity.y);
    }



    public override string ToString()
    {
        return base.ToString();
    }
}
