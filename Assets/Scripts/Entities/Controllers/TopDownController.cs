using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TopDownController : MonoBehaviour // 캐릭터와 몬스터의 공통적인 기능들을 넣어놓는 곳.
{
    public event Action<Vector2> OnMoveEvent; // Action 은 무조건 void 만 반환해야 한다 아니면 Func
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;

    protected bool IsAttacking { get; set; }

    private float timeSinceLastAttack = float.MaxValue;

    // protected 사용하는 이유 : set 은 여기서만 하고싶고, get 은 상속받는 클래스들이 할 수 있게
    protected CharacterStatHandler stats { get; private set; }

    protected virtual void Awake()
    {
        stats = GetComponent<CharacterStatHandler>();
    }

    private void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {        
        if(timeSinceLastAttack < stats.CurrentStat.attackSO.delay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        else if(IsAttacking && timeSinceLastAttack >= stats.CurrentStat.attackSO.delay)
        {
            timeSinceLastAttack = 0f;
            CallAttackEvent(stats.CurrentStat.attackSO);
        }
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); // ?. 의 의미 : 없으면 말고, 있으면 실행한다.
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    private void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }   
}
