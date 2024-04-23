using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float moveSpeed = 3f; // �̵� �ӵ�
    public float patrolRange = 5f; // �̵� ����

    private Vector3 initialPosition; // �ʱ� ��ġ
    private Vector3 targetPosition; // ��ǥ ��ġ

    void Start()
    {
        initialPosition = transform.position; // �ʱ� ��ġ ����
        SetRandomTarget(); // �ʱ� �̵� ��ǥ ����
    }

    void Update()
    {
        // �̵� ���� ������ ��ǥ ��ġ���� �̵�
        if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            // ��ǥ ��ġ�� �����ϸ� ���ο� ��ǥ ��ġ ����
            SetRandomTarget();
        }
    }

    // ������ ��ġ�� �����Ͽ� �̵� ��ǥ�� ����
    void SetRandomTarget()
    {
        // �ʱ� ��ġ���� ������ �������� �̵� ���� ���� ��ġ�� ����
        float randomAngle = Random.Range(0f, 360f);
        Vector3 randomDirection = Quaternion.Euler(0f, randomAngle, 0f) * Vector3.forward;
        targetPosition = initialPosition + randomDirection * Random.Range(0f, patrolRange);
        targetPosition.y = initialPosition.y; // ���� �� ����
    }

    // ����Ƽ �����Ϳ��� �̵� ������ �ð������� ǥ��
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(new Vector3(-5.33f,0,0), patrolRange);
    }
}
