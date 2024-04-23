using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Camera mainCamera;

    void Start()
    {
        // ���� ī�޶� ��������
        mainCamera = Camera.main;
    }

    void Update()
    {
        // ASWD Ű �Է� ����
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // ���� ī�޶��� forward�� right ���͸� �̿��Ͽ� �̵� ���� ����
        Vector3 movement = mainCamera.transform.forward * verticalInput + mainCamera.transform.right * horizontalInput;
        movement.y = 0f; // y ���� �������� �ʵ��� ����

        // �÷��̾ �̵���Ŵ
        transform.Translate(movement.normalized * moveSpeed * Time.deltaTime);
    }
}
