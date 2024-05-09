using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TopDownController : MonoBehaviour // 캐릭터와 몬스터의 공통적인 기능들을 넣어놓는 곳.
{
    public event Action<Vector2> OnMoveEvent; // Action 은 무조건 void 만 반환해야 한다 아니면 Func
    public event Action<Vector2> OnLookEvent;

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); // ?. 의 의미 : 없으면 말고, 있으면 실행한다.
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
}
