using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraSet : MonoBehaviour
{
    public Transform target; // 캐릭터의 Transform
    public float rotationSpeed = 90f; // 회전 속도

    void Update()
    {
        // 키보드 입력 감지
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(RotateCamera(-1.5f));
            
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            // 오른쪽 키를 눌렀을 때

            StartCoroutine(RotateCamera(1.5f));

        }
    }

    IEnumerator RotateCamera(float angle)
    {
        for (int i = 0; i < 60; i++)
        {
            transform.RotateAround(target.position, target.up, angle);
            yield return new WaitForSeconds(0.016f);
        }
        // 캐릭터를 중심으로 카메라의 Up 벡터를 축으로 회전
     
    }
}

