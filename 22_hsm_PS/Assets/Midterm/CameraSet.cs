using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraSet : MonoBehaviour
{
    public Transform target; // ĳ������ Transform
    public float rotationSpeed = 90f; // ȸ�� �ӵ�

    void Update()
    {
        // Ű���� �Է� ����
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(RotateCamera(-1.5f));
            
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            // ������ Ű�� ������ ��

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
        // ĳ���͸� �߽����� ī�޶��� Up ���͸� ������ ȸ��
     
    }
}

