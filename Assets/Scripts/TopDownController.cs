using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TopDownController : MonoBehaviour // ĳ���Ϳ� ������ �������� ��ɵ��� �־���� ��.
{
    public event Action<Vector2> OnMoveEvent; // Action �� ������ void �� ��ȯ�ؾ� �Ѵ� �ƴϸ� Func
    public event Action<Vector2> OnLookEvent;

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); // ?. �� �ǹ� : ������ ����, ������ �����Ѵ�.
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
}
