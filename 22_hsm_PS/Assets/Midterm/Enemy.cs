using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    
    public float moveSpeed = 3f; // �̵� �ӵ�
    public float patrolRange = 5f; // �̵� ����

    private Vector3 initialPosition; // �ʱ� ��ġ
    private Vector3 targetPosition; // ��ǥ ��ġ

    public Camera mainCamera;
    public Transform player;

    private bool isChasing = false;
    private bool isWandering = false;
    bool inview=false;
    
   

    void Start()
    {
        initialPosition = transform.position; // �ʱ� ��ġ ����
        SetRandomTarget(); // �ʱ� �̵� ��ǥ ����
    }

    void Update()
    {
        if (IsPlayerInFrustum())
        {
            isChasing = true;
            isWandering = false; // �θ����Ÿ��� ���� ����
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

    // �θ����Ÿ��� ����
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
