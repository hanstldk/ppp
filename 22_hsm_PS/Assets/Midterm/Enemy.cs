using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float moveSpeed = 3f; // 이동 속도
    public float patrolRange = 5f; // 이동 범위

    private Vector3 initialPosition; // 초기 위치
    private Vector3 targetPosition; // 목표 위치

    void Start()
    {
        initialPosition = transform.position; // 초기 위치 저장
        SetRandomTarget(); // 초기 이동 목표 설정
    }

    void Update()
    {
        // 이동 범위 내에서 목표 위치까지 이동
        if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            // 목표 위치에 도착하면 새로운 목표 위치 설정
            SetRandomTarget();
        }
    }

    // 랜덤한 위치를 설정하여 이동 목표로 설정
    void SetRandomTarget()
    {
        // 초기 위치에서 랜덤한 방향으로 이동 범위 내의 위치를 선택
        float randomAngle = Random.Range(0f, 360f);
        Vector3 randomDirection = Quaternion.Euler(0f, randomAngle, 0f) * Vector3.forward;
        targetPosition = initialPosition + randomDirection * Random.Range(0f, patrolRange);
        targetPosition.y = initialPosition.y; // 높이 값 보정
    }

    // 유니티 에디터에서 이동 범위를 시각적으로 표시
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(new Vector3(-5.33f,0,0), patrolRange);
    }
}
