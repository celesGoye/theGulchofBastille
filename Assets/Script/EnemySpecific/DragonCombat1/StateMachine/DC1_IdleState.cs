﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DC1_IdleState : IdleState
{
    protected DragonCombat1 enemy;
    protected bool isPlayerInFront;
    public DC1_IdleState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, IdleStateData idleData, DragonCombat1 enemy) : base(stateMachine, entity, animBoolName, idleData)
    {
        this.enemy = enemy;
    }

    public override bool CanAction()
    {
        return base.CanAction();
    }

    public override void Complete()
    {
        base.Complete();
    }

    public override void DoChecks()
    {
        base.DoChecks();
        float tolerence = 0.1f;
        this.isPlayerInFront = enemy.facingDirection > 0 ? (enemy.refPlayer.transform.position.x > enemy.transform.position.x + tolerence) : 
                                                        (enemy.refPlayer.transform.position.x < enemy.transform.position.x - tolerence);
    }

    public override void Enter()
    {
        base.Enter();
        isPlayerInFront = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isPlayerInFront)
        {
            stateMachine.SwitchState(enemy.flipState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void ResetTimer()
    {
        base.ResetTimer();
    }

    public override void UpdateTimer()
    {
        base.UpdateTimer();
    }
}
