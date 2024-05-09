using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerInputController : TopDownController
{
    private Camera camera;
    private void Awake()
    {
        camera = Camera.main; // mainCamera �±װ� �پ��ִ� ī�޶� �����´�
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
        // ���� �����̴� ó���� ���⼭ �ϴ°� �ƴ϶� PlayerMovement ���� ��
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>(); // ���콺 ��ġ�̱� ������ ��ֶ����� �ϸ� �ȵ�
        Vector2 worldPos = camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        CallLookEvent(newAim);
    }

    public void OnFire(InputValue value)
    {
        IsAttacking = value.isPressed;
    }
}