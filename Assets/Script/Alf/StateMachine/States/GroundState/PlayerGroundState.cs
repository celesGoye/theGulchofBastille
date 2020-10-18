﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{

    #region CONTROL VARIABLES
    protected bool isAction;
    #endregion

    public PlayerGroundState(PlayerStateMachine stateMachine, Player player, int animCode, D_PlayerStateMachine data) : base(stateMachine, player, animCode, data)
    {

    }

    protected override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();

        ResetControlVariables();
    }

    public override void Exit()
    {
        base.Exit();
    }

public override void LogicUpdate()
    {
        base.LogicUpdate();

        isAction = true;
        if (isJump)
        {
            stateMachine.SwitchState(player.jumpState);
        }
        else if (isMeleeAttack && player.meleeAttackState.CanMeleeAttack())
        {
            stateMachine.SwitchState(player.meleeAttackState);
        }
        else if (isParry)
        {
            stateMachine.SwitchState(player.parryState);
        }
        else if (isRoll)
        {
            stateMachine.SwitchState(player.rollState);
        }
        else
        {
            isAction = false;
            player.meleeAttackState.UpdateAttackCooldownTimer();
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    protected override void UpdateInputSubscription()
    {
        base.UpdateInputSubscription();
    }

    protected override void UpdateStatusSubscription()
    {
        base.UpdateStatusSubscription();

        shouldFlip = player.CheckFlip();
        currentVelocity = player.Rb.velocity;
    }

    protected override void UpdatePhysicsStatusSubScription()
    {
        base.UpdatePhysicsStatusSubScription();
        isGrounded = player.CheckGrounded();
    }

    protected override void ResetControlVariables()
    {
        base.ResetControlVariables();

        isAction = false;
    }
}
