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

    private void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        // To do : Magic number ����
        if(timeSinceLastAttack < 0.2f)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        else if(IsAttacking && timeSinceLastAttack >= 0.2f)
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
