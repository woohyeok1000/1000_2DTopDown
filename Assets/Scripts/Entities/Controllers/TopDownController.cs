using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TopDownController : MonoBehaviour // ĳ���Ϳ� ������ �������� ��ɵ��� �־���� ��.
{
    public event Action<Vector2> OnMoveEvent; // Action �� ������ void �� ��ȯ�ؾ� �Ѵ� �ƴϸ� Func
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;

    protected bool IsAttacking { get; set; }

    private float timeSinceLastAttack = float.MaxValue;

    // protected ����ϴ� ���� : set �� ���⼭�� �ϰ�Ͱ�, get �� ��ӹ޴� Ŭ�������� �� �� �ְ�
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
            CallAttackEvent();
        }
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); // ?. �� �ǹ� : ������ ����, ������ �����Ѵ�.
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    private void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }   
}
