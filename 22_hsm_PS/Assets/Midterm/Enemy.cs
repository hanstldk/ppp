using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    
    public float moveSpeed = 3f; // 이동 속도
    public float patrolRange = 5f; // 이동 범위

    private Vector3 initialPosition; // 초기 위치
    private Vector3 targetPosition; // 목표 위치

    public Camera mainCamera;
    public Transform player;

    private bool isChasing = false;
    private bool isWandering = false;
    bool inview=false;
    
   

    void Start()
    {
        initialPosition = transform.position; // 초기 위치 저장
        SetRandomTarget(); // 초기 이동 목표 설정
    }

    void Update()
    {
        if (IsPlayerInFrustum())
        {
            isChasing = true;
            isWandering = false; // 두리번거리는 상태 해제
        }
        else
        {
            isChasing = false;      
        }


        if (inview && !IsPlayerInFrustum())
        {
            inview = false;
            StartCoroutine(StartWandering());
        }



        if (isChasing)
        {
            transform.LookAt(player);
            transform.position=Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }


        if (!isWandering && !isChasing)
        {
            if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.LookAt(targetPosition);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            }
            else
            {
                SetRandomTarget();
            }
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
        Gizmos.DrawWireSphere(initialPosition, patrolRange);
    }

    bool IsPlayerInFrustum()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);

        if (GeometryUtility.TestPlanesAABB(planes, player.GetComponent<Collider>().bounds))
        {
            inview=true;
            return true;
        }
        else
        {
            return false;
        }
    }

    // 두리번거리기 시작
    private IEnumerator StartWandering()
    {
        if (isWandering)
            yield break;
        isWandering = true;
        for (int i = 0;i<90;i++)
        {
            transform.Rotate(0f, -1f, 0f, Space.Self);
            yield return new WaitForSeconds(0.011111f);
        }
        for (int i = 0; i < 180; i++)
        {
            transform.Rotate(0f, 1f, 0f, Space.Self);
            yield return new WaitForSeconds(0.0111111f);
        }
        isWandering = false;
    }
}
