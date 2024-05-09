using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    // ������ �̵��� �Ͼ ������Ʈ

    private TopDownController controller;
    private Rigidbody2D movementRigidbody;

    private Vector2 movementDirection = Vector2.zero;

    private void Awake() // Awake ������ �ַ� �� ������Ʈ �ȿ��� ������ ��
    {
        // controller �� TopDownMovement �� ���� ���� ������Ʈ �ȿ� �ִٶ�� ����
        controller = GetComponent<TopDownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    private void FixedUpdate() // FixedUpdate �� ����������Ʈ�� ������ �ִ�
    {
        // rigidbody �� ���� �ٲٴϱ� ���� ������Ʈ �߻�
        ApplyMovement(movementDirection);
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * 5;
        movementRigidbody.velocity = direction;
    }
}