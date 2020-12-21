﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoyeCombat1 : Entity
{
    #region REFERENCES
    public Transform refPlayer {get; private set; }
    public GC1_ObjectToAlive gc1_ota { get; private set; }
    #endregion

    #region STATE
    public GC1_BattleBeginState battleBeginState;
    public GC1_ChargeState chargeState;
    public GC1_DefeatState defeatState;
    public GC1_DefenceState defenceState;
    public GC1_DetectPlayerState detectPlayerState;
    public GC1_EvadeState evadeState;
    public GC1_CombatIdleState combatIdleState;
    public GC1_ParryState parryState;
    public GC1_RunState runState;
    public GC1_StunState stunState;
    public GC1_MeleeAttackState meleeAttackState;
    #endregion

    #region STATE_DATA
    public ChargeStateData chargeStateData;
    public DefenceStateData defenceStateData;
    public DetectPlayerStateData detectPlayerStateData;
    public EvadeStateData evadeStateData;
    public IdleStateData idleStateData;
    public WalkStateData runStateData;
    public StunStateData stunStateData;
    public ParryStateData parryStateData;
    public MeleeAttackStateData meleeAttackStateData;
    #endregion

    protected override void Damage(CombatData combatData)
    {
        base.Damage(combatData);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void KnockBack(CombatData combatData)
    {
        base.KnockBack(combatData);
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }

    private void Awake()
    {
        /* --------- ASIGN REFERENCEs HERE --------------*/

        refPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected override void Start()
    {
        base.Start();
        gc1_ota = (GC1_ObjectToAlive)objectToAlive;

        battleBeginState = new GC1_BattleBeginState(stateMachine, this, "battleBegin", this);
        chargeState = new GC1_ChargeState(stateMachine, this, "charge", chargeStateData, this); // not ready
        defeatState = new GC1_DefeatState(stateMachine, this, "defeat", this);
        defenceState = new GC1_DefenceState(stateMachine, this, "defence", defenceStateData, this);
        detectPlayerState = new GC1_DetectPlayerState(stateMachine, this, null, detectPlayerStateData, this);
        evadeState = new GC1_EvadeState(stateMachine, this, "evade", evadeStateData, this);
        combatIdleState = new GC1_CombatIdleState(stateMachine, this, "combatIdle", idleStateData, this);
        parryState = new GC1_ParryState(stateMachine, this, "parry", parryStateData, this);
        runState = new GC1_RunState(stateMachine, this, "run", runStateData, this);
        stunState = new GC1_StunState(stateMachine, this, "stun", stunStateData, this);
        meleeAttackState = new GC1_MeleeAttackState(stateMachine, this, "meleeAttack", meleeAttackStateData, hitbox, this);

        stateMachine.Initialize(battleBeginState);

        stateCooldownTimer = new StateCooldownTimer();
        stateCooldownTimer.AddStateTimer(meleeAttackState);
        stateCooldownTimer.AddStateTimer(evadeState);
        stateCooldownTimer.AddStateTimer(chargeState);
        stateCooldownTimer.AddStateTimer(defenceState);
        stateCooldownTimer.AddStateTimer(parryState);

        stateMachine.SetStateCooldownTimer(stateCooldownTimer);
}

    protected override void Update()
    {
        base.Update();
    }

    // >>>>>>>>>>>>>>>>>>>>>>>>>>> MESSAGE <<<<<<<<<<<<<<<<<<<<<<<<<<<
    public void CombatTriggered()
    {
        StartCoroutine(battleBeginState.BattleBegin());
    }

    // >>>>>>>>>>>>>>>>>>>>>>>>>>> MESSAGE <<<<<<<<<<<<<<<<<<<<<<<<<<<


    // >>>>>>>>>>>>>>>>>>>>>>>>>>>  HELPER <<<<<<<<<<<<<<<<<<<<<<<<<<<

    public bool IsPlayerWithinMeleeAttackRange() => Mathf.Abs(refPlayer.position.x - aliveGO.transform.position.x) < entityData.meleeAttackDistance;

    // >>>>>>>>>>>>>>>>>>>>>>>>>>>  HELPER <<<<<<<<<<<<<<<<<<<<<<<<<<<
}
