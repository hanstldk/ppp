using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Camera mainCamera;

    void Start()
    {
        // 메인 카메라 가져오기
        mainCamera = Camera.main;
    }

    void Update()
    {
        // ASWD 키 입력 감지
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 메인 카메라의 forward와 right 벡터를 이용하여 이동 방향 설정
        Vector3 movement = mainCamera.transform.forward * verticalInput + mainCamera.transform.right * horizontalInput;
        movement.y = 0f; // y 축은 움직이지 않도록 설정

        // 플레이어를 이동시킴
        transform.Translate(movement.normalized * moveSpeed * Time.deltaTime);
    }
}
